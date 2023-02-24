using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
  public TMP_Text livesText;
  void Start()
  {
    GameManager.instance.levelManager.updateLives += UpdateText;
  }

  void UpdateText(int newLives)
  {
    livesText.text = newLives.ToString();
  }
}
