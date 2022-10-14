using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : UnitySingleton<GameLoop>
{
    private MediationMgr m_mediationMgr = null;
    private SceneMediation m_sceneMediation = null;

    public override void Awake()
    {
        base.Awake();

        //游戏初始化
        m_mediationMgr = GameManager.Instance.MediationMgr;
        //end
    }

    void Start()
    {
        
        m_sceneMediation = new SceneMediation(m_mediationMgr);
        m_sceneMediation.SetScene(new InitScene(m_sceneMediation), "");
        

    }

    void Update()
    {
        m_sceneMediation.SceneUpdate();
    }
}
