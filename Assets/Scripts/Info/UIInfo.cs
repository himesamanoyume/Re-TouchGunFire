using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "UIInfo/New UIInfo")]
public abstract class UIInfo : MonoBehaviour//: ScriptableObject
{
    private string m_name = "IBase";
    public string Name{
        get{ return m_name;}
        set{ m_name = value;}
    }

    public abstract void Init();
}
