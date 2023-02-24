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
        DisableSelected();
        Discard();
        GameManager.instance.levelManager.AddMatch();
      }
      else
      {
        StartCoroutine(Miss());
      }
    }
  }

  private IEnumerator Miss()
  {
    Debug.Log("Miss :(");
    yield return new WaitForSeconds(0.5f);
    CloseCards();
    GameManager.instance.levelManager.Miss();

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
    Discard();
  }

  public void DisableSelected()
  {
    secondToken.active = firstToken.active = false;
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
