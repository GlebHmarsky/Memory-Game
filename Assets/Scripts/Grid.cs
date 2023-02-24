using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
  public static void PlaceByGrid(List<Token> list, int rows, int cols, float tokenSize)
  {
    for (int i = 0, row = 0; row < rows; row++)
    {
      for (int col = 0; col < cols; col++, i++)
      {
        float posX = col * tokenSize;
        float posY = row * -tokenSize;

        list[i].transform.position = new Vector2(posX, posY);
      }
    }
  }
}
