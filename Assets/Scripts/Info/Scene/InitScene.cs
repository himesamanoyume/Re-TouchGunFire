using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class InitScene : SceneInfo
{
    public InitScene(SceneMediation sceneMediation) : base(sceneMediation){
        Name = "InitScene";
    }

    // public float coldDown = 2f;
    // private float m_coldDown = 2f;

    public override void OnBegin()
    {
        Debug.Log("Init Begin");
        m_sceneMediation.RunEnumerator(StartInit());
        // m_coldDown = coldDown;
    }

    public override void OnUpdate()
    {

        // m_coldDown -= Time.deltaTime;
        // if(m_coldDown<=0){
        //     MainScene mainScene = new MainScene(m_sceneMediation);
        //     m_sceneMediation.SetScene(mainScene,mainScene.Name);
        // }
        
    }

    public override void OnEnd()
    {
        Debug.Log("Init End");

        // m_coldDown = coldDown;
    }

    private IEnumerator StartInit(){
        yield return m_sceneMediation.RunEnumerator(CheckHotUpdate());

        //
    }

    private IEnumerator CheckHotUpdate(){
        yield return 0;
    }
}
