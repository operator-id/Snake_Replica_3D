using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject deathScreen;
    bool gameIsPaused;

    private void Start()
    {
        deathScreen.SetActive(false);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            if (gameIsPaused)
            {
                GameState.Pause();
                deathScreen.SetActive(true);
            }
            else
            {
                GameState.Unpause();
                deathScreen.SetActive(false);
            }
        }
    }

    public void LoadDeathScreen()
    {
        GameState.PlayerDied();
        deathScreen.SetActive(true);
    }
}
