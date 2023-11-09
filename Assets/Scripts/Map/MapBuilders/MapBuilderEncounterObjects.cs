using System;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilderEncounterObjects : MapBuilder
{
    protected int encounterDistanceDifficulty;
    protected MapObjectManager mapObjectManager;

    public MapBuilderEncounterObjects(SectorMap sectorMap, MapObjectManager mapObjectManager, int encounterDistanceDifficulty) : base(sectorMap) 
    {
        this.encounterDistanceDifficulty = encounterDistanceDifficulty;
        this.mapObjectManager = mapObjectManager;
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

        var tryCount = 5;
        while (tryCount > 0)
        {
            tryCount--;
            if (!AddEncounter(sector, sectorMap.GetRandomLocationWithSector(sector), MapObjectTypes.Encounter)) continue;
            encounterSecotrs.Add(sector);
            break;
        }
    }

    protected virtual bool AddEncounter(Sector sector, Vector3 loc, MapObjectTypes type)
    {
        var scale = RandomGenerator.SeededRange(mapObjectManager.GetProviderMinSize(type), mapObjectManager.GetProviderMaxSize(type));
        var finalLoc = new Vector3(loc.x, -(mapObjectManager.GetProviderYValueOffset(type)), loc.z);
        if (!IsValidatePlacement(sector, finalLoc, scale, type))
            return false;

        var missionLoc = new EncounterLocation();
        missionLoc.ObjectType = type;
        missionLoc.Location = finalLoc;
        missionLoc.Scale = scale;
        missionLoc.Difficulty = GetEncounterLocationDifficulty(sector);
        missionLoc.ObjectManager = mapObjectManager;
        missionLoc.EncounterType = EncounterLocationType.None;

        sector.EncounterLocation = missionLoc;
        return true;
    }

    protected virtual bool IsValidatePlacement(Sector sector, Vector3 loc, float scale, MapObjectTypes type)
    {
        return true;
    }

    protected virtual EncounterLocationDifficulty GetEncounterLocationDifficulty(Sector sectors)
    { 
        for(var i = 1; i < Enum.GetNames(typeof(EncounterLocationDifficulty)).Length; i++)
        {
            var difX = Mathf.Abs(sectors.SectorPosX - sectorMap.GetPlayerSpawnSector().SectorPosX);
            var difZ = Mathf.Abs(sectors.SectorPosZ - sectorMap.GetPlayerSpawnSector().SectorPosZ);
            var dist = Mathf.Max(difX, difZ);
            if ((dist >= (i-1) * encounterDistanceDifficulty && dist < i * encounterDistanceDifficulty) &&
                (dist >= (i-1) * encounterDistanceDifficulty && dist < i * encounterDistanceDifficulty))
                return (EncounterLocationDifficulty)i;
        }

        return EncounterLocationDifficulty.None;
    }
}
