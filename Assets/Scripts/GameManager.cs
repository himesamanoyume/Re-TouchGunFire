using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;

public class GameManager : Singleton<GameManager>
{
    private InfoMgr m_infoMgr = new InfoMgr();
    private ObjectMgr m_objectMgr = new ObjectMgr();
    private SceneMgr m_sceneMgr = new SceneMgr();
    private UIMgr m_uiMgr = new UIMgr();
    private ClientMgr m_clientMgr = new ClientMgr();
    private RequestMgr m_requestMgr = new RequestMgr();
    private MediationMgr m_mediationMgr = new MediationMgr();
    private LuaMgr m_luaMgr = new LuaMgr();

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

    public MediationMgr MediationMgr{
        get{return m_mediationMgr;}
    }
    public LuaMgr LuaMgr{
        get{return m_luaMgr;}
    }
}
