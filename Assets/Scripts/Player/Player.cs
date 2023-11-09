using UnityEngine;

public class Player : MonoBehaviour
{
    protected Ship ship;

    protected virtual void Awake()
    {
        ship = GetComponentInChildren<Ship>();
        ship.Ship_OnHealthUpdate += Ship_Ship_OnHealthUpdate;
    }

    public virtual Ship GetShip()
    {
        return ship;
    }

    private void Ship_Ship_OnHealthUpdate(Ship data)
    {
        IsPlayerKilled(data);
    }

    protected virtual void IsPlayerKilled(Ship data)
    {
        if (data.GetHealth() <= 0 && this != null)
        {
            GameEventSystem.Player_OnKilled(this);
        }
    }
}
