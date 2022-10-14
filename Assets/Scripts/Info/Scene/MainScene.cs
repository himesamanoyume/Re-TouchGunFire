using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MainScene : SceneInfo
{
    public MainScene(SceneMediation sceneMediation) : base(sceneMediation){
        Name = "MainScene";
    }

    public override void OnBegin()
    {
        Debug.Log("Main Begin");
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnEnd()
    {
        Debug.Log("Main End");
    }
}
