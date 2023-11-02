
public class MapBuilder
{
    protected SectorMap sectorMap;

    public MapBuilder(SectorMap sectorMap)
    {
        this.sectorMap = sectorMap;
    }

    public virtual void PerformBuilderProcess() { }
}
