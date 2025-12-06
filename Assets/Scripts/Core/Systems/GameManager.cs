using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public enum GameState
    {
        Boot,
        MainMenu,
        Playing,
        Paused
    }
    [field: SerializeField] public string firstNameScene { get; private set; } = "Level_01";
    [field: SerializeField] public string mainMenuScene { get; private set; } = "MainMenu";

    public GameState CurrentState { get; private set; } = GameState.Boot;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        CurrentState = GameState.Playing;
        SceneLoader.LoadScene(firstNameScene);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        CurrentState = GameState.MainMenu;
        SceneLoader.LoadScene(mainMenuScene);
    }

    public void ReloadGame()
    {
        Time.timeScale = 1f;
        CurrentState = GameState.Playing;
        SceneLoader.ReloadCurrent();
    }

    public void QuitGame()
    {
        Application.Quit();
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void PauseGame()
    {
        if (CurrentState != GameState.Playing)
        {
            return;
        }
        
        Time.timeScale = 0f;
        CurrentState = GameState.Paused;
    }

    public void ResumeGame()
    {
        if (CurrentState != GameState.Paused)
        {
            return;
        }
        
        Time.timeScale = 1f;
        CurrentState = GameState.Playing;
    }
}
