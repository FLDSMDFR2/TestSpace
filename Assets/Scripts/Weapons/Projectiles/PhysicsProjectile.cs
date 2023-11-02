using System;
using System.Collections;
using System.Threading;
using UnityEngine;

public class PhysicsProjectile : Projectile
{
    protected float velocity;
    protected System.Timers.Timer destoryTimer;

    public override void Fire()
    {
        velocity = speed + addedDirectionalVelocity.magnitude;
        StartCoroutine(DestoryProjectialRange());
    }

    protected virtual void FixedUpdate()
    {
        if (GameStateData.IsPaused || GameStateData.IsGameOver) return;

        //transform.position += (this.direction) * (speed * Time.deltaTime);
        transform.Translate(Vector3.forward * ((velocity) * Time.deltaTime));
    }

    protected override void DestoryProjectial()
    {
        StopCoroutine(DestoryProjectialRange());
        base.DestoryProjectial();
    }

    protected virtual IEnumerator DestoryTimer()
    {
        yield return new WaitForSeconds(range / velocity);

        DestoryProjectial();
    }

    protected virtual IEnumerator DestoryProjectialRange()
    {

        yield return new WaitUntil(() => {
            return Vector3.Distance(startPos, transform.position) > range;
        });

        DestoryProjectial();
    }

    #region Collision
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (IsPlayerProjectile && other.gameObject.GetComponent<Player>() != null) return;
        else if (!IsPlayerProjectile && other.gameObject.GetComponent<Enemy>() != null) return;

        var projectile = other.gameObject.GetComponent<Projectile>();
        if (projectile != null && projectile.isActiveAndEnabled == projectile.isActiveAndEnabled) return;

        var damageable = other.GetComponent<IDamageable>();
        if (damageable == null) return;

        Hit(damageable);
        PlayDestruction();
        DestoryProjectial();
    }
    #endregion
}
