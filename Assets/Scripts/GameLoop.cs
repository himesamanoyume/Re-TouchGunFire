using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReTouchGunFire.Mediators;
using ReTouchGunFire.Mgrs;

public class GameLoop : UnitySingleton<GameLoop>
{
    private MediatorMgr m_MediatorMgr;
    private SceneMediator m_sceneMediator;
    public GameManager gameManager;

    public override void Awake()
    {
        base.Awake();
        gameManager = new GameManager();
        //游戏初始化
        m_MediatorMgr = gameManager.MediatorMgr;
        m_MediatorMgr.m_initDel += m_MediatorMgr.InitAbMediator;
        m_MediatorMgr.m_initDel += m_MediatorMgr.InitSceneMediator;
        m_MediatorMgr.m_initDel += m_MediatorMgr.InitHotUpdateMediator;
        m_MediatorMgr.m_initDel += m_MediatorMgr.InitCanvasMediator;
        m_MediatorMgr.m_initDel += m_MediatorMgr.InitLuaMediator;
        m_MediatorMgr.m_initDel += m_MediatorMgr.InitPanelMediator;
        m_MediatorMgr.m_initDel += m_MediatorMgr.InitNetworkMediator;

        m_MediatorMgr.InitDelMediator();

        gameManager.Init();
        //end
    }

    void Start()
    {
        
        m_sceneMediator = gameObject.GetComponent<SceneMediator>();
        // Debug.Log("GameLoop Start.");
        m_sceneMediator.SetScene(new InitScene(m_sceneMediator), "");

    }

    void Update()
    {
        m_sceneMediator.SceneUpdate();
    }

    public T GetMediator<T>() where T : IMediator{
        if(this.TryGetComponent<T>(out T t)){
            return t;
        }else{
            Debug.LogWarning("未拿到对应组件:" + t.ToString());
            return null;
        }
    }
}
