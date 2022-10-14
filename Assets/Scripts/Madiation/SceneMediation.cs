using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMediation : IMediation
{
    private SceneMgr m_sceneMgr = null;
    private MediationMgr m_mediationMgr = null;
    public SceneMediation(){
        Name = "SceneMediation";
        m_sceneMgr = GameManager.Instance.SceneMgr;
        m_mediationMgr = GameManager.Instance.MediationMgr;
        m_mediationMgr.AddMediation(this);
    }

    private void OnDestroy() {
        m_mediationMgr.RemoveMediation(this);
    }

    public void SetScene(SceneInfo sceneInfo, string sceneName){
        m_sceneMgr.SetScene(sceneInfo, sceneName);
    }

    public void SceneUpdate(){
        m_sceneMgr.SceneUpdate();
    }

}
