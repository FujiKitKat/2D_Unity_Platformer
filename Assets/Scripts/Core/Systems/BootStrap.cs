using UnityEngine;
using UnityEngine.SceneManagement;

public class BootStrap : MonoBehaviour
{
    [SerializeField] private string menuSceneName = "MainMenu";

    private void Start()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
