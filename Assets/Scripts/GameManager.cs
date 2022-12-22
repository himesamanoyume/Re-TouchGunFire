using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mgrs;

public class GameManager
{
    private MediatorMgr mediatorMgr = new MediatorMgr();
    // private InfoMgr infoMgr = new InfoMgr();
    // private SceneMgr sceneMgr = new SceneMgr();
    // private UIMgr uiMgr = new UIMgr();
    // private ClientMgr clientMgr = new ClientMgr();
    // private RequestMgr requestMgr = new RequestMgr();
    private LuaMgr luaMgr = new LuaMgr();

    public void Init(){
        // Debug.Log("GameManager Init Start");
        mediatorMgr.Init();
        // infoMgr.Init();
        // sceneMgr.Init();
        // uiMgr.Init();
        // requestMgr.Init();
        luaMgr.Init();
        // EventMgr.AddListener<StartConnectMasterServerNotify>(OnConnectMasterServer);
    }

    // void OnConnectMasterServer(StartConnectMasterServerNotify evt) => InitClientMgr();
    // void InitClientMgr(){
    //     clientMgr.Init();
    // }

    // public InfoMgr InfoMgr{
    //     get{return infoMgr;}
    // }

    // public SceneMgr SceneMgr{
    //     get{return sceneMgr;}
    // }

    // public UIMgr UIMgr{
    //     get{return uiMgr;}
    // }

    // public ClientMgr ClientMgr{
    //     get{return clientMgr;}
    // }

    // public RequestMgr RequestMgr{
    //     get{return requestMgr;}
    // }

    public MediatorMgr MediatorMgr{
        get{return mediatorMgr;}
    }
    public LuaMgr LuaMgr{
        get{return luaMgr;}
    }

}
