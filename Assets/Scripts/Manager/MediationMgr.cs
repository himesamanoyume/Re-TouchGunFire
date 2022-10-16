using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MediationMgr : IManager
{
    public MediationMgr(){
        Name = "MediationMgr";
    }

    public override void Init(){
        
    }

    public delegate void initDel();
    public initDel m_initDel = null;

    public void InitDelMediation(){
        m_initDel();
    }

    public void InitLuaMediation(){
        GameLoop.Instance.gameObject.AddComponent<LuaMediation>().Init();
    }
 
    public void InitCanvasMediation(){
        GameLoop.Instance.gameObject.AddComponent<CanvasMediation>().Init();
    }

    public void InitAbMediation(){
        GameLoop.Instance.gameObject.AddComponent<AbMediation>().Init();
    }

    public void InitNetworkMediation(){
        GameLoop.Instance.gameObject.AddComponent<NetworkMediation>().Init();
    }

    public void InitSceneMediation(){
        GameLoop.Instance.gameObject.AddComponent<SceneMediation>().Init();
    }

    public void InitHotUpdateMediation(){
        GameLoop.Instance.gameObject.AddComponent<HotUpdateMediation>().Init();
    }

    public void InitPanelMediation(){
        GameLoop.Instance.gameObject.AddComponent<PanelMediation>().Init();
    }
}
