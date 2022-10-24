using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReTouchGunFire.PanelInfo{
        public class CanvasInfo : UIInfo
    {
        public Transform level1;
        public Transform level2;
        public Transform level3;
        public Transform level4;
        public Transform levelLoading;
        public Camera mainCamera;

        private void Start() {
            Name = "CanvasInfo";
            Init();
        }

        public override void Init(){
            base.Init();
            level1 = transform.GetChild(0);
            // Debug.Log(level1.name);
            level2 = transform.GetChild(1);
            // Debug.Log(level2.name);
            level3 = transform.GetChild(2);
            // Debug.Log(level3.name);
            level4 = transform.GetChild(3);
            // Debug.Log(level4.name);
            levelLoading = transform.GetChild(4);
            // Debug.Log(levelLoading.name);
            mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(mainCamera);
            transform.GetComponent<Canvas>().worldCamera = mainCamera;
        }

        public Transform Canvas{
            get{ return this.transform;}
        }
        public Transform Level1{
            get{ return level1;}
        }
        public Transform Level2{
            get{ return level2;}
        }
        public Transform Level3{
            get{ return level3;}
        }
        public Transform Level4{
            get{ return level4;}
        }
        public Transform LevelLoading{
            get{ return levelLoading;}
        }
    }
}

