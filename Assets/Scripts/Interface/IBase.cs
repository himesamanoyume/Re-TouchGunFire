using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IBase
{
    private string m_name = "IBase";
    public string Name{
        get{ return m_name;}
        set{ m_name = value;}
    }
}
