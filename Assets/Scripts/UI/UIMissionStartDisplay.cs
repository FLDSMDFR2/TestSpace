using UnityEngine;

public class UIMissionStartDisplay : MonoBehaviour
{
    public GameObject Display;

    protected virtual void Awake()
    {
        GameEventSystem.Encounter_EnterEncounterRange += GameEventSystem_encounterToActive_EnterEncounterRange;
        GameEventSystem.Encounter_ExitEncounterRange += GameEventSystem_encounterToActive_ExitEncounterRange;
        GameEventSystem.Encounter_Complete += GameEventSystem_Encounter_Complete;
        GameEventSystem.Game_StageComplete += GameEventSystem_Game_StageComplete;
    }

    private void GameEventSystem_Game_StageComplete()
    {
        Display.SetActive(false);
    }

    private void GameEventSystem_Encounter_Complete(Encounter sector)
    {
        Display.SetActive(false);
    }

    private void GameEventSystem_encounterToActive_ExitEncounterRange(Encounter encounter)
    {
        Display.SetActive(false);
    }

    protected void GameEventSystem_encounterToActive_EnterEncounterRange(Encounter encounter)
    {
        Display.SetActive(true);
    }
}
