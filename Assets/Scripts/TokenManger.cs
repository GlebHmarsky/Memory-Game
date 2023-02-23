using System.Collections.Generic;
using UnityEngine;

public class TokenManger : MonoBehaviour
{
  public Sprite back;
  public List<Sprite> faces = new List<Sprite>();

  public Token firstToken = null;
  public Token secondToken = null;

  public void OpenCard(Token token)
  {
    if (!firstToken)
    {
      firstToken = token;
    }
    else
    {
      secondToken = token;
      if (CheckTokens())
      {
        Debug.Log("Match!");
        DisableCards();
        Discard();
      }
      else
      {
        Debug.Log("Miss :(");
        CloseCards();
      }
    }
  }

  public void CloseFirstCard()
  {
    firstToken.CloseCard();
    firstToken = null;
  }

  public void CloseCards()
  {
    firstToken.CloseCard();
    secondToken.CloseCard();
    Discard();
  }

  public void DisableCards()
  {
    secondToken.enable = firstToken.enable = false;
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
