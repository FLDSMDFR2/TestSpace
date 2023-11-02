using UnityEngine;

public class Projectile : MonoBehaviour, IPoolable, IDamager
{
    #region Variables
    [Header("Base Projectile")]
    /// <summary>
    /// Id of this object for object pooling
    /// </summary>
    [SerializeField]
    protected string PoolingID;
    /// <summary>
    /// Damage of projectile
    /// </summary>
    protected int damage;
    /// <summary>
    /// Range of projectile
    /// </summary>
    protected float range;
    /// <summary>
    /// Speed of Projectile
    /// </summary>
    protected float speed;
    /// <summary>
    /// Direction of travel
    /// </summary>
    protected Vector3 direction = Vector3.forward;
    /// <summary>
    /// Added volocity if whatever fired the projectile is moving
    /// </summary>
    protected Vector3 addedDirectionalVelocity = Vector3.forward;
    /// <summary>
    /// start pos
    /// </summary>
    protected Vector3 startPos;
    [SerializeField]
    protected GameObject ImpactEffect;
    [SerializeField]
    protected bool IsPlayerProjectile;
    #endregion

    #region Class Logic
    /// <summary>
    /// Init the Projectile before firing
    /// </summary>
    /// <param name="dir"></param>
    /// <param name="range"></param>
    /// <param name="damage"></param>
    public virtual void InitProjectile(Vector3 dir, Vector3 addedDirectionalVelocity, float range, int damage, float speed)
    {
        direction = dir;

        this.damage = damage;
        this.range = range;
        this.speed = speed;
        this.addedDirectionalVelocity = addedDirectionalVelocity;

        startPos = transform.position;
    }

    /// <summary>
    /// Fire the Projectile
    /// </summary>
    public virtual void Fire(){ }

    #region Destruction
    protected virtual void PlayDestruction()
    {
        if (ImpactEffect == null) return;

        var impactEffect = ObjectPooler.GetObject(GetPoolId()+ "_Destruction", ImpactEffect, transform.position, Quaternion.identity);
        impactEffect.SetActive(true);
    }

    protected virtual void DestoryProjectial()
    {
        ObjectPooler.DestroyObject(gameObject);
    }
    #endregion

    protected virtual void Hit(IDamageable damageable)
    {
        damageable.TakeDamage(this);
    }

    #endregion

    #region IPoolable
    public virtual string GetPoolId()
    {
        return PoolingID;
    }
    #endregion

    #region IDamager
    public int GetDamage()
    {
        return damage;
    }

    public string GetName()
    {
        return PoolingID;
    }
    #endregion
}