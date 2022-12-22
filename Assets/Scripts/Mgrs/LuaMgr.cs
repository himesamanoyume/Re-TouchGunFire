using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using XLua;

namespace ReTouchGunFire.Mgrs{
    public class LuaMgr : IManager
    {
        public LuaEnv env;
        private static string _LuaScriptFolder = "LuaScripts";
        public LuaMgr(){
            Name = "LuaMgr";
        }

        public bool isGameStarted = false;

        public override void Init(){
            InitLuaEnv();
        }

        private void InitLuaEnv(){
            env = new LuaEnv();
            if (env == null)
            {
                Debug.LogError("Lua Env is null");
                return;
            }

            env.AddLoader(LuaScriptLoader);
            EnterGame();
        }

        public byte[] LuaScriptLoader(ref string filePath){
            string scriptPath = string.Empty;
            filePath = filePath.Replace(".","/") + ".lua"; // UI/UIBase.lua

        #if UNITY_EDITOR
            scriptPath = Path.Combine(Application.dataPath, _LuaScriptFolder); // Assets/LuaScripts
            scriptPath = Path.Combine(scriptPath, filePath); // Assets/LuaScripts/UI/UIBase.lua
            
            if (File.Exists(scriptPath))
            {
                return File.ReadAllBytes(scriptPath);
            }else
            {
                return null;
            }
            
        #endif
            //发布模式去ab包读
            return null;
        }

        public void EnterGame(){
            env.DoString("require('GameLoopLua')");
            env.DoString("GameLoopLua.Init()");
            isGameStarted = true;
        }

        private void OnDestroy()
        {
            env.Dispose();
        }
    }
}


