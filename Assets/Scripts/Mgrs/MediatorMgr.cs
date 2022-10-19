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
            GameLoop.Instance.gameObject.AddComponent<LuaMediator>();
        }
    
        public void InitCanvasMediator(){
            GameLoop.Instance.gameObject.AddComponent<CanvasMediator>();
        }

        public void InitAbMediator(){
            GameLoop.Instance.gameObject.AddComponent<AbMediator>();
        }

        public void InitNetworkMediator(){
            GameLoop.Instance.gameObject.AddComponent<NetworkMediator>();
        }

        public void InitSceneMediator(){
            GameLoop.Instance.gameObject.AddComponent<SceneMediator>();
        }

        public void InitHotUpdateMediator(){
            GameLoop.Instance.gameObject.AddComponent<HotUpdateMediator>();
        }

        public void InitPanelMediator(){
            GameLoop.Instance.gameObject.AddComponent<PanelMediator>();
        }
    }

}

