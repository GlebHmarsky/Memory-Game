using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenCreateManager : MonoBehaviour
{
  public List<Token> tokens;
  public Token tokenPrefab;
  private System.Random rng = new System.Random();

  public void CreateTokenList(int tokenPairCount)
  {
    for (int i = 0; i < tokenPairCount; i++)
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
}
