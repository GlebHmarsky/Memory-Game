using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMusic : MonoBehaviour
{
  public static BackMusic instance;

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
