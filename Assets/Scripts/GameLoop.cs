using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : UnitySingleton<GameLoop>
{
    private MediationMgr m_mediationMgr = null;
    private SceneMediation m_sceneMediation = null;

    void Start()
    {
        m_mediationMgr = GameManager.Instance.MediationMgr;
        m_sceneMediation = new SceneMediation();
        m_sceneMediation.SetScene(new InitScene(m_sceneMediation), "");

    }

    void Update()
    {
        m_sceneMediation.SceneUpdate();
    }
}
