using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionEncounter : Encounter
{
    public GameObject Active;
    public GameObject Complete;

    public Material Easy;
    public Material Medium;
    public Material Hard;

    protected override void InitEncounter()
    {
        Active.SetActive(true);
        Complete.SetActive(false);
    }

    public override void SetDifficulty(EncounterLocationDifficulty difficulty)
    {
        base.SetDifficulty(difficulty);
        var material = Easy;
        if (encounterDifficulty == EncounterLocationDifficulty.Medium)
        {
            material = Medium;
        }
        else if (encounterDifficulty == EncounterLocationDifficulty.Hard)
        {
            material = Hard;
        }
        var renderers = GetComponentsInChildren<Renderer>();
        foreach (var renderer in renderers)
        {
            renderer.material = material;
        }
    }

    public override void EncounterCompleted()
    {      
        Active.SetActive(false);
        Complete.SetActive(true);

        base.EncounterCompleted();
    }
}
