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

    public PanelMediator m_panelMediator;

    public override void OnBegin()
    {
        // Debug.Log("MainScene Begin");
        m_panelMediator = GameLoop.Instance.GetComponent<PanelMediator>();
        m_panelMediator.SpawnPanelAndPush(EUIPanelType.TestPanel, EUILevel.Level2, (GameObject obj)=>{});
        m_panelMediator.SpawnPanelWithoutPush(EUIPanelType.MainInfoPanel, EUILevel.Level1, (GameObject obj)=>{
            obj.AddComponent<MainInfoPanelInfo>();
        });
        m_panelMediator.SpawnBackButtonPanel();
        m_panelMediator.SpawnPanelWithoutPush(EUIPanelType.MainMenuPanel, EUILevel.Level1, (GameObject obj)=>{
            obj.AddComponent<MainMenuPanelInfo>();
        });
        m_panelMediator.SpawnPanelWithoutPush(EUIPanelType.PlayerPropsPanel, EUILevel.Level3, (GameObject obj)=>{
            obj.AddComponent<PlayerPropsPanelInfo>();
        });
        m_panelMediator.SpawnPanelWithoutPush(EUIPanelType.PlayerInfoPanel, EUILevel.Level1, (GameObject obj)=>{
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
