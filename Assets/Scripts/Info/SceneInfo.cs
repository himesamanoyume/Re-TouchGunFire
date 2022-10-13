using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInfo : IInfo
{
    protected SceneMgr m_sceneMgr = null;
    public SceneInfo(SceneMgr sceneMgr){
        m_sceneMgr = sceneMgr;
    }

    public virtual void OnBegin(){

    }
    public virtual void OnUpdate(){

    }
    public virtual void OnEnd(){

    }
}
