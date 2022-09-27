using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
   public void Restart() {
       Scene scene = SceneManager.GetActiveScene(); 
       SceneManager.LoadScene(scene.name);
       Time.timeScale = 1;
   }

   public void PlayHoverSound() {
        AudioManager.GetInstance().PlayMenuItemHover();
   }

   public void GoToMainMenu() {
      SceneManager.LoadScene(0);
   }
}
