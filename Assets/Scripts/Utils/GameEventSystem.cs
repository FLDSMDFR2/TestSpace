public class GameEventSystem
{
    #region UI Interaction Events
    public delegate void UIInteractionEvent();
    public static event UIInteractionEvent UI_StartClick;
    public static event UIInteractionEvent UI_RestartClick;

    public static void UI_OnStartClick()
    {
        UI_StartClick?.Invoke();
    }

    public static void UI_OnRestartClick()
    {
        UI_RestartClick?.Invoke();
    }
    #endregion

    #region Game Events
    public delegate void GameEvent();
    public static event GameEvent Game_Pause;
    public static event GameEvent Game_Resume;
    public static event GameEvent Game_Start;
    public static event GameEvent Game_Over;
    public static event GameEvent Game_StageComplete;

    public static void Game_OnPause()
    {
        Game_Pause?.Invoke();
    }
    public static void Game_OnResume()
    {
        Game_Resume?.Invoke();
    }
    public static void Game_OnStart()
    {
        Game_Start?.Invoke();
    }
    public static void Game_OnGameOver()
    {
        Game_Over?.Invoke();
    }
    public static void Game_OnStageComplete()
    {
        Game_StageComplete?.Invoke();
    }
    #endregion

    #region Map Events
    public delegate void MapEvent(SectorMap map);
    public static event MapEvent Map_Built;
    public static event MapEvent Map_Drawn;

    public static void Map_OnBuilt(SectorMap map)
    {
        Map_Built?.Invoke(map);
    }
    public static void Map_OnDrawn(SectorMap map)
    {
        Map_Drawn?.Invoke(map);
    }
    #endregion

    #region Encounter Events
    public delegate void EncounterEvent(Encounter sector);
    public static event EncounterEvent Encounter_MissionChange;
    public static event EncounterEvent Encounter_EnterEncounterRange;
    public static event EncounterEvent Encounter_ExitEncounterRange;
    public static event EncounterEvent Encounter_Complete;

    public static void Encounter_OnMissionChange(Encounter encounter)
    {
        Encounter_MissionChange?.Invoke(encounter);
    }

    public static void Encounter_OnEnterEncounterRange(Encounter encounter)
    {
        Encounter_EnterEncounterRange?.Invoke(encounter);
    }

    public static void Encounter_OnExitEncounterRange(Encounter encounter)
    {
        Encounter_ExitEncounterRange?.Invoke(encounter);
    }
    public static void Encounter_OnComplete(Encounter encounter)
    {
        Encounter_Complete?.Invoke(encounter);
    }
    #endregion

    #region Player Events
    public delegate void PlayerEvent(Player data);
    public static event PlayerEvent Player_Killed;
    public static event PlayerEvent Player_HealthUpdate;
    public static event PlayerEvent Player_Paused;
    public static event PlayerEvent Player_BlinkTriggered; // blink button press
    public static event PlayerEvent Player_TriggerBlink; // blink should now be performed
    public static event PlayerEvent Player_ResetData;
    public static event PlayerEvent Player_ActivateEncounter;

    public static void Player_OnKilled(Player data)
    {
        Player_Killed?.Invoke(data);
    }
    public static void Player_OnHealthUpdate(Player data)
    {
        Player_HealthUpdate?.Invoke(data);
    }
    public static void Player_OnPaused(Player data)
    {
        Player_Paused?.Invoke(data);
    }
    public static void Player_OnBlinkTriggered(Player data)
    {
        Player_BlinkTriggered?.Invoke(data);
    }
    public static void Player_OnTriggerBlink(Player data)
    {
        Player_TriggerBlink?.Invoke(data);
    }
    public static void Player_OnResetData(Player data)
    {
        Player_ResetData?.Invoke(data);
    }
    public static void Player_OnActivateEncounter(Player data)
    {
        Player_ActivateEncounter?.Invoke(data);
    }
    #endregion

    #region Enemy Events
    //public delegate void EnemyEvent(Enemy data);
    //public static event EnemyEvent Enemy_Killed;

    //public static void Enemy_OnEnemyKilled(Enemy data)
    //{
    //    Enemy_Killed?.Invoke(data);
    //}
    #endregion

}
