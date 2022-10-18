using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ReTouchGunFire.Mediators;

public sealed class MainScene : SceneInfo
{
    public MainScene(SceneMediator sceneMediator) : base(sceneMediator){
        Name = "MainScene";
    }

    public PanelMediator m_panelMediator;

    public override void OnBegin()
    {
        Debug.Log("MainScene Begin");
        m_panelMediator = GameLoop.Instance.GetComponent<PanelMediator>();
        m_panelMediator.SpawnPanel(EUIPanelType.TestPanel, EUILevel.Level2);
        m_panelMediator.SpawnPanel(EUIPanelType.MainInfoPanel, EUILevel.Level4);
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
