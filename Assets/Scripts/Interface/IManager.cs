using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IManager : IBase
{
    protected SceneMgr m_sceneMgr = null;
    protected InfoMgr m_infoMgr = null;
    protected ObjectMgr m_objectMgr = null;
    protected UIMgr m_uiMgr = null;
    protected bool isBegin = false;

    // public IManager(SceneMgr sceneManager){
    //     m_sceneMgr = sceneManager;
    // }

    // public IManager(InfoMgr infoManager){
    //     m_infoMgr = infoManager;
    // }

    // public IManager(ObjectMgr objectManager){
    //     m_objectMgr = objectManager;
    // }

    // public IManager(UIMgr uIManager){
    //     m_uiMgr = uIManager;
    // }

    // public IManager(){

    // }

}
