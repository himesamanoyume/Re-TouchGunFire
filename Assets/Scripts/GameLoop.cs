using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReTouchGunFire.Mediators;
using ReTouchGunFire.Mgrs;

public class GameLoop : UnitySingleton<GameLoop>
{
    private MediatorMgr mediatorMgr;
    private SceneMediator sceneMediator;
    public GameManager gameManager;

    public override void Awake()
    {
        base.Awake();
        gameManager = new GameManager();
        //游戏初始化
        mediatorMgr = gameManager.MediatorMgr;
        mediatorMgr.initDel += mediatorMgr.InitAbMediator;
        mediatorMgr.initDel += mediatorMgr.InitSceneMediator;
        mediatorMgr.initDel += mediatorMgr.InitHotUpdateMediator;
        mediatorMgr.initDel += mediatorMgr.InitCanvasMediator;
        mediatorMgr.initDel += mediatorMgr.InitLuaMediator;
        mediatorMgr.initDel += mediatorMgr.InitPanelMediator;
        mediatorMgr.initDel += mediatorMgr.InitNetworkMediator;

        mediatorMgr.InitDelMediator();

        gameManager.Init();
        //end
    }

    void Start()
    {
        
        sceneMediator = GetMediator<SceneMediator>();
        // Debug.Log("GameLoop Start.");
        sceneMediator.SetScene(new InitScene(this.sceneMediator));
        gameObject.AddComponent<PlayerInfo>();
        gameObject.AddComponent<GetPlayerBaseInfoRequest>();
        // sceneMediator.SetScene(new InitScene(this.sceneMediator), "");

    }

    void Update()
    {
        sceneMediator.SceneUpdate();
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
