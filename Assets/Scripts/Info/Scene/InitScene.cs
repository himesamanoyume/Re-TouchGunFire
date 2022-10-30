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
        panelMediator.PushPanel(EUIPanelType.InitPanel, EUILevel.Level2, true,(GameObject obj)=>{ 
            obj.AddComponent<InitPanelInfo>().currentLevel = EUILevel.Level2;
        });
        panelMediator.PushPanel(EUIPanelType.LoadingPanel, EUILevel.LevelLoading, false, (GameObject obj)=>{
            obj.AddComponent<LoadingPanelInfo>().currentLevel = EUILevel.LevelLoading;
        });

        panelMediator.PushPanel(EUIPanelType.TwiceConfirmPanel,EUILevel.LevelTwiceConfirm, false, (GameObject obj)=>{
            obj.AddComponent<TwiceConfirmPanelInfo>().currentLevel = EUILevel.LevelTwiceConfirm;
        });

        hotUpdateMediator = GameLoop.Instance.GetMediator<HotUpdateMediator>();
        hotUpdateMediator.StartCheck(sceneMediator);

        EventMgr.AddListener<CheckHotUpdateEndNotify>(OnCheckHotUpdateEnd);

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

    void OnCheckHotUpdateEnd(CheckHotUpdateEndNotify evt) => CheckHotUpdateEnd();

    void CheckHotUpdateEnd(){
        panelMediator.PopPanel(true);
        panelMediator.PushPanel(EUIPanelType.LoginRegisterPanel, EUILevel.Level2, true, (GameObject obj)=>{
            obj.AddComponent<LoginRegisterPanelInfo>().currentLevel = EUILevel.Level2;
        });
    }
}
