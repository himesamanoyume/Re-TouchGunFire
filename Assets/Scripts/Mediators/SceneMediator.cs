using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ReTouchGunFire.Mgrs;

namespace ReTouchGunFire.Mediators{
    public class SceneMediator : IMediator
    {
        public SceneMgr sceneMgr;
        public AbMediator abMediator;
        
        public SceneMediator(){
            Name = "SceneMediator";
        }

        private void Awake() {
            Init();
        }

        public override void Init()
        {
            sceneMgr = GameLoop.Instance.gameManager.SceneMgr;
            abMediator = GameLoop.Instance.GetMediator<AbMediator>();
            EventMgr.AddListener<UserLoginSuccessNotify>(OnUserLoginSuccess);
        }

        public void SetScene(SceneInfo sceneInfo, string sceneName){
            sceneMgr.SetScene(sceneInfo, sceneName);
        }

        public void SetScene(SceneInfo sceneInfo){
            sceneMgr.SetScene(sceneInfo);
        }

        public void SceneUpdate(){
            sceneMgr.SceneUpdate();
        }

        public void LoadScene(string sceneName){
            // abMediator.SyncLoadABScene("scenes",sceneName);//同步加载场景测试
            StartCoroutine(abMediator.AsyncLoadAbScene("scenes",sceneName));
        }

        public void SceneLog(){
            sceneMgr.SceneLog();
        }


        void SetMainScene(){
            EventMgr.Broadcast(GameEvents.ShowLoadingPanelNotify);
            sceneMgr.SetScene(new MainScene(this));
        }
        void OnUserLoginSuccess(UserLoginSuccessNotify evt) => SetMainScene();

    }
}


