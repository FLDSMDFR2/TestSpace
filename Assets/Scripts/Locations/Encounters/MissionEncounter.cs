using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionEncounter : Encounter
{
    public GameObject Active;
    public GameObject Complete;

    protected override void InitEncounter()
    {
        Active.SetActive(true);
        Complete.SetActive(false);
    }

    public override void EncounterCompleted()
    {      
        Active.SetActive(false);
        Complete.SetActive(true);

        base.EncounterCompleted();
    }
}
