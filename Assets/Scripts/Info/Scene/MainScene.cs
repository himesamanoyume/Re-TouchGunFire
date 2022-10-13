using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : SceneInfo
{
    public MainScene(SceneMgr sceneMgr):base(sceneMgr){
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
