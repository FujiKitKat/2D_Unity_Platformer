using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private PauseMenuScreen pauseMenuScreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.instance.CurrentState == GameManager.GameState.Playing)
            {
                GameManager.instance.PauseGame();
                pauseMenuScreen.Show();
            }
            
            else if (GameManager.instance.CurrentState == GameManager.GameState.Paused)
            {
                GameManager.instance.ResumeGame();
                pauseMenuScreen.Hide();
            }
        }
    }
}