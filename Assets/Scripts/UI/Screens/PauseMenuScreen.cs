using UnityEngine;

public class PauseMenuScreen : UIScreenBase
{
   private void Awake()
   {
      Hide();
   }

   public void OnResumeButtonPresssed()
   {
      GameManager.instance.PauseGame();
      Hide();
   }

   public void OnRestartButtonPresssed()
   {
      GameManager.instance.ReloadGame();
      Hide();
   }

   public void OnMainMenuButtonPresssed()
   {
      GameManager.instance.ReturnToMainMenu();
   }
}
