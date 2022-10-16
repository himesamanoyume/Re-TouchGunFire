using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneMgr : IManager
{
    private SceneInfo m_sceneInfo;
    private bool isBegin = false;
    public SceneMediation m_sceneMediation = null;

    public SceneMgr(){
        Name = "SceneMgr";
    }

    public override void Init(){
        Debug.Log("SceneMgr Init start");
        if(GameLoop.Instance.TryGetComponent<SceneMediation>(out SceneMediation sceneMediation)){
            m_sceneMediation = sceneMediation;
        }
    }
    
    public void SetScene(SceneInfo sceneInfo, string sceneName){
        isBegin = false;
        LoadScene(sceneName);
        if(m_sceneInfo!=null){
            m_sceneInfo.OnEnd();
        }
        m_sceneInfo = sceneInfo;
    }

    public void SceneUpdate(){
        if(m_sceneInfo != null && isBegin == false){
            m_sceneInfo.OnBegin();
            isBegin = true;
        }
        
        if(m_sceneInfo != null){
            m_sceneInfo.OnUpdate();
        }
    }
        

    private void LoadScene(string sceneName){
        if(sceneName == null || sceneName.Length == 0){
            return;
        }
        m_sceneMediation.LoadScene(sceneName);
        // AssetBundle.UnloadAllAssetBundles(false);
    }

    public void SceneLog(){
        Debug.Log("SceneLog");
    }
}
