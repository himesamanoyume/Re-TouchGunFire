using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HotUpdateMediation : IMediation
{
    public SceneMediation m_sceneMediation = null;
    public HotUpdateMediation(){
        Name = "HotUpdateMediation";
    }

    public override void Init()
    {
        
    }

    public void StartCheck(SceneMediation sceneMediation){
        Debug.Log("HotUpdateMediation StartCheck");
        m_sceneMediation = sceneMediation;
        StartCoroutine(CheckHotUpdate());
    }

    public IEnumerator CheckHotUpdate(){
        Debug.Log("HotUpdateMediation CheckHotUpdate");
        yield return new WaitForSeconds(2);
        MainScene mainScene = new MainScene(m_sceneMediation);
        m_sceneMediation.SetScene(mainScene,mainScene.Name);
    }
}
