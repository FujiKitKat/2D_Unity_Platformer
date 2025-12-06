using System;
using UnityEngine;

public class MainMenuScreen : UIScreenBase
{
    private void Awake()
    {
        Show();
        AudioManager.instance.MainMenuSong();
    }

    public void OnStartButtonPressed()
    {
        GameManager.instance.StartGame();
        AudioManager.instance.StopMusic();
    }

    public void OnExitButtonPressed()
    {
        GameManager.instance.QuitGame();
    }
}
