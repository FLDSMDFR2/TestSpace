using System.Collections.Generic;
using UnityEngine;

public class Sector
{
    public int SectorSize;
    public int SectorPosX;
    public int SectorPosZ;

    public List<SectorObjectLocation> BackgroundLocations = new List<SectorObjectLocation>();
    public EncounterLocation EncounterLocation;

    public Sector(int x, int z, int size)
    {
        SectorSize = size;
        SectorPosX = x;
        SectorPosZ = z;
    }

    public virtual void SetMissionLocationObject(GameObject obj)
    {
        if (EncounterLocation == null) return;       
        EncounterLocation.Object = obj;

        var encounter = obj.GetComponent<Encounter>();
        if (encounter == null) return;
        EncounterLocation.Encounter = encounter;

        if (EncounterLocation.ObjectType == SectorObjectLocation.MapObjectTypes.Exit) EncounterLocation.Object.SetActive(false);
    }
}
