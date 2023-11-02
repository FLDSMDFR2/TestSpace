using UnityEngine;

public class Encounter : MonoBehaviour
{
    protected virtual void Awake()
    {
        var trigger = GetComponentInChildren<ColliderTriggers>();
        if (trigger != null)
        {
            trigger.OnColliderTriggerEnter += OnTriggerEnter;
            trigger.OnColliderTriggerExit += OnTriggerExit;
        }
        InitEncounter();
    }

    protected virtual void InitEncounter(){ }

    public virtual void ActivateEncounter()
    {
        EncounterCompleted();
    }

    public virtual void EncounterCompleted()
    {
        GameEventSystem.Encounter_OnComplete(this);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            GameEventSystem.Encounter_OnEnterEncounterRange(this);
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            GameEventSystem.Encounter_OnExitEncounterRange(this);
        }
    }
}
