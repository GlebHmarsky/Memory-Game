using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenCreateManager : MonoBehaviour
{
  public int length = 3;
  public List<Token> tokens;
  public Token tokenPrefab;
  private System.Random rng = new System.Random();

  private void Start()
  {
    CreateTokenList();
    Replace();
  }

  void CreateTokenList()
  {
    for (int i = 0; i < length; i++)
    {
      CreateTokenPair(i);
    }
    Shuffle(tokens);
  }


  public void Shuffle(List<Token> list)
  {
    int n = list.Count;
    while (n > 1)
    {
      n--;
      int k = rng.Next(n + 1);
      var value = list[k];
      list[k] = list[n];
      list[n] = value;
    }
  }

  void CreateTokenPair(int index)
  {
    Token token;

    token = Instantiate(tokenPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    token.tokenIndex = index;
    tokens.Add(token);

    token = Instantiate(tokenPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    token.tokenIndex = index;
    tokens.Add(token);
  }

  void Replace()
  {
    int xCounter = 0;
    int yCounter = 0;
    float xStart = -4.2f;
    float yStart = 2.2f;
    float xOffset = 4f;
    float yOffset = -4f;
    foreach (var token in tokens)
    {
      var vec = new Vector3(xStart + (xCounter * xOffset), yStart + (yCounter * yOffset), 0);
      token.gameObject.transform.position = vec;
      xCounter++;
      if (xCounter % length == 0)
      {
        xCounter = 0;
        yCounter++;
      }
    }
  }

}
