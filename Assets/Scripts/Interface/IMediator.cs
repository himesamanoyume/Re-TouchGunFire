using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMediator : MonoBehaviour
{
    private string m_name = "IMediator";
    public string Name{
        get{ return m_name;}
        set{ m_name = value;}
    }

    public abstract void Init();
}
