using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesUI : MonoBehaviour
{
  public TMP_Text livesText;
  public List<Image> hearts;

  public Sprite heartFilled;
  public Sprite heartOutlined;

  void Start()
  {
    GameManager.instance.levelManager.updateLives += UpdateText;
  }

  void UpdateText(int newLives)
  {
    livesText.text = newLives.ToString();

    var len = hearts.Count;
    for (int i = 0; i < len - newLives; i++)
    {
      hearts[i].sprite = heartOutlined;
    }
  }
}
