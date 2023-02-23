using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Token : MonoBehaviour
{
  SpriteRenderer spriteRenderer;
  private Sprite face = null;
  private Sprite back;
  public int tokenIndex;
  public bool open = false;
  public bool enable = true;

  private List<Sprite> faces;

  TokenManger tokenManger;

  private void Awake()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();

    tokenManger = GameManager.instance.tokenManger;
    back = tokenManger.back;
    faces = tokenManger.faces;
  }

  public void OnMouseDown()
  {
    if (!enable) return;

    if (!face)
    {
      face = faces[tokenIndex];
    }

    if (!open)
    {
      OpenCard();
    }
    else
    {
      CloseCard();
      tokenManger.CloseFirstCard();
    }
  }

  public void OpenCard()
  {
    open = true;
    spriteRenderer.sprite = face;
    tokenManger.OpenCard(this);
  }

  public void CloseCard()
  {
    open = false;
    spriteRenderer.sprite = back;
  }
}
