using System.Collections.Generic;
using UnityEngine;

public class MapBuilderExit : MapBuilder
{
    public MapBuilderExit(SectorMap sectorMap) : base(sectorMap){}

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
        AddExitLocation(foundSector);
    }

    protected virtual void AddExitLocation(Sector exitSector)
    {
        if (exitSector == null) return;

        var missionLoc = new EncounterLocation();
        missionLoc.ObjectType = SectorObjectLocation.MapObjectTypes.Exit;
        missionLoc.Location = sectorMap.GetRandomLocationWithSector(exitSector);
        missionLoc.Difficulty = EncounterLocation.EncounterLocationDifficulty.None;

        exitSector.EncounterLocation = missionLoc;

        sectorMap.SetExitSector(exitSector);
        sectorMap.GetEncounterMissionSectors().Add(exitSector);
    }
}
