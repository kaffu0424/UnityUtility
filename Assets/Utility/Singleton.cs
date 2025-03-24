using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));

                if(instance == null)
                {
                    GameObject newInstance = new GameObject(typeof(T).Name, typeof(T));
                    instance = newInstance.GetComponent<T>();
                }
            }

            return instance;
        }
    }

    public void Awake()
    {
        InitManager();
    }

    protected abstract void InitManager(); 
}
