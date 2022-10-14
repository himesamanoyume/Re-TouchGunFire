using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMediation : IMediation
{
    private SceneMgr m_sceneMgr = null;
    
    public SceneMediation(MediationMgr mediationMgr) : base(mediationMgr){
        Name = "SceneMediation";
        m_sceneMgr = GameManager.Instance.SceneMgr;
    }

    public void SetScene(SceneInfo sceneInfo, string sceneName){
        m_sceneMgr.SetScene(sceneInfo, sceneName);
    }

    public void SceneUpdate(){
        m_sceneMgr.SceneUpdate();
    }

    public IEnumerator RunEnumerator(IEnumerator enumerator){
        yield return StartCoroutine(enumerator);
    }

}
