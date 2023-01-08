using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReTouchGunFire.Mgrs;

namespace ReTouchGunFire.Mediators{
    public class LuaMediator : IMediator
    {
        public LuaMgr luaMgr;
        
        public LuaMediator(){
            Name = "LuaMediator";
        }

        private void Start() {
            Init();
        }

        public override void Init()
        {
            luaMgr = GameLoop.Instance.gameManager.LuaMgr;
        }

    }
}

