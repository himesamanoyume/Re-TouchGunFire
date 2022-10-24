using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMediator : MonoBehaviour
{
    private string _name = "IMediator";
    public string Name{
        get{ return _name;}
        set{ _name = value;}
    }

    public abstract void Init();
}
