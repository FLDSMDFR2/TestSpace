using UnityEngine;

public class GamePlayerManager : MonoBehaviour
{
    protected GameStateManager stateManager;

    protected virtual void Awake()
    {
        stateManager = new GameStateManager();
    }
}