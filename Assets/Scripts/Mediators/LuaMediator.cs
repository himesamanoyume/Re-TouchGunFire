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


        public void Update(){
            if (luaMgr.isGameStarted)
            {
                luaMgr.env.DoString("GameLoopLua.Update()");
            }
        }

        public void FixedUpdate() {
            if (luaMgr.isGameStarted)
            {
                luaMgr.env.DoString("GameLoopLua.FixedUpdate()");
            }
        }
    }
}

