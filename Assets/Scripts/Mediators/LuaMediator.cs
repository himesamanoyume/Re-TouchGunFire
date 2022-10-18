using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReTouchGunFire.Mgrs;

namespace ReTouchGunFire.Mediators{
    public class LuaMediator : IMediator
    {
        public LuaMgr m_luaMgr = null;
        
        public LuaMediator(){
            Name = "LuaMediator";
        }

        public override void Init()
        {
            m_luaMgr = GameLoop.Instance.gameManager.LuaMgr;
        }

    }
}

