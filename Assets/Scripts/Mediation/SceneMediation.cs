using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMediation : IMediation
{
    public SceneMgr m_sceneMgr = null;
    
    public SceneMediation(){
        Name = "SceneMediation";
    }

    public override void Init()
    {
        m_sceneMgr = GameLoop.Instance.gameManager.SceneMgr;
    }

    public void SetScene(SceneInfo sceneInfo, string sceneName){
        m_sceneMgr.SetScene(sceneInfo, sceneName);
    }

    public void SceneUpdate(){
        m_sceneMgr.SceneUpdate();
    }

    public IEnumerator RunEnumerator(IEnumerator enumerator){
        Debug.Log("SceneMediation RunEnumerator");
        yield return StartCoroutine(enumerator);
    }

    public void SceneLog(){
        m_sceneMgr.SceneLog();
    }

}
