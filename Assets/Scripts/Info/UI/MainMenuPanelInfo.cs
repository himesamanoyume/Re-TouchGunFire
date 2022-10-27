using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{
    public sealed class MainMenuPanelInfo : UIInfo
    {
        public PanelMediator panelMediator;

        public Button attackCube;
        public Button backpackCube;
        public Button warehouseCube;
        public Button friendsCube;
        public Button buildingCube;
        public Button settingCube;

        public Button attackBackCube;
        public Button area1Cube;
        void Start()
        {
            Name = "MainMenuPanelInfo";
            currentLevel = EUILevel.Level1;
            Init();
        }

        private Transform mainTemplate;
        private Transform attackTemplate;

        protected sealed override void Init()
        {
            base.Init();
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            mainTemplate = transform.Find("Point/RightBottom/Container/SelectMenuContent/MainTemplate");
            attackTemplate = transform.Find("Point/RightBottom/Container/SelectMenuContent/AttackTemplate");
            InitMainTemplate();
            InitAttackTemplate();
        }

        void InitMainTemplate(){
            attackCube = mainTemplate.Find("line1/AttackCube").GetComponent<Button>();
            backpackCube = mainTemplate.Find("line2/BackpackCube").GetComponent<Button>();
            warehouseCube = mainTemplate.Find("line2/WarehouseCube").GetComponent<Button>();
            friendsCube = mainTemplate.Find("line3/FriendsCube").GetComponent<Button>();
            buildingCube = mainTemplate.Find("line3/BuildingCube").GetComponent<Button>();
            settingCube = mainTemplate.Find("line4/SettingCube").GetComponent<Button>();
            
            attackCube.onClick.AddListener(()=>{
                mainTemplate.localScale = Vector3.zero;
                attackTemplate.localScale = Vector3.one;
            });
            
            backpackCube.onClick.AddListener(()=>{
                panelMediator.PushPanel(EUIPanelType.BackpackPanel, panelMediator.GetPanelLevelUp(currentLevel), true, (GameObject obj)=>{
                    obj.AddComponent<BackpackPanelInfo>().currentLevel = panelMediator.GetPanelLevelUp(currentLevel);
                    
                });
                
            });
            settingCube.onClick.AddListener(()=>{
                panelMediator.PushPanel(EUIPanelType.TestPanel, panelMediator.GetPanelLevelUp(currentLevel), true, (GameObject obj)=>{
                    obj.AddComponent<TestPanelInfo>().currentLevel = panelMediator.GetPanelLevelUp(currentLevel);
                    
                });
            });
        }

        void BackToDefaultMainMenu(){
            mainTemplate.localScale = Vector3.one;
            attackTemplate.localScale = Vector3.zero;
        }

        void InitAttackTemplate(){
            attackBackCube = attackTemplate.Find("line1/BackCube").GetComponent<Button>();
            area1Cube = attackTemplate.Find("line2/Area1Cube").GetComponent<Button>();

            attackBackCube.onClick.AddListener(()=>{
                mainTemplate.localScale = Vector3.one;
                attackTemplate.localScale = Vector3.zero;
            });

            area1Cube.onClick.AddListener(()=>{
                panelMediator.MovePanelLevel(EUIPanelType.MainMenuPanel, EUILevel.Level1);
                EventMgr.Broadcast(GameEvents.RestorePanelNotify);
                // EventMgr.Broadcast(GameEvents.ShowLoadingPanelNotify);
                
                BackToDefaultMainMenu();

                panelMediator.PushPanel(EUIPanelType.AttackArea1Panel, EUILevel.Level2, false, (GameObject obj)=>{
                    obj.AddComponent<AttackArea1PanelInfo>().currentLevel = EUILevel.Level2;
                });
                panelMediator.PushPanel(EUIPanelType.BattleGunInfoPanel, EUILevel.Level3, false, (GameObject obj)=>{
                    obj.AddComponent<BattleGunInfoPanelInfo>().currentLevel = EUILevel.Level3;
                });
                panelMediator.PushPanel(EUIPanelType.BattleLittleMenuPanel, EUILevel.Level3, false, (GameObject obj)=>{
                    obj.AddComponent<BattleLittleMenuPanelInfo>().currentLevel = EUILevel.Level3;
                });
                panelMediator.MovePanelLevel(EUIPanelType.PlayerInfoPanel, EUILevel.Level3);
                panelMediator.MovePanelLevel(EUIPanelType.MainInfoPanel, EUILevel.Level3);
                panelMediator.MovePanelLevel(EUIPanelType.PlayerPropsPanel, EUILevel.Level1);
            });
        }
    }
}

