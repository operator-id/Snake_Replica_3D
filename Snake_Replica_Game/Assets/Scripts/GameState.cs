using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{



    private void Start()
    {

        Time.timeScale = 1;


    }


    public static void PlayerDied()
    {
        Time.timeScale = 0;

    }
    public static void Pause()
    {
        Time.timeScale = 0;
    }
    public static void Unpause()
    {
        Time.timeScale = 1;
    }
    public static void RestartLevel()
    {
        //temporarly hard coded!
        SceneManager.LoadScene("Level 1");
    }
    public static void Exit()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
        Application.Quit();
    }
}
