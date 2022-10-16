using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuaMediation : IMediation
{
    public LuaMgr m_luaMgr = null;
    
    public LuaMediation(){
        Name = "LuaMediation";
    }

    public override void Init()
    {
        m_luaMgr = GameLoop.Instance.gameManager.LuaMgr;
    }

}
