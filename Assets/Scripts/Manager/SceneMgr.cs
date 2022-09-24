using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : IManager
{
    private SceneInfo m_sceneInfo;

    public SceneMgr(){
        this.Name = "SceneMgr";
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

        SceneManager.LoadScene(sceneName);

    }
}
