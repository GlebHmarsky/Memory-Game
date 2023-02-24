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
    ClearTokens();
    for (int i = 0; i < tokenPairCount; i++)
    {
      CreateTokenPair(i);
    }
    Utils.Shuffle(tokens);
  }

  void ClearTokens()
  {
    Debug.Log(tokens.Count);
    foreach (var token in tokens)
    {
      Destroy(token.gameObject);
    }
    tokens.Clear();
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
