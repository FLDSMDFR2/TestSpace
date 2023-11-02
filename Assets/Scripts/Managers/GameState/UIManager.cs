using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject HUD;
    public GameObject StartScreen;
    public GameObject PauseMenu;
    public GameObject GameOverScreen;

    protected virtual void Awake()
    {
        GameEventSystem.UI_StartClick += StartClicked;
        GameEventSystem.UI_RestartClick += StartClicked;
        GameEventSystem.Player_Killed += ShowGameOver;
        GameEventSystem.Player_Paused += GameEventSystem_Player_Paused;
        GameEventSystem.Game_StageComplete += GameEventSystem_Game_StageComplete;
    }

    protected virtual void Start()
    {
        AllUIActiveState(true);
        ShowStartMenu();
    }

    protected virtual void ShowStartMenu()
    {
        AllUIActiveState();

        GameEventSystem.Game_OnGameOver();

        StartScreen.SetActive(true);
    }

    protected virtual void StartClicked()
    {
        GameEventSystem.Game_OnStart();
        ShowHUD();
    }

    protected virtual void ShowHUD()
    {
        AllUIActiveState();

        GameEventSystem.Game_OnResume();

        HUD.SetActive(true);
    }

    protected virtual void ShowGameOver(Player data)
    {
        AllUIActiveState();

        GameEventSystem.Game_OnGameOver();

        GameOverScreen.SetActive(true);
    }

    protected virtual void GameEventSystem_Player_Paused(Player data)
    {
        AllUIActiveState();

        if (GameStateData.IsPaused)
        {
            PauseMenu.SetActive(true);
        }
        else
        {
            ShowHUD();
        }
    }

    protected virtual void GameEventSystem_Game_StageComplete()
    {
        ShowGameOver(null);
    }

    protected virtual void AllUIActiveState(bool isActive = false)
    {
        HUD.SetActive(isActive);
        StartScreen.SetActive(isActive);
        PauseMenu.SetActive(isActive);
        GameOverScreen.SetActive(isActive);
    }
}
