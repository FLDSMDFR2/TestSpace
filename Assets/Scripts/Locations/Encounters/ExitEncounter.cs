
public class ExitEncounter : Encounter
{
    protected override void InitEncounter() 
    {
        GameEventSystem.Encounter_MissionChange += GameEventSystem_Encounter_MissionChange;
    }

    protected virtual void GameEventSystem_Encounter_MissionChange(Encounter encounter)
    {
        if (encounter == this)
        {
            gameObject.SetActive(true);
        }
    }

    public override void ActivateEncounter()
    {
        GameEventSystem.Game_OnStageComplete();
    }

    protected virtual void OnDestroy()
    {
        GameEventSystem.Encounter_MissionChange -= GameEventSystem_Encounter_MissionChange;
    }
}
