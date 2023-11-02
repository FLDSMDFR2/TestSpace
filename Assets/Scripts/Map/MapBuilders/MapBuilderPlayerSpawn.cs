public class MapBuilderPlayerSpawn : MapBuilder
{
    public MapBuilderPlayerSpawn(SectorMap sectorMap) : base(sectorMap) { }

    public override void PerformBuilderProcess()
    {
        var foundLoc = false;
        Sector sector = null;
        var maxLoops = 50;
        while (!foundLoc && maxLoops > 0)
        {
            maxLoops--;
            sector = sectorMap.GetRandomSectorWithinMap(3);
            if (sector != null && sector.EncounterLocation == null) foundLoc = true;
        }

        if (sector != null)
        {
            sectorMap.SetPlayerSpawnSector(sector);
        }  
    }
}
