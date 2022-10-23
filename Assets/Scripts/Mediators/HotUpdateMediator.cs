using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReTouchGunFire.Mgrs;

namespace ReTouchGunFire.Mediators{
    public class HotUpdateMediator : IMediator
    {
        public SceneMediator m_sceneMediator;
        public HotUpdateMediator(){
            Name = "HotUpdateMediator";
        }

        private void Start() {
            Init();
        }

        public override void Init()
        {
            
        }

        public void StartCheck(SceneMediator sceneMediator){
            // Debug.Log("HotUpdateMediator StartCheck");
            m_sceneMediator = sceneMediator;
            StartCoroutine(CheckHotUpdate());
        }

        public IEnumerator CheckHotUpdate(){
            // Debug.Log("HotUpdateMediator CheckHotUpdate");
            yield return new WaitForSeconds(2);
            
            EventMgr.Broadcast(GameEvents.CheckHotUpdateEndNotify);
            // m_sceneMediator.SetScene(mainScene,mainScene.Name);
        }

        
    }
}

