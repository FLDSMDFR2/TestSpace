
public class MapBuilderValidator : MapBuilder
{
    protected bool isValidMap = false;
    protected int missionsToComplete;

    public MapBuilderValidator(SectorMap sectorMap, int missionsToComplete) : base(sectorMap) 
    { 
        this.missionsToComplete = missionsToComplete;
    }

    public override void PerformBuilderProcess()
    {
        // player location needs to have been found
        if (sectorMap.GetPlayerSpawnSector() == null) return;
        // Make sure we have found all mission locations
        // +1 for exit location
        if (sectorMap.GetEncounterMissionSectors().Count != missionsToComplete + 1) return;
        // If we dont have an active mission
        if (sectorMap.GetActiveMissionSector() == null) return;
        // If we dont have an exit location
        if (sectorMap.GetExitSector() == null) return;

        isValidMap = true;
    }

    public virtual bool IsValidMap()
    {
        return isValidMap;
    }

}
