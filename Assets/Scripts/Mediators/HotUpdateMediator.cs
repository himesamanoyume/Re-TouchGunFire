using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReTouchGunFire.Mgrs;

namespace ReTouchGunFire.Mediators{
    public class HotUpdateMediator : IMediator
    {
        public SceneMediator sceneMediator;
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
            this.sceneMediator = sceneMediator;
            StartCoroutine(CheckHotUpdate());
        }

        public IEnumerator CheckHotUpdate(){
            // Debug.Log("HotUpdateMediator CheckHotUpdate");
            yield return new WaitForSeconds(2);
            
            EventMgr.Broadcast(GameEvents.CheckHotUpdateEndNotify);
            // sceneMediator.SetScene(mainScene,mainScene.Name);
        }

        
    }
}

