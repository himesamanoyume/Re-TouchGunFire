using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReTouchGunFire.PanelInfo{
        public class CanvasInfo : UIInfo
    {
        public Transform m_level1;
        public Transform m_level2;
        public Transform m_level3;
        public Transform m_level4;
        public Transform m_levelLoading;
        public Camera m_mainCamera;

        private void Start() {
            Init();
        }

        public override void Init(){
            m_level1 = transform.GetChild(0);
            // Debug.Log(m_level1.name);
            m_level2 = transform.GetChild(1);
            // Debug.Log(m_level2.name);
            m_level3 = transform.GetChild(2);
            // Debug.Log(m_level3.name);
            m_level4 = transform.GetChild(3);
            // Debug.Log(m_level4.name);
            m_levelLoading = transform.GetChild(4);
            // Debug.Log(m_levelLoading.name);
            m_mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(m_mainCamera);
            transform.GetComponent<Canvas>().worldCamera = m_mainCamera;
        }

        public Transform Canvas{
            get{ return this.transform;}
        }
        public Transform Level1{
            get{ return m_level1;}
        }
        public Transform Level2{
            get{ return m_level2;}
        }
        public Transform Level3{
            get{ return m_level3;}
        }
        public Transform Level4{
            get{ return m_level4;}
        }
        public Transform LevelLoading{
            get{ return m_levelLoading;}
        }
    }
}

