using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
  public static void PlaceByGrid(List<Token> list, int rows, int cols, float tokenSize)
  {
    float width = tokenSize * (cols - 1);
    float height = tokenSize * (rows - 1);

    for (int i = 0, row = 0; row < rows; row++)
    {
      for (int col = 0; col < cols; col++, i++)
      {
        float offset = 1.2f; //for the gap between cards
        float posX = col * (tokenSize * offset) - (width * offset / 2);
        float posY = row * -(tokenSize * offset) + (height * offset / 2);

        var tmp = list[i];
        tmp.transform.position = new Vector2(posX, posY);
        tmp.transform.localScale = new Vector3(tokenSize, tokenSize, tokenSize);
      }
    }
  }
}
