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
        // panelMediator.SpawnPanel(EUIPanelType.TestPanel, EUILevel.Level2, true, (GameObject obj)=>{});
        panelMediator.PushPanel(EUIPanelType.MainInfoPanel, EUILevel.Level1, false, (GameObject obj)=>{
            obj.AddComponent<MainInfoPanelInfo>();
        });
        // panelMediator.SpawnBackButtonPanel();
        panelMediator.PushPanel(EUIPanelType.BackButtonPanel, EUILevel.Level4, false, (GameObject obj)=>{
            obj.AddComponent<BackButtonPanelInfo>();
        });

        panelMediator.PushPanel(EUIPanelType.MainMenuPanel, EUILevel.Level1, false, (GameObject obj)=>{
            obj.AddComponent<MainMenuPanelInfo>();
        });
        panelMediator.PushPanel(EUIPanelType.PlayerPropsPanel, EUILevel.Level3, false, (GameObject obj)=>{
            obj.AddComponent<PlayerPropsPanelInfo>();
        });
        panelMediator.PushPanel(EUIPanelType.PlayerInfoPanel, EUILevel.Level1, false, (GameObject obj)=>{
            obj.AddComponent<PlayerInfoPanelInfo>();
        });

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
