using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReTouchGunFire.Mediators;

public sealed class InitScene : SceneInfo
{
    public InitScene(SceneMediator sceneMediator) : base(sceneMediator){
        Name = "InitScene";
    }

    public HotUpdateMediator m_hotUpdateMediator;
    public CanvasMediator m_canvasMediator;
    

    public override void OnBegin()
    {
        Debug.Log("InitScene Begin");

        if(GameLoop.Instance.TryGetComponent<CanvasMediator>(out CanvasMediator canvasMediator)){
            m_canvasMediator = canvasMediator;
        }else{
            Debug.LogWarning("未拿到对应组件");
        }

        m_canvasMediator.InitCanvas();

        
        GameLoop.Instance.GetComponent<PanelMediator>().SpawnPanel(EUIPanelType.InitPanel, EUILevel.Level2);
        

        if(GameLoop.Instance.TryGetComponent<HotUpdateMediator>(out HotUpdateMediator hotUpdateMediator)){
            m_hotUpdateMediator = hotUpdateMediator;
        }else{
            Debug.LogWarning("未拿到对应组件");
        }

        m_hotUpdateMediator.StartCheck(m_sceneMediator);
        
    }

    public override void OnUpdate()
    {
        Debug.Log("InitScene Update");
    }

    public override void OnEnd()
    {
        Debug.Log("InitScene End");
        m_canvasMediator.m_uiMgr.PopPanel();
    }
}
