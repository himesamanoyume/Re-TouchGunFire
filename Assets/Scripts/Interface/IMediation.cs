using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMediation : MonoBehaviour
{
    private string m_name = "IMediation";
    public string Name{
        get{ return m_name;}
        set{ m_name = value;}
    }
}
