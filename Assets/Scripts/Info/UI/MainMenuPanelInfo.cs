using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{
    public class MainMenuPanelInfo : UIInfo
    {
        public PanelMediator m_panelMediator;

        public Button m_attackCube;
        public Button m_bagCube;
        public Button m_warehouseCube;
        public Button m_friendsCube;
        public Button m_buildingCube;
        public Button m_settingCube;
        void Start()
        {
            Name = "MainMenuPanelInfo";
            Init();
        }

        private Transform mainTemplate;

        public override void Init()
        {
            base.Init();
            m_panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            mainTemplate = transform.Find("Point/RightBottom/Container/SelectMenuContent/MainTemplate");

            InitMainTemplate();
        }

        void InitMainTemplate(){
            m_attackCube = mainTemplate.Find("line1/AttackCube").GetComponent<Button>();
            m_bagCube = mainTemplate.Find("line2/BagCube").GetComponent<Button>();
            m_warehouseCube = mainTemplate.Find("line2/WarehouseCube").GetComponent<Button>();
            m_friendsCube = mainTemplate.Find("line3/FriendsCube").GetComponent<Button>();
            m_buildingCube = mainTemplate.Find("line3/BuildingCube").GetComponent<Button>();
            m_settingCube = mainTemplate.Find("line4/SettingCube").GetComponent<Button>();

            m_settingCube.onClick.AddListener(()=>{
                m_panelMediator.PushPanel(EUIPanelType.TestPanel, EUILevel.Level2, true,(GameObject obj)=>{
                    obj.AddComponent<TestPanelInfo>();
                });
            });
        }
    }
}

