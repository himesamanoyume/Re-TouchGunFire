using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;

public class GameManager
{
    private InfoMgr m_infoMgr = new InfoMgr();
    private ObjectMgr m_objectMgr = new ObjectMgr();
    private SceneMgr m_sceneMgr = new SceneMgr();
    private UIMgr m_uiMgr = new UIMgr();
    private ClientMgr m_clientMgr = new ClientMgr();
    private RequestMgr m_requestMgr = new RequestMgr();

    public InfoMgr InfoMgr{
        get{return m_infoMgr;}
    }

    public ObjectMgr ObjectMgr{
        get{return m_objectMgr;}
    }

    public SceneMgr SceneMgr{
        get{return m_sceneMgr;}
    }

    public UIMgr UIMgr{
        get{return m_uiMgr;}
    }

    public ClientMgr ClientMgr{
        get{return m_clientMgr;}
    }

    public RequestMgr RequestMgr{
        get{return m_requestMgr;}
    }


    // public void Send(MainPack mainPack){
    //     m_clientMgr.Send(mainPack);
    // }

    // public void HandleResponse(MainPack mainPack){
        
    // }
}
