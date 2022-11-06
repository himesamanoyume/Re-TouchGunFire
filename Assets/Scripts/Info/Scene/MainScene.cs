using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ReTouchGunFire.Mediators;
using ReTouchGunFire.PanelInfo;

public sealed class MainScene : SceneInfo
{
    public MainScene(SceneMediator sceneMediator) : base(sceneMediator){
        Name = "MainScene";
    }

    public PanelMediator panelMediator;

    public override void OnBegin()
    {
        // Debug.Log("MainScene Begin");
        panelMediator = GameLoop.Instance.GetComponent<PanelMediator>();
        SetDefaultPanelLevel();
        
        EventMgr.Broadcast(GameEvents.CloseBackButtonPanelNotify);
        EventMgr.Broadcast(GameEvents.CloseLoadingPanelNotify);
    }

    void SetDefaultPanelLevel(){
        panelMediator.PushPanel(EUIPanelType.MainInfoPanel, EUILevel.Level1, false, (GameObject obj)=>{
            obj.AddComponent<MainInfoPanelInfo>().currentLevel = EUILevel.Level1;
        });
        panelMediator.PushPanel(EUIPanelType.BackButtonPanel, EUILevel.LevelBackButton, false, (GameObject obj)=>{
            obj.AddComponent<BackButtonPanelInfo>().currentLevel = EUILevel.LevelBackButton;
        });

        panelMediator.PushPanel(EUIPanelType.MainMenuPanel, EUILevel.Level1, false, (GameObject obj)=>{
            obj.AddComponent<MainMenuPanelInfo>().currentLevel = EUILevel.Level1;
        });
        panelMediator.PushPanel(EUIPanelType.PlayerPropsPanel, EUILevel.Level3, false, (GameObject obj)=>{
            obj.AddComponent<PlayerPropsPanelInfo>().currentLevel = EUILevel.Level4;
        });
        panelMediator.PushPanel(EUIPanelType.PlayerInfoPanel, EUILevel.Level1, false, (GameObject obj)=>{
            obj.AddComponent<PlayerInfoPanelInfo>().currentLevel = EUILevel.Level1;
        });
        panelMediator.PushPanel(EUIPanelType.BattleGunInfoPanel,EUILevel.Level1, false, (GameObject obj)=>{
            obj.AddComponent<BattleGunInfoPanelInfo>().currentLevel = EUILevel.Level1;
        });
        panelMediator.PushPanel(EUIPanelType.BattleLittleMenuPanel,EUILevel.Level3, false, (GameObject obj)=>{
            obj.AddComponent<BattleLittleMenuPanelInfo>().currentLevel = EUILevel.Level3;
        });
        panelMediator.PushPanel(EUIPanelType.PlayerCurrentStatePanel,EUILevel.Level1, false, (GameObject obj)=>{
            obj.AddComponent<PlayerCurrentStatePanelInfo>().currentLevel = EUILevel.Level1;
        });
        

        EventMgr.Broadcast(GameEvents.HideBattleLittleMenuPanelNotify);
    }

    public override void OnUpdate()
    {
        // Debug.Log("MainScene Update");
    }

    public override void OnEnd()
    {
        // Debug.Log("MainScene End");
    }
}
