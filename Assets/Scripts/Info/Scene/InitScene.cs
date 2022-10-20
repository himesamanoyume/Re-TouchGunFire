using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReTouchGunFire.Mediators;
using ReTouchGunFire.PanelInfo;

public sealed class InitScene : SceneInfo
{
    public InitScene(SceneMediator sceneMediator) : base(sceneMediator){
        Name = "InitScene";
    }

    public HotUpdateMediator m_hotUpdateMediator;
    public CanvasMediator m_canvasMediator;
    public PanelMediator m_panelMediator;
    

    public override void OnBegin()
    {
        // Debug.Log("InitScene Begin");

        m_canvasMediator = GameLoop.Instance.GetMediator<CanvasMediator>();

        m_panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
        m_panelMediator.SpawnPanel(EUIPanelType.InitPanel, EUILevel.Level2, (GameObject obj)=>{ 
            obj.AddComponent<InitPanelInfo>();
        });

        m_hotUpdateMediator = GameLoop.Instance.GetMediator<HotUpdateMediator>();
        m_hotUpdateMediator.StartCheck(m_sceneMediator);

    }

    public override void OnUpdate()
    {
        // Debug.Log("InitScene Update");
    }

    public override void OnEnd()
    {
        // Debug.Log("InitScene End");
        m_panelMediator.PopPanel();
    }
}
