using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{
    public sealed class MainMenuPanelInfo : UIInfo
    {
        public PanelMediator panelMediator;
        public SceneMediator sceneMediator;

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
            Init();
        }

        private Transform mainTemplate;
        private Transform attackTemplate;

        protected sealed override void Init()
        {
            base.Init();
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            sceneMediator = GameLoop.Instance.GetMediator<SceneMediator>();
            
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
                GameObject.Find("TwiceConfirmPanel").GetComponent<TwiceConfirmPanelInfo>().ShowTwiceConfirmPanel("确定要出击地区1吗?", 10, ()=>{
                    BackToDefaultMainMenu();
                    sceneMediator.SetScene(new AttackArea1Scene(sceneMediator));
                });
                

            });
        }
    }
}

