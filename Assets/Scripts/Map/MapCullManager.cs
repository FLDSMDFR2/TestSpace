using System.Collections.Generic;
using UnityEngine;

public class MapCullManager
{
    protected SectorMap sectorMap;
    protected Sector lastPlayerSector;
    protected List<Sector> active = new List<Sector>();
    protected int cullDistance;

    public MapCullManager(SectorMap sectorMap, int cullDistance)
    {
        this.sectorMap = sectorMap;
        this.cullDistance = cullDistance;

        InitAllSectorsToActive();
    }

    protected virtual void InitAllSectorsToActive()
    {
        foreach (var xSectors in sectorMap.GetSectors())
        {
            foreach (var ySectors in xSectors)
            {
                active.Add(ySectors);
            }
        }
    }

    public virtual void CullMap(Sector playerSector)
    {
        if (lastPlayerSector == playerSector) return;
        lastPlayerSector = playerSector;

        var activeStartX = Mathf.Clamp(playerSector.SectorPosX - cullDistance, 0, (sectorMap.TotalSectorsX)-1);
        var activeEndX = Mathf.Clamp(playerSector.SectorPosX + cullDistance, 0, (sectorMap.TotalSectorsX) - 1);
        var activeStartZ = Mathf.Clamp(playerSector.SectorPosZ - cullDistance, 0, (sectorMap.TotalSectorsZ) - 1);
        var activeEndZ = Mathf.Clamp(playerSector.SectorPosZ + cullDistance, 0, (sectorMap.TotalSectorsZ) - 1);

        List<Sector> tempActiveList = new List<Sector>();
        for (int x = activeStartX; x <= activeEndX; x++)
        {
            for (int z = activeStartZ; z <= activeEndZ; z++)
            {
                var activeSector = sectorMap.GetSector(x, z);
                if (!active.Contains(activeSector)) ActivateSector(activeSector);
                tempActiveList.Add(activeSector);
            }
        }

        foreach (Sector sector in active)
        {
            if (!tempActiveList.Contains(sector))
            {
                DeactivateSector(sector);
            }
        }
        active = tempActiveList;
    }

    protected virtual void ActivateSector(Sector sector)
    {
        foreach (var bgl in sector.BackgroundObjects)
        {
            bgl.Object.transform.position = bgl.Location;
            bgl.Object.SetActive(true);
        }
        if (sector.EncounterLocation != null)
        {
            // if this is the exit location dont do anything it will activate on its own when needed
            if (sector.EncounterLocation.ObjectType == MapObjectTypes.Exit) return;

            sector.EncounterLocation.Object.SetActive(true);
        }
    }

    protected virtual void DeactivateSector(Sector sector)
    {
        foreach (var bgl in sector.BackgroundObjects)
        {
            bgl.Object.SetActive(false);
        }

        if (sector.EncounterLocation != null && sector.EncounterLocation.Object != null) sector.EncounterLocation.Object.SetActive(false);
    }
}
