using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TokenCreateManager))]
public class LevelManager : MonoBehaviour
{
  int level = 1;
  private TokenCreateManager tokenCreateManager;

  private void Start()
  {
    tokenCreateManager = GameManager.instance.tokenCreateManager;
    UpdateLevel();
  }

  void UpdateLevel()
  {
    float duration = 1;
    switch (level)
    {
      case 1:
        {
          tokenCreateManager.CreateTokenList(1);
          Grid.PlaceByGrid(tokenCreateManager.tokens, 1, 2, 3);
          duration = 1;
        }
        break;
      case 2:
        {
          tokenCreateManager.CreateTokenList(2);
          Grid.PlaceByGrid(tokenCreateManager.tokens, 2, 2, 3);
          duration = 2;
        }
        break;
      default:
      case 3:
        {
          tokenCreateManager.CreateTokenList(3);
          Grid.PlaceByGrid(tokenCreateManager.tokens, 2, 3, 3);
          duration = 3;
        }
        break;
    }
    StartCoroutine(FlipCards(duration));
  }

  private IEnumerator FlipCards(float duration)
  {
    yield return new WaitForSeconds(0.5f);
    SetActive(false);
    OpenCards();
    yield return new WaitForSeconds(duration);
    CloseCards();
    SetActive(true);

  }

  void OpenCards()
  {
    foreach (var token in tokenCreateManager.tokens)
    {
      token.Open();
    }
  }

  void CloseCards()
  {
    foreach (var token in tokenCreateManager.tokens)
    {
      token.Close();
    }
  }

  void SetActive(bool active)
  {
    foreach (var token in tokenCreateManager.tokens)
    {
      token.active = active;
    }
  }

}
