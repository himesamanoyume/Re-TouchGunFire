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
        mediatorMgr.initDel += mediatorMgr.InitNetworkMediator;
        mediatorMgr.initDel += mediatorMgr.InitRequestMediator;
        mediatorMgr.initDel += mediatorMgr.InitSceneMediator;
        mediatorMgr.initDel += mediatorMgr.InitHotUpdateMediator;
        mediatorMgr.initDel += mediatorMgr.InitCanvasMediator;
        mediatorMgr.initDel += mediatorMgr.InitLuaMediator;
        mediatorMgr.initDel += mediatorMgr.InitPanelMediator;
        

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
        
        // sceneMediator.SetScene(new InitScene(this.sceneMediator), "");

        //temp
            // Tester tester = new Tester();
            // addCoin += GunBuff1;
            // addCoin?.Invoke(tester);
            // realTester = tester;
            // Debug.LogError("tester coin:"+realTester.coin);
            // Tester tester1 = new Tester();
            // addCoin += GunBuff2;
            // addCoin?.Invoke(tester1);
            // realTester = tester1;
            // Debug.LogError("tester coin:"+realTester.coin);
            // Tester tester2 = new Tester();
            // addCoin -= GunBuff2;
            // addCoin?.Invoke(tester2);
            // realTester = tester2;
            // Debug.LogError("tester coin:"+realTester.coin);
        //end
    }
    //temp
        // Tester realTester = new Tester();
        // public void GunBuff1(Tester tester){
        //     tester.coin += 5;
        // }

        // public void GunBuff2(Tester tester){
        //     tester.coin += 10;
        // }

        // public delegate void AddCoin(Tester tester);
        // public AddCoin addCoin;

        // public class Tester{
        //     public int coin = 0;
            
        // }
    //end

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
