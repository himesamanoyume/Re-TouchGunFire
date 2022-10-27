using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "UIInfo/New UIInfo")]
public abstract class UIInfo : MonoBehaviour//: ScriptableObject
{
    private string _name = "UIInfo";
    public string Name{
        get{ return _name;}
        set{ _name = value;}
    }

    public EUILevel currentLevel;

    protected virtual void Init(){
        if(Name.Contains("UIInfo")) 
            Debug.LogWarning(this.gameObject.name + " Info name not set.");
    }
}
