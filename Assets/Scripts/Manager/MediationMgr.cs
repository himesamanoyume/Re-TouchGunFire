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

    // private Dictionary<string,IMediation> mediationList = new Dictionary<string,IMediation>();

    // public void AddMediation(IMediation mediation){
    //     mediationList.Add(mediation.Name,mediation);
    // }

    // public void RemoveMediation(IMediation mediation){
    //     mediationList.Remove(mediation.Name);
    // }

    // public IMediation GetMediation(string mediationName){
    //     if(mediationList.TryGetValue(mediationName, out IMediation mediationValue)){
    //         return mediationValue;
    //     }
    //     return null;
    // }

    public void InitDelMediation(){
        m_initDel();
    }

    public void InitLuaMediation(){
        GameLoop.Instance.gameObject.AddComponent<LuaMediation>();
        // AddMediation(GameLoop.Instance.GetComponent<LuaMediation>());
    }
 
    public void InitCanvasMediation(){
        GameLoop.Instance.gameObject.AddComponent<CanvasMediation>();
        // AddMediation(GameLoop.Instance.GetComponent<CanvasMediation>());
    }

    public void InitAbMediation(){
        GameLoop.Instance.gameObject.AddComponent<AbMediation>();
        // AddMediation(GameLoop.Instance.GetComponent<AbMediation>());
    }

    public void InitNetworkMediation(){
        GameLoop.Instance.gameObject.AddComponent<NetworkMediation>();
        // AddMediation(GameLoop.Instance.GetComponent<NetworkMediation>());
    }

    public void InitSceneMediation(){
        GameLoop.Instance.gameObject.AddComponent<SceneMediation>();
        // AddMediation(GameLoop.Instance.GetComponent<SceneMediation>());
    }

    public void InitHotUpdateMediation(){
        GameLoop.Instance.gameObject.AddComponent<HotUpdateMediation>();
    }
}
