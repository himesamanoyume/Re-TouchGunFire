using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using ReTouchGunFire.Mgrs;

public class GameManager
{
    private MediatorMgr m_mediatorMgr = new MediatorMgr();
    private InfoMgr m_infoMgr = new InfoMgr();
    private ObjectMgr m_objectMgr = new ObjectMgr();
    private SceneMgr m_sceneMgr = new SceneMgr();
    private UIMgr m_uiMgr = new UIMgr();
    private ClientMgr m_clientMgr = new ClientMgr();
    private RequestMgr m_requestMgr = new RequestMgr();
    private LuaMgr m_luaMgr = new LuaMgr();

    public void Init(){
        // Debug.Log("GameManager Init Start");
        m_mediatorMgr.Init();
        m_infoMgr.Init();
        m_objectMgr.Init();
        m_sceneMgr.Init();
        m_uiMgr.Init();
        m_clientMgr.Init();
        m_requestMgr.Init();
        m_requestMgr.Init();
        m_luaMgr.Init();
    }

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

    public MediatorMgr MediatorMgr{
        get{return m_mediatorMgr;}
    }
    public LuaMgr LuaMgr{
        get{return m_luaMgr;}
    }
}
