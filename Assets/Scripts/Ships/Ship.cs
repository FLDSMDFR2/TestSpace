using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ship : MonoBehaviour, IDamageable
{
    public delegate void ShipEvent(Ship data);
    public event ShipEvent Ship_OnHealthUpdate;
    public event ShipEvent Ship_PerformBlink;

    public int MaxHealth;
    [ReadOnlyInspector]
    [SerializeField]
    protected int health;

    public Vector3 MovementVelocity;

    public float BlinkDistance;
    public float BlinkDelayTime;
    public float BlinkCoolDownTime;
    protected float lastBlinkTime;

    protected List<Weapon> weapons;

    protected virtual void Awake()
    {
        GameEventSystem.Game_Start += ShipReset;
        GameEventSystem.Player_BlinkTriggered += GameEventSystem_Player_BlinkTriggered;
        weapons = GetComponentsInChildren<Weapon>().ToList();
        ShipReset();
    }

    protected virtual void Start()
    {
        StartCoroutine(Shoot());
    }

    protected virtual void ShipReset()
    {
        lastBlinkTime = Time.time;
    }

    protected virtual IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            foreach (var weapon in weapons)
            {
                weapon.Shoot(MovementVelocity);
            }
        }
    }

    #region Blink
    protected virtual void GameEventSystem_Player_BlinkTriggered(Player data)
    {
        TryToBlink();
    }

    protected virtual void TryToBlink()
    {
        if ((Time.time - lastBlinkTime) < BlinkCoolDownTime) return;
        StartCoroutine(WaitForBlink());
    }

    protected virtual IEnumerator WaitForBlink()
    {
        yield return new WaitForSeconds(BlinkDelayTime);
        Ship_PerformBlink.Invoke(this);
        lastBlinkTime = Time.time;
    }
    #endregion

    #region IDamageable
    public virtual void SetHealth(int Health)
    {
        this.health = Math.Clamp(Health, 0, MaxHealth);
        Ship_OnHealthUpdate?.Invoke(this);
    }
    public virtual int GetHealth()
    {
        return health;
    }

    public virtual void UpdateHealth(int Health)
    {
        this.health = Math.Clamp(this.health + health, 0, MaxHealth);
        Ship_OnHealthUpdate?.Invoke(this);
    }

    public virtual void TakeDamage(IDamager damager)
    {
        SetHealth(health - damager.GetDamage());
    }
    #endregion
}
