using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IObject : IBase
{
    public virtual void Awake(){
        // objectMgr = GameLoop.Instance.gameManager.ObjectMgr;
    }
    
}
