using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public int MaxHealth;
    [ReadOnlyInspector]
    [SerializeField]
    protected int health;

    public Vector3 MovementVelocity;

    public float BlinkDelayTime;
    public float BlinkCoolDownTime;
    protected float lastBlinkTime;

    protected List<Weapon> weapons;

    protected virtual void Awake()
    {
        GameEventSystem.Game_Start += ResetPlayer;
        GameEventSystem.Player_BlinkTriggered += GameEventSystem_Player_BlinkTriggered;
        weapons = GetComponentsInChildren<Weapon>().ToList();
        ResetPlayer();
    }

    protected virtual void Start()
    {
        StartCoroutine(Shoot());
    }

    #region Blink
    protected virtual void GameEventSystem_Player_BlinkTriggered(Player data)
    {
        if ((Time.time - lastBlinkTime) < BlinkCoolDownTime) return;
        StartCoroutine(WaitForBlink());
    }
    protected virtual IEnumerator WaitForBlink()
    {
        yield return new WaitForSeconds(BlinkDelayTime);
        GameEventSystem.Player_OnTriggerBlink(this);
        lastBlinkTime = Time.time;
    }
    #endregion

    #region IDamageable
    public void SetHealth(int Health)
    {
        this.health = Math.Clamp(Health, 0, MaxHealth);
        GameEventSystem.Player_OnHealthUpdate(this);
    }
    public virtual int GetHealth()
    {
        return health;
    }

    public void UpdateHealth(int Health)
    {
        this.health = Math.Clamp(this.health + health, 0, MaxHealth);
        GameEventSystem.Player_OnHealthUpdate(this);
    }

    public void TakeDamage(IDamager damager)
    {
        SetHealth(health - damager.GetDamage());

        IsPlayerKilled(damager);
    }

    #endregion

    protected virtual IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            foreach(var weapon in weapons)
            {
                weapon.Shoot(MovementVelocity);
            }
        }
    }

    protected virtual void ResetPlayer()
    {
        SetHealth(MaxHealth);
        lastBlinkTime = Time.time;
        GameEventSystem.Player_OnResetData(this);
    }

    protected virtual void IsPlayerKilled(IDamager damager)
    {
        if (health <= 0 && this != null)
        {
            GameEventSystem.Player_OnKilled(this);
        }
    }
}
