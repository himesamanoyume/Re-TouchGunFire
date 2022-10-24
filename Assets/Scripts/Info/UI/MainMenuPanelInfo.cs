using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{
    public class MainMenuPanelInfo : UIInfo
    {
        public PanelMediator panelMediator;

        public Button attackCube;
        public Button backpackCube;
        public Button warehouseCube;
        public Button friendsCube;
        public Button buildingCube;
        public Button settingCube;
        void Start()
        {
            Name = "MainMenuPanelInfo";
            Init();
        }

        private Transform mainTemplate;

        public override void Init()
        {
            base.Init();
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            mainTemplate = transform.Find("Point/RightBottom/Container/SelectMenuContent/MainTemplate");

            InitMainTemplate();
        }

        void InitMainTemplate(){
            attackCube = mainTemplate.Find("line1/AttackCube").GetComponent<Button>();
            backpackCube = mainTemplate.Find("line2/BackpackCube").GetComponent<Button>();
            warehouseCube = mainTemplate.Find("line2/WarehouseCube").GetComponent<Button>();
            friendsCube = mainTemplate.Find("line3/FriendsCube").GetComponent<Button>();
            buildingCube = mainTemplate.Find("line3/BuildingCube").GetComponent<Button>();
            settingCube = mainTemplate.Find("line4/SettingCube").GetComponent<Button>();

            settingCube.onClick.AddListener(()=>{
                panelMediator.PushPanel(EUIPanelType.TestPanel, EUILevel.Level2, true,(GameObject obj)=>{
                    obj.AddComponent<TestPanelInfo>();
                });
            });
        }
    }
}

