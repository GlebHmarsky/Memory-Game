using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class TokenManger : MonoBehaviour
{
  public Sprite back;
  public List<Sprite> faces = new List<Sprite>();

  public Token firstToken = null;
  public Token secondToken = null;

  public void OpenCard(Token token)
  {
    GameManager.instance.levelManager.tapSound.Play();
    if (!firstToken)
    {
      firstToken = token;
    }
    else
    {
      secondToken = token;

      if (CheckTokens())
      {
        DisableSelected();
        Discard();
        GameManager.instance.levelManager.AddMatch();
      }
      else
      {
        Token[] arr = { firstToken, secondToken };
        Discard();

        StartCoroutine(Miss(arr));
      }
    }
  }

  private IEnumerator Miss(Token[] list)
  {
    SetActive(list, false);
    yield return new WaitForSeconds(0.5f);
    CloseCards(list);
    GameManager.instance.levelManager.Miss();
    SetActive(list, true);

  }


  public void CloseFirstCard()
  {
    firstToken.Close();
    firstToken = null;
  }

  public void CloseCards()
  {
    firstToken.Close();
    secondToken.Close();
  }
  public void CloseCards(Token[] list)
  {
    foreach (var token in list)
    {
      token.Close();
    }
  }

  public void DisableSelected()
  {
    secondToken.active = firstToken.active = false;
  }

  public void SetActive(Token[] list, bool active)
  {
    foreach (var token in list)
    {
      token.active = active;
    }
  }


  public void Discard()
  {
    firstToken = null;
    secondToken = null;
  }

  public bool CheckTokens()
  {
    return firstToken.tokenIndex == secondToken.tokenIndex;
  }


}
