using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IObject : IBase
{
    protected ObjectMgr m_objectMgr;
    public virtual void Awake(){
        m_objectMgr = GameManager.Instance.ObjectMgr;
    }
    
}
