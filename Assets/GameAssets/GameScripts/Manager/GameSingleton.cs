using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;
     
    public static T Instance { get { return instance; } }

    public virtual void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
    }

    public virtual void OnInit()
    {

    }

    public virtual void FetchData()
    {

    }
}
