
using System;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilderMissionEncounterLocations : MapBuilder
{
    protected int missionsToComplete;

    protected List<int> difficultyMap = new List<int>();

    public MapBuilderMissionEncounterLocations(SectorMap sectorMap, int missionsToComplete) : base(sectorMap)
    {
        this.missionsToComplete = missionsToComplete;

        var difficulties = Enum.GetNames(typeof(EncounterLocationDifficulty)).Length - 1;
        var totalPerDif = missionsToComplete / difficulties;
        var remander = missionsToComplete % difficulties;

        for (int i = 0  ; i < Enum.GetNames(typeof(EncounterLocationDifficulty)).Length; i++)
        {
            difficultyMap.Add(0);
            if ((EncounterLocationDifficulty)i == EncounterLocationDifficulty.None) continue;
            difficultyMap[i] += totalPerDif;
            if (i <= remander) difficultyMap[i] += 1;
        }

    }
    public override void PerformBuilderProcess()
    {
        var tempList = new List<Sector>();
        var lastSecor = sectorMap.GetPlayerSpawnSector();
        for (int index = 0; index < difficultyMap.Count; index++)
        {
            if ((EncounterLocationDifficulty)index == EncounterLocationDifficulty.None) continue;

            GetSectorsForMissionDifficulty((EncounterLocationDifficulty)index, difficultyMap[index], lastSecor, tempList);
            if (tempList.Count > 0) lastSecor = tempList[tempList.Count - 1];
        }

        if (tempList.Count > 0)
        {
            sectorMap.SetEncounterMissionSectors(tempList);
            sectorMap.SetActiveMissionSector(tempList[0]);
        }
    }

    protected virtual void GetSectorsForMissionDifficulty(EncounterLocationDifficulty difficulty, 
        int difficultiesToFind, Sector startFromSector, List<Sector> foundSectors)
    {
        var currentSectorToSearchFrom = startFromSector;

        for (int count = 0; count < difficultiesToFind; count++)
        {

            var difficultTypeList = new List<Sector>();
            var destArray = new List<int>();
            foreach (var sector in sectorMap.GetEncounterSectors())
            {
                if (foundSectors.Contains(sector)) continue;
                if (sector.EncounterLocation.Difficulty != difficulty) continue;

                var dist = sectorMap.GetTotalDistanceBetweenSectors(sector, currentSectorToSearchFrom);
                var found = false;
                for (int i = 0; i < difficultTypeList.Count; i++)
                {
                    if (dist < destArray[i])
                    {
                        difficultTypeList.Insert(i, sector);
                        destArray.Insert(i, dist);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    difficultTypeList.Add(sector);
                    destArray.Add(dist);
                }
            }

            Sector foundSector = null;
            if (difficultTypeList.Count > 3) foundSector = difficultTypeList[RandomGenerator.SeededRange(0, difficultTypeList.Count / 3)];
            else if (difficultTypeList.Count > 0) foundSector = difficultTypeList[0];

            if (foundSector != null)
            {
                foundSector.EncounterLocation.EncounterType = EncounterLocationType.Mission;
                foundSectors.Add(foundSector);
                currentSectorToSearchFrom = foundSector;
            }
        }     
    }
}
