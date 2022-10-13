using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScene : SceneInfo
{
    public InitScene(SceneMgr sceneMgr) : base(sceneMgr){
        Name = "InitScene";
    }

    public float coldDown = 2f;
    private float m_coldDown = 2f;

    public override void OnBegin()
    {
        Debug.Log("Init Begin");
        m_coldDown = coldDown;
    }

    public override void OnUpdate()
    {
        m_coldDown -= Time.deltaTime;
        if(m_coldDown<=0){
            MainScene mainScene = new MainScene(m_sceneMgr);
            m_sceneMgr.SetScene(mainScene,mainScene.Name);
        }
        
    }

    public override void OnEnd()
    {
        Debug.Log("Init End");
        m_coldDown = coldDown;
    }
}
