using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonMonoBehaviour : MonoBehaviour
{

}

public abstract class SingletonMonoBehaviour<T> : SingletonMonoBehaviour where T : MonoBehaviour
{
  private static bool _applicationIsQuitting = false;
  private static T _instance;

  public static T Instance
  {
    get
    {
      if (_applicationIsQuitting) return null;

      if (_instance == null)
      {
        _instance = FindObjectOfType<T>();

        if (_instance == null)
        {
          GameObject gameObject = new GameObject($"{typeof(T)}");
          _instance = gameObject.AddComponent<T>();
          DontDestroyOnLoad(gameObject);
        }
      }

      return _instance;
    }
  }

  protected virtual void Awake()
  {
    if (_instance != null)
    {
      Destroy(gameObject);
      return;
    }

    _instance = this as T;
    DontDestroyOnLoad(gameObject);
  }

  protected virtual void OnApplicationQuit()
  {
    _instance = null;
    _applicationIsQuitting = true;
  }
}