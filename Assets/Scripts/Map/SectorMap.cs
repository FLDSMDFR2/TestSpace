using System.Collections.Generic;
using UnityEngine;

public class SectorMap
{
    public int TotalSectorsX;
    public int TotalSectorsZ;

    public int SectorSize = 1000;

    protected List<List<Sector>> sectors = new List<List<Sector>>();
    protected List<Sector> encounterSectors = new List<Sector>();
    protected List<Sector> encounterMissionSectors = new List<Sector>();
    protected Sector playSpawnSector;
    protected Sector activeMissionSector;
    protected Sector exitSector;

    public SectorMap(int boundsX, int boundsY, int sectorSize)
    {
        TotalSectorsX = boundsX;
        TotalSectorsZ = boundsY;
        SectorSize = sectorSize;

        SetUpSectors();
    }

    protected virtual void SetUpSectors()
    {
        for (int x = 0; x < TotalSectorsX; x++)
        {
            sectors.Add(new List<Sector>());
            for (int z = 0; z < TotalSectorsZ; z++)
            {
                sectors[x].Add(new Sector(x, z, SectorSize));
            }
        }
    }

    #region Public Class Helpers
    public virtual List<List<Sector>> GetSectors()
    {
        return sectors;
    }
    public virtual List<Sector> GetEncounterSectors()
    {
        return encounterSectors;
    }
    public virtual void SetEncounterSectors(List<Sector> sectors)
    {
        encounterSectors = sectors;
    }
    public virtual List<Sector> GetEncounterMissionSectors()
    {
        return encounterMissionSectors;
    }
    public virtual void SetEncounterMissionSectors(List<Sector> sectors)
    {
        encounterMissionSectors = sectors;
    }
    public virtual Sector GetActiveMissionSector()
    {
        return activeMissionSector;
    }
    public virtual void SetActiveMissionSector(Sector sector)
    {
        activeMissionSector = sector;
        GameEventSystem.Encounter_OnMissionChange(sector.EncounterLocation.Encounter);
    }
    public virtual Sector GetExitSector()
    {
        return exitSector;
    }
    public virtual void SetExitSector(Sector sector)
    {
        exitSector = sector;
    }
    public virtual bool IsPlayerSpawnSector(Sector sector)
    {
        if (sector == null || playSpawnSector == null) return false;
        return playSpawnSector == sector;
    }
    public virtual Sector GetPlayerSpawnSector()
    {
        return playSpawnSector;
    }
    public virtual void SetPlayerSpawnSector(Sector sector)
    {
        playSpawnSector = sector;
    }

    public virtual Sector GetSector(int x, int z)
    {
        if (IsOutOfBounds(x,z)) return null;

        return sectors[x][z];
    }
    public virtual Sector GetSector(Vector3 loc)
    {
        if (IsOutOfBounds(loc)) return null;

        return sectors[(int)(loc.x / SectorSize)][(int)(loc.z / SectorSize)];
    }

    public virtual bool IsOutOfBounds(Vector3 loc)
    {
        //world space
        return (loc.x < 0 || loc.x > (TotalSectorsX * SectorSize)) || (loc.z < 0 || loc.z > (TotalSectorsZ * SectorSize));
    }
    public virtual bool IsOutOfBounds(int x, int z)
    {
        // map index
        return (x > TotalSectorsX - 1 || x < 0) || ( z > TotalSectorsZ - 1 || z < 0);
    }

    public virtual Sector GetRandomSectorWithinMap(int offset = 0)
    {
        var xLoc = RandomGenerator.SeededRange(offset, TotalSectorsX - offset);
        var zLoc = RandomGenerator.SeededRange(offset, TotalSectorsZ - offset);

        return GetSector(xLoc, zLoc);
    }

    public virtual Vector3 GetRandomLocationWithSector(Sector sectors)
    {
        var xLoc = RandomGenerator.SeededRange((sectors.SectorPosX * SectorSize) + 200, ((sectors.SectorPosX * SectorSize) + SectorSize) - 200);
        var zLoc = RandomGenerator.SeededRange((sectors.SectorPosZ * SectorSize) + 200, ((sectors.SectorPosZ * SectorSize) + SectorSize) - 200);

        return new Vector3(xLoc, 0, zLoc);
    }

    public virtual int GetTotalDistanceBetweenSectors(Sector sector1, Sector sector2)
    {
        return Mathf.Abs(sector1.SectorPosX - sector2.SectorPosX) + Mathf.Abs(sector1.SectorPosZ - sector2.SectorPosZ);
    }
    #endregion
}
