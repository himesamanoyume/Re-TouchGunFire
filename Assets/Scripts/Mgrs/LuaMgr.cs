using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using XLua;

namespace ReTouchGunFire.Mgrs{
    public class LuaMgr : IManager
    {
        private LuaEnv env;
        private static string _LuaScriptFolder = "LuaScripts";
        public LuaMgr(){
            Name = "LuaMgr";
        }

        public override void Init(){
            //InitLuaEnv();
        }

        private void InitLuaEnv(){
            env = new LuaEnv();
            env.AddLoader(LuaScriptLoader);
        }

        public byte[] LuaScriptLoader(ref string filePath){
            string scriptPath = string.Empty;
            filePath = filePath.Replace(".","/") + ".lua"; // UI/UIBase.lua

        #if UNITY_EDITOR
            scriptPath = Path.Combine(Application.dataPath, _LuaScriptFolder); // Assets/LuaScripts
            scriptPath = Path.Combine(scriptPath, filePath); // Assets/LuaScripts/UI/UIBase.lua

            // byte[] data = Game
            return null;
        #endif

            return null;
        }
    }
}


