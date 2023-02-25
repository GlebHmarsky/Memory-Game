using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesUI : MonoBehaviour
{
  public TMP_Text lifesText;
  public List<Image> hearts;

  public Sprite heartFilled;
  public Sprite heartOutlined;

  void Start()
  {
    GameManager.instance.levelManager.updateLifes += UpdateText;
  }

  void UpdateText(int newLifes)
  {
    var len = hearts.Count;
    for (int i = 0; i < len - newLifes; i++)
    {
      hearts[i].sprite = heartOutlined;
    }
  }
}
