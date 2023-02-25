using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void StartGame()
  {
    Debug.Log("hello");
    SceneManager.LoadScene("MainGameScene");
  }

  public void ExitGame()
  {
    Application.Quit();
  }
}
