using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : UnitySingleton<GameLoop>
{
    private MediationMgr m_mediationMgr = null;
    private SceneMediation m_sceneMediation = null;
    public GameManager gameManager = null;

    public override void Awake()
    {
        base.Awake();
        gameManager = new GameManager();
        //游戏初始化
        m_mediationMgr = gameManager.MediationMgr;
        m_mediationMgr.m_initDel += m_mediationMgr.InitAbMediation;
        m_mediationMgr.m_initDel += m_mediationMgr.InitSceneMediation;
        m_mediationMgr.m_initDel += m_mediationMgr.InitHotUpdateMediation;
        m_mediationMgr.m_initDel += m_mediationMgr.InitCanvasMediation;
        m_mediationMgr.m_initDel += m_mediationMgr.InitLuaMediation;
        m_mediationMgr.m_initDel += m_mediationMgr.InitPanelMediation;
        m_mediationMgr.m_initDel += m_mediationMgr.InitNetworkMediation;

        m_mediationMgr.InitDelMediation();
        gameManager.Init();
        //end
    }

    void Start()
    {
        
        m_sceneMediation = gameObject.GetComponent<SceneMediation>();
        Debug.Log("GameLoop Start.");
        m_sceneMediation.SetScene(new InitScene(m_sceneMediation), "");

    }

    void Update()
    {
        m_sceneMediation.SceneUpdate();
    }
}
