using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneInfo : IInfo
{
    protected SceneMediation m_sceneMediation = null;
    public SceneInfo(SceneMediation sceneMediation){
        m_sceneMediation = sceneMediation;
    }

    public abstract void OnBegin();
    public abstract void OnUpdate();
    public abstract void OnEnd();
}
