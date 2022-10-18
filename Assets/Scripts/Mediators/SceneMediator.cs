using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ReTouchGunFire.Mgrs;

namespace ReTouchGunFire.Mediators{
    public class SceneMediator : IMediator
    {
        public SceneMgr m_sceneMgr;
        public AbMediator m_abMediator;
        
        public SceneMediator(){
            Name = "SceneMediator";
        }

        public override void Init()
        {
            m_sceneMgr = GameLoop.Instance.gameManager.SceneMgr;
            if(GameLoop.Instance.TryGetComponent<AbMediator>(out AbMediator abMediator)){
                m_abMediator = abMediator;
            }
            EventMgr.AddListener<CheckHotUpdateEndEvent>(OnCheckHotUpdateEnd);
        }

        public void SetScene(SceneInfo sceneInfo, string sceneName){
            m_sceneMgr.SetScene(sceneInfo, sceneName);
        }

        public void SceneUpdate(){
            m_sceneMgr.SceneUpdate();
        }

        public void LoadScene(string sceneName){
            // m_abMediator.SyncLoadABScene("scenes",sceneName);//同步加载场景测试
            StartCoroutine(m_abMediator.AsyncLoadAbScene("scenes",sceneName));
        }

        public void SceneLog(){
            m_sceneMgr.SceneLog();
        }


        void SetMainScene(){
            MainScene mainScene = new MainScene(this);
            m_sceneMgr.SetScene(mainScene,mainScene.Name);
            EventMgr.RemoveListener<CheckHotUpdateEndEvent>(OnCheckHotUpdateEnd);
        }
        void OnCheckHotUpdateEnd(CheckHotUpdateEndEvent evt) => SetMainScene();

    }
}


