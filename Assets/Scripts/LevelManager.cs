using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(TokenCreateManager))]
public class LevelManager : MonoBehaviour
{
  int level = 3;
  private int pairCount;
  private int matchCount;
  public int lifes = 5;
  public event Action<int> updateLifes;
  private TokenCreateManager tokenCreateManager;

  private void Start()
  {
    tokenCreateManager = GameManager.instance.tokenCreateManager;
    UpdateLevel();
  }

  public void AddMatch()
  {
    matchCount++;

    if (matchCount == pairCount)
    {
      StartCoroutine(LevelUp());
    }
  }

  IEnumerator LevelUp()
  {
    yield return new WaitForSeconds(0.6f);
    matchCount = 0;
    level++;
    UpdateLevel();
  }

  public void Miss()
  {
    lifes--;
    updateLifes.Invoke(lifes);
    if (lifes == 0)
    {
      OnLifesEnd();
    }
  }

  void OnLifesEnd()
  {
    SetActive(false);

  }

  void UpdateLevel()
  {

    Utils.Shuffle(GameManager.instance.tokenManger.faces);

    float duration = 1;
    switch (level)
    {
      case 1:
        {
          pairCount = 2;
          tokenCreateManager.CreateTokenList(pairCount);
          Grid.PlaceByGrid(tokenCreateManager.tokens, 2, 2, 3);
          duration = 1.5f;
        }
        break;
      case 2:
        {
          pairCount = 3;
          tokenCreateManager.CreateTokenList(pairCount);
          Grid.PlaceByGrid(tokenCreateManager.tokens, 2, 3, 3);
          duration = 3;
        }
        break;
      case 3:
        {
          pairCount = 5;
          tokenCreateManager.CreateTokenList(pairCount);
          Grid.PlaceByGrid(tokenCreateManager.tokens, 2, 5, 2.3f);
          duration = 4;
        }
        break;
      case 4:
        {
          pairCount = 6;
          tokenCreateManager.CreateTokenList(pairCount);
          Grid.PlaceByGrid(tokenCreateManager.tokens, 3, 4, 2);
          duration = 5;
        }
        break;
      case 5:
      default:
        {
          pairCount = 8;
          tokenCreateManager.CreateTokenList(pairCount);
          Grid.PlaceByGrid(tokenCreateManager.tokens, 4, 4, 1.8f);
          duration = 7;
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
