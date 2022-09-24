using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IBase
{
    public virtual void OnBegin(){

    }
    public virtual void OnUpdate(){

    }
    public virtual void OnEnd(){

    }

    private string m_name = "IBase";
    public string Name{
        get{ return m_name;}
        set{ m_name = value;}
    }
}
