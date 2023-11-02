using UnityEngine;

public class ColliderTriggers : MonoBehaviour
{
    public delegate void ColliderTrigger(Collider collision);
    public event ColliderTrigger OnColliderTriggerEnter;
    public event ColliderTrigger OnColliderTriggerExit;

    protected virtual void OnTriggerEnter(Collider collision)
    {
        OnColliderTriggerEnter?.Invoke(collision);
    }

    protected virtual void OnTriggerExit(Collider collision)
    {
        OnColliderTriggerExit?.Invoke(collision);
    }
}
