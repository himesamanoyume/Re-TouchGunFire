using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "UIInfo/New UIInfo")]
public abstract class UIInfo : MonoBehaviour//: ScriptableObject
{
    private string m_name = "UIInfo";
    public string Name{
        get{ return m_name;}
        set{ m_name = value;}
    }

    public virtual void Init(){
        if(Name.Contains("UIInfo")) 
            Debug.LogWarning(this.gameObject.name + " Info name not set.");
    }
}
