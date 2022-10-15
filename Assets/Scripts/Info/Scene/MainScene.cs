using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public sealed class MainScene : SceneInfo
{
    public MainScene(SceneMediation sceneMediation) : base(sceneMediation){
        Name = "MainScene";
    }

    public AbMediation m_abMediation = null;

    public override void OnBegin()
    {
        Debug.Log("MainScene Begin");
        if(GameLoop.Instance.TryGetComponent<AbMediation>(out AbMediation abMediation)){
            m_abMediation = abMediation;
        }else{
            Debug.LogWarning("未拿到对应组件");
        }
        GameObject canvas = m_abMediation.SyncLoadABRes("prefabs", "Canvas");
        // Debug.Log(canvas.name);
        canvas.AddComponent<CanvasInfo>().InitCanvasChild();
        
    }

    public override void OnUpdate()
    {
        Debug.Log("MainScene Update");
    }

    public override void OnEnd()
    {
        Debug.Log("MainScene End");
    }
}
