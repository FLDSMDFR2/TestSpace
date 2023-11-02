using System;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilderEncounterObjects : MapBuilder
{
    protected int encounterDistanceDifficulty;
    public MapBuilderEncounterObjects(SectorMap sectorMap, int encounterDistanceDifficulty) : base(sectorMap) 
    {
        this.encounterDistanceDifficulty = encounterDistanceDifficulty;
    }

    public override void PerformBuilderProcess()
    {
        var tempList = new List<Sector>();
        foreach (var xSector in sectorMap.GetSectors())
        {
            foreach (var sector in xSector)
            {
                // dont add Encounter to edge of map
                if (sector.SectorPosX <= 0 || sector.SectorPosX >= sectorMap.TotalSectorsX - 1 ||
                    sector.SectorPosZ <= 0 || sector.SectorPosZ >= sectorMap.TotalSectorsZ - 1) continue;

                // dont add Encounter to player spawn location
                if (sectorMap.IsPlayerSpawnSector(sector)) continue;

                CheckForEncounter(sector, tempList);
            }
        }
        sectorMap.SetEncounterSectors(tempList);
    }

    protected virtual void CheckForEncounter(Sector sector, List<Sector> encounterSecotrs)
    {
        // randomally dont place background objects
        if (RandomGenerator.SeededRandomBool()) return;

        AddEncounter(sector, sectorMap.GetRandomLocationWithSector(sector));
        encounterSecotrs.Add(sector);
    }

    protected virtual void AddEncounter(Sector sectors, Vector3 loc)
    {
        var missionLoc = new EncounterLocation();
        missionLoc.ObjectType = SectorObjectLocation.MapObjectTypes.Encounter;
        missionLoc.Location = loc;
        missionLoc.Difficulty = GetEncounterLocationDifficulty(sectors);

        sectors.EncounterLocation = missionLoc;
    }

    protected virtual EncounterLocation.EncounterLocationDifficulty GetEncounterLocationDifficulty(Sector sectors)
    { 
        for(var i = 1; i < Enum.GetNames(typeof(EncounterLocation.EncounterLocationDifficulty)).Length; i++)
        {
            var difX = Mathf.Abs(sectors.SectorPosX - sectorMap.GetPlayerSpawnSector().SectorPosX);
            var difZ = Mathf.Abs(sectors.SectorPosZ - sectorMap.GetPlayerSpawnSector().SectorPosZ);
            var dist = Mathf.Max(difX, difZ);
            if ((dist >= (i-1) * encounterDistanceDifficulty && dist < i * encounterDistanceDifficulty) &&
                (dist >= (i-1) * encounterDistanceDifficulty && dist < i * encounterDistanceDifficulty))
                return (EncounterLocation.EncounterLocationDifficulty)i;
        }

        return EncounterLocation.EncounterLocationDifficulty.None;
    }
}
