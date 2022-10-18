using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReTouchGunFire.Mediators;

public abstract class SceneInfo : IInfo
{
    protected SceneMediator m_sceneMediator;
    public SceneInfo(SceneMediator sceneMediator){
        m_sceneMediator = sceneMediator;
    }

    public abstract void OnBegin();
    public abstract void OnUpdate();
    public abstract void OnEnd();
}
