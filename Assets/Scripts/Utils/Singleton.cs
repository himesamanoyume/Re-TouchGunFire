using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> where T : new()
{
    private static T m_instance;
    private static object mutex = new object();
    public static T Instance{
        get{
            if(m_instance == null){
                lock(mutex){
                    if(m_instance == null){
                        m_instance = new T();
                    }
                }
            }
            return m_instance;
        }
    }
}

public class UnitySingleton<T> : MonoBehaviour where T : Component{
    private static T m_instance = null;
    public static T Instance{
        get{
            if(m_instance == null){
                m_instance = FindObjectOfType(typeof(T)) as T;
                if(m_instance == null){
                    GameObject obj = new GameObject();
                    m_instance = (T)obj.AddComponent(typeof(T));
                    obj.hideFlags = HideFlags.DontSave;
                    obj.name = typeof(T).Name;
                }
            }
            return m_instance;
        }
    }

    public virtual void Awake() {
        DontDestroyOnLoad(gameObject);
        if(m_instance == null){
            m_instance = this as T;
        }else{
            Destroy(this.gameObject);
        }
    }
}

