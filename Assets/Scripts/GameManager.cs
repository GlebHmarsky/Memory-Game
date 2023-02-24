using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;

  public TokenManger tokenManger;
  public TokenCreateManager tokenCreateManager;
  public LevelManager levelManager;

  void Awake()
  {

    if (instance != null && instance != this)
    {
      Destroy(this.gameObject);
    }
    else
    {
      instance = this;
    }

    DontDestroyOnLoad(this.gameObject);
  }

}
