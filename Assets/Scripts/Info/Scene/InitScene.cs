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

    public HotUpdateMediator hotUpdateMediator;
    public CanvasMediator canvasMediator;
    public PanelMediator panelMediator;
    

    public override void OnBegin()
    {
        // Debug.Log("InitScene Begin");
        canvasMediator = GameLoop.Instance.GetMediator<CanvasMediator>();

        panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
        panelMediator.PushPanel(EUIPanelType.InitPanel, EUILevel.Level2, true, (GameObject obj)=>{ 
            obj.AddComponent<InitPanelInfo>();
        });

        hotUpdateMediator = GameLoop.Instance.GetMediator<HotUpdateMediator>();
        hotUpdateMediator.StartCheck(sceneMediator);

    }

    public override void OnUpdate()
    {
        // Debug.Log("InitScene Update");
    }

    public override void OnEnd()
    {
        // Debug.Log("InitScene End");
        panelMediator.PopPanel(true);
    }
}
