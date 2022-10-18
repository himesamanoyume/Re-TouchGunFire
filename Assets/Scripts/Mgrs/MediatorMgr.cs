using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.Mgrs{
    public class MediatorMgr : IManager
    {
        public MediatorMgr(){
            Name = "MediatorMgr";
        }

        public override void Init(){
            
        }

        public delegate void initDel();
        public initDel m_initDel;

        public void InitDelMediator(){
            m_initDel();
        }

        public void InitLuaMediator(){
            GameLoop.Instance.gameObject.AddComponent<LuaMediator>().Init();
        }
    
        public void InitCanvasMediator(){
            GameLoop.Instance.gameObject.AddComponent<CanvasMediator>().Init();
        }

        public void InitAbMediator(){
            GameLoop.Instance.gameObject.AddComponent<AbMediator>().Init();
        }

        public void InitNetworkMediator(){
            GameLoop.Instance.gameObject.AddComponent<NetworkMediator>().Init();
        }

        public void InitSceneMediator(){
            GameLoop.Instance.gameObject.AddComponent<SceneMediator>().Init();
        }

        public void InitHotUpdateMediator(){
            GameLoop.Instance.gameObject.AddComponent<HotUpdateMediator>().Init();
        }

        public void InitPanelMediator(){
            GameLoop.Instance.gameObject.AddComponent<PanelMediator>().Init();
        }
    }

}

