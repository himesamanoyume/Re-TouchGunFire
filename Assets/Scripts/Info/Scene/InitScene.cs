using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class InitScene : SceneInfo
{
    public InitScene(SceneMediation sceneMediation) : base(sceneMediation){
        Name = "InitScene";
    }

    public HotUpdateMediation m_hotUpdateMediation = null;

    public override void OnBegin()
    {
        Debug.Log("InitScene Begin");
        if(GameLoop.Instance.TryGetComponent<HotUpdateMediation>(out HotUpdateMediation hotUpdateMediation)){
            m_hotUpdateMediation = hotUpdateMediation;
        }else{
            Debug.LogWarning("未拿到对应组件");
        }
        m_hotUpdateMediation.StartCheck(m_sceneMediation);
    }

    public override void OnUpdate()
    {
        Debug.Log("InitScene Update");
    }

    public override void OnEnd()
    {
        Debug.Log("InitScene End");
    }
}
