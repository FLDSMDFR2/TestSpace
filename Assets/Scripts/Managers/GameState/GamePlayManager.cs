using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    protected GameStateManager stateManager;

    protected virtual void Awake()
    {
        stateManager = new GameStateManager();
    }
}