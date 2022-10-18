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

    public override void OnBegin()
    {
        Debug.Log("MainScene Begin");
        GameLoop.Instance.GetComponent<PanelMediator>().SpawnPanel(EUIPanelType.TestPanel, EUILevel.Level2);
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
