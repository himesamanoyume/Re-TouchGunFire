using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReTouchGunFire.Mediators{
    public class HotUpdateMediator : IMediator
    {
        // public SceneMediator sceneMediator;
        public HotUpdateMediator(){
            Name = "HotUpdateMediator";
        }

        private void Start() {
            Init();
        }

        public override void Init()
        {
            
        }

        public void StartCheck(bool isConnected){
            // Debug.Log("HotUpdateMediator StartCheck");
            // this.sceneMediator = sceneMediator;
            
            StartCoroutine(CheckHotUpdate(isConnected));
        }

        public IEnumerator CheckHotUpdate(bool isConnected){
            // Debug.Log("HotUpdateMediator CheckHotUpdate");
            yield return new WaitForSeconds(2);
            if(!isConnected)
                GameLoop.Instance.GetMediator<PanelMediator>().ShowNotifyPanel("主服务器未能连接~",2f);
                
            EventMgr.Broadcast(GameEvents.CheckHotUpdateEndNotify);
            // sceneMediator.SetScene(mainScene,mainScene.Name);
        }

        
    }
}

