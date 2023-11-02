using UnityEngine;

public class MapBuilderBackGroundObjects : MapBuilder
{
    public MapBuilderBackGroundObjects(SectorMap sectorMap) : base(sectorMap){ }

    public override void PerformBuilderProcess()
    {
        foreach (var xSector in sectorMap.GetSectors())
        {
            foreach (var sector in xSector)
            {
                CheckForBackGroundObject(sector);
            }
        }
    }

    protected virtual void CheckForBackGroundObject(Sector sectors)
    {
        // randomally dont place background objects
        if (RandomGenerator.SeededRandomBool()) return;

        var count = RandomGenerator.SeededRange(1, 3);
        while (count > 0)
        {
            AddPlanetBackground(sectors, sectorMap.GetRandomLocationWithSector(sectors));

            count--;
        }
    }

    protected virtual void AddPlanetBackground(Sector sectors, Vector3 loc)
    {
        var obj = new SectorObjectLocation();
        obj.ObjectType = SectorObjectLocation.MapObjectTypes.BackGround;
        obj.Location = loc;

        sectors.BackgroundLocations.Add(obj);
    }
}
