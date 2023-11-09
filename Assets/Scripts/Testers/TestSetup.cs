using UnityEngine;

public class TestSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameStateData.IsPaused = false;
        GameStateData.IsGameOver = false;
    }

}
