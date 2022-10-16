using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMediation : IMediation
{
    public SceneMgr m_sceneMgr = null;
    public AbMediation m_abMediation = null;
    
    public SceneMediation(){
        Name = "SceneMediation";
    }

    public override void Init()
    {
        m_sceneMgr = GameLoop.Instance.gameManager.SceneMgr;
        if(GameLoop.Instance.TryGetComponent<AbMediation>(out AbMediation abMediation)){
            m_abMediation = abMediation;
        }
    }

    public void SetScene(SceneInfo sceneInfo, string sceneName){
        m_sceneMgr.SetScene(sceneInfo, sceneName);
    }

    public void SceneUpdate(){
        m_sceneMgr.SceneUpdate();
    }

    public void LoadScene(string sceneName){
        // m_abMediation.SyncLoadABScene("scenes",sceneName);//同步加载场景测试
        StartCoroutine(m_abMediation.AsyncLoadAbScene("scenes",sceneName));
    }

    public void SceneLog(){
        m_sceneMgr.SceneLog();
    }

}
