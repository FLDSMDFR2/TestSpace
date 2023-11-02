public class EncounterManager
{
    protected Encounter encounterToActive;
    protected SectorMap map;

    public EncounterManager(SectorMap map)
    {
        this.map = map;
        GameEventSystem.Encounter_EnterEncounterRange += GameEventSystem_Encounter_EnterEncounterRange;
        GameEventSystem.Encounter_ExitEncounterRange += GameEventSystem_Encounter_ExitEncounterRange;
        GameEventSystem.Player_ActivateEncounter += GameEventSystem_Player_ActivateEncounter;
        GameEventSystem.Encounter_Complete += GameEventSystem_Encounter_Complete;
    }

    protected virtual void GameEventSystem_Player_ActivateEncounter(Player data)
    {
        if (encounterToActive == null) return;
        encounterToActive.ActivateEncounter();
    }

    protected virtual void GameEventSystem_Encounter_Complete(Encounter encounter)
    {
        // if this is a mission encounter then advance to next
        if (encounter == map.GetActiveMissionSector().EncounterLocation.Encounter)
        {
            if (map.GetEncounterMissionSectors().Count > 1)
            {
                map.GetEncounterMissionSectors().RemoveAt(0);
                map.SetActiveMissionSector(map.GetEncounterMissionSectors()[0]);
            }
        }
    }

    protected virtual void GameEventSystem_Encounter_EnterEncounterRange(Encounter encounter)
    {
        encounterToActive = encounter;
    }
    protected virtual void GameEventSystem_Encounter_ExitEncounterRange(Encounter encounter)
    {
        encounterToActive = null;
    }
}
