using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Token : MonoBehaviour
{
  SpriteRenderer spriteRenderer;
  private Sprite face = null;
  private Sprite back;

  private int _tokenIndex;
  public int tokenIndex
  {
    get { return _tokenIndex;}
    set
    {
      _tokenIndex = value;
      face = faces[_tokenIndex];
    }
  }
  public bool open = false;
  public bool active = true;

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
    if (!active) return;

    if (!face)
    {
      face = faces[tokenIndex];
    }

    if (!open)
    {
      Open();
    }
    else
    {
      Close();
      tokenManger.CloseFirstCard();
    }
  }

  public void Open()
  {
    open = true; // TODO: add actions on change open, that would be easier than that 
    spriteRenderer.sprite = face;
    if (!active) return;
    tokenManger.OpenCard(this);
  }

  public void Close()
  {
    open = false;
    spriteRenderer.sprite = back;
  }
}
