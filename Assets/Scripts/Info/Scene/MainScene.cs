using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public sealed class MainScene : SceneInfo
{
    public MainScene(SceneMediation sceneMediation) : base(sceneMediation){
        Name = "MainScene";
    }

    public override void OnBegin()
    {
        Debug.Log("MainScene Begin");
        
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
