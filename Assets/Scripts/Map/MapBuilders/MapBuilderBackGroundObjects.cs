using UnityEngine;

public class MapBuilderBackGroundObjects : MapBuilder
{
    protected MapObjectManager mapObjectManager;

    public MapBuilderBackGroundObjects(SectorMap sectorMap, MapObjectManager mapObjectManager) : base(sectorMap)
    {
        this.mapObjectManager = mapObjectManager;
    }

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
        var tryCount = 5;
        while (count > 0 && tryCount > 0)
        {
            tryCount--;
            if (!AddBackGroundObject(sectors, sectorMap.GetRandomLocationWithSector(sectors), MapObjectTypes.Planet)) continue;// TODO: get random type
            count--;
        }
    }

    protected virtual bool AddBackGroundObject(Sector sector, Vector3 loc, MapObjectTypes type)
    {
        var scale = RandomGenerator.SeededRange(mapObjectManager.GetProviderMinSize(type), mapObjectManager.GetProviderMaxSize(type));
        var finalLoc = new Vector3(loc.x, -(scale + mapObjectManager.GetProviderYValueOffset(type)), loc.z);
        if (!IsValidatePlacement(sector, finalLoc, scale, type))
            return false;

        var obj = new SectorObjectLocation();
        obj.ObjectType = type; 
        obj.Location = finalLoc;
        obj.Scale = scale;
        obj.ObjectManager = mapObjectManager;

        sector.BackgroundObjects.Add(obj);
        return true;
    }

    protected virtual bool IsValidatePlacement(Sector sector, Vector3 loc, float scale, MapObjectTypes type)
    {
        foreach (var bg in sector.BackgroundObjects) 
        {
            if (Vector3.Distance(bg.Location, loc) <= ((scale + mapObjectManager.GetProviderPadding(type)) + (bg.Scale + mapObjectManager.GetProviderPadding(type))))
            {
                return false;
            }
        }

        return true;
    }
}
