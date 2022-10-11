using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;

public class GameManager
{
    public InfoMgr m_infoMgr = new InfoMgr();
    public ObjectMgr m_objectMgr = new ObjectMgr();
    public SceneMgr m_sceneMgr = new SceneMgr();
    public UIMgr m_uiMgr = new UIMgr();
    public ClientMgr m_clientMgr = new ClientMgr();


    public void Send(MainPack mainPack){
        m_clientMgr.Send(mainPack);
    }

    public void HandleResponse(MainPack mainPack){
        
    }
}
