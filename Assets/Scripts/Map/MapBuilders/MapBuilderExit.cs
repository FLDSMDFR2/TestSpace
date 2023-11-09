using System.Collections.Generic;
using UnityEngine;

public class MapBuilderExit : MapBuilder
{
    protected MapObjectManager mapObjectManager;

    public MapBuilderExit(SectorMap sectorMap, MapObjectManager mapObjectManager) : base(sectorMap)
    {
        this.mapObjectManager = mapObjectManager;
    }

    public override void PerformBuilderProcess()
    {
        FindExitLocation(sectorMap.GetEncounterMissionSectors()[sectorMap.GetEncounterMissionSectors().Count-1]);
    }

    protected virtual void FindExitLocation(Sector lastMissionSector)
    {
        var tempEmptySectorList = new List<Sector>();
        var tempEmptySectorListDist = new List<int>();
        foreach (var xSectors in sectorMap.GetSectors())
        {
            foreach (var zSectors in xSectors)
            {
                if (sectorMap.IsPlayerSpawnSector(zSectors)) continue;
                if (zSectors.EncounterLocation != null) continue;

                var dist = sectorMap.GetTotalDistanceBetweenSectors(zSectors, lastMissionSector);
                var found = false;
                for (int i = 0; i < tempEmptySectorList.Count; i++)
                {
                    if (dist < tempEmptySectorListDist[i])
                    {
                        tempEmptySectorList.Insert(i, zSectors);
                        tempEmptySectorListDist.Insert(i, dist);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    tempEmptySectorList.Add(zSectors);
                    tempEmptySectorListDist.Add(dist);
                }
            }
        }

        Sector foundSector = null;
        if (tempEmptySectorList.Count > 3) foundSector = tempEmptySectorList[RandomGenerator.SeededRange(0, tempEmptySectorList.Count / 5)];
        else if (tempEmptySectorList.Count > 0) foundSector = tempEmptySectorList[0];
        if (foundSector != null)
        {
            AddExitLocation(foundSector, sectorMap.GetRandomLocationWithSector(foundSector), MapObjectTypes.Exit);
        }
    }

    protected virtual bool AddExitLocation(Sector sector, Vector3 loc, MapObjectTypes type)
    {
        if (sector == null) return false;

        var scale = RandomGenerator.SeededRange(mapObjectManager.GetProviderMinSize(type), mapObjectManager.GetProviderMaxSize(type));
        var finalLoc = new Vector3(loc.x, -(mapObjectManager.GetProviderYValueOffset(type)), loc.z);
        if (!IsValidatePlacement(sector, finalLoc, scale, type))
            return false;

        var missionLoc = new EncounterLocation();
        missionLoc.ObjectType = type;
        missionLoc.Location = finalLoc;
        missionLoc.Scale = scale;
        missionLoc.Difficulty = EncounterLocationDifficulty.None;
        missionLoc.ObjectManager = mapObjectManager;
        missionLoc.EncounterType = EncounterLocationType.Mission;

        sector.EncounterLocation = missionLoc;

        sectorMap.SetExitSector(sector);
        sectorMap.GetEncounterMissionSectors().Add(sector);

        return true;
    }

    protected virtual bool IsValidatePlacement(Sector sector, Vector3 loc, float scale, MapObjectTypes type)
    {
        return true;
    }
}
