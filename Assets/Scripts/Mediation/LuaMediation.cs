using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuaMediation : IMediation
{
    private LuaMgr m_luaMgr = null;
    private MediationMgr m_mediationMgr = null;
    
    public LuaMediation(MediationMgr mediationMgr) : base (mediationMgr){
        Name = "LuaMediation";
        m_luaMgr = GameManager.Instance.LuaMgr;
    }

}
