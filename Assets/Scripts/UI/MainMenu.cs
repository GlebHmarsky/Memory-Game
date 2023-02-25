using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void StartGame()
  {
    SceneManager.LoadScene("MainGameScene");
  }

  public void ExitGame()
  {
    Application.Quit();
  }

  public void ToMenu()
  {
    SceneManager.LoadScene("MenuScene");
  }
}
