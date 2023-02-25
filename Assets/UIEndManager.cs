using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIEndManager : MonoBehaviour
{
  public TMP_Text time;
  public TMP_Text matchCount;

  void Start()
  {
    if (!GameManager.instance) return;

    var timer = (int)GameManager.instance.levelManager.time;
    int minutes = timer / 60;
    int seconds = timer % 60;

    time.text = $"{minutes.ToString("00")}:{seconds.ToString("00")}";
    matchCount.text = GameManager.instance.levelManager.globalMatchCount.ToString();
  }
}
