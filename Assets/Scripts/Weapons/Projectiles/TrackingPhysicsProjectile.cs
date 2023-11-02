using System.Collections;
using UnityEngine;

public class TrackingPhysicsProjectile : PhysicsProjectile
{
    public float FindTargetUpdateTime;

    protected Transform target;

    public override void InitProjectile(Vector3 dir, Vector3 addedDirectionalVelocity, float range, int damage, float speed)
    {
        base.InitProjectile(dir, addedDirectionalVelocity, range, damage, speed);

        target = null;
    }

    public override void Fire()
    {
        base.Fire();

        StartCoroutine(FindTarget());
    }

    protected override void FixedUpdate()
    {
        if (GameStateData.IsPaused || GameStateData.IsGameOver) return;

        if (target != null && target.gameObject.activeSelf)
        {
            var directionToLook = target.position - transform.position;
            var lookRot = Quaternion.LookRotation(directionToLook);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * GetLookSpeed());        
        }
        base.FixedUpdate();
    }

    protected virtual float GetLookSpeed()
    {
        if (target != null && target.gameObject.activeSelf)
        {
            var startDist = Vector3.Distance(target.transform.position, startPos);
            var currentDist =Vector3.Distance(target.transform.position, transform.position);
            return  ((float)startDist / (float)currentDist);
        }

        return 0;
    }

    protected virtual IEnumerator FindTarget()
    {
        yield return new WaitForSeconds(FindTargetUpdateTime);

        var targets = Physics.OverlapSphere(transform.position, range);
        foreach(var t in targets)
        {
            // only target what we should
            if (IsPlayerProjectile && t.gameObject.GetComponent<Enemy>() == null) continue;
            if (!IsPlayerProjectile && t.gameObject.GetComponent<Player>() == null) continue;

            // dont target anything outside the overall range
            if (Vector3.Distance(startPos, t.gameObject.transform.position) > range) continue;

            target = t.transform;
            break;
        }      
    }
}
