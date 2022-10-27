using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{

    public class BattleLittleMenuPanelInfo : UIInfo
    {
        public Transform container;
        public Button showAllMenuCube;
        public Text showAllMenuCubeText;

        public PanelMediator panelMediator;
        void Start()
        {
            Name = "BattleLittleMenuPanelInfo";
            currentLevel = EUILevel.Level3;
            Init();
        }

        bool isShowAllMenu = false;

        protected sealed override void Init()
        {
            base.Init();
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            
            container = transform.Find("Point/RightCenter/Container");
            EventMgr.AddListener<RestorePanelNotify>(OnRestorePanel);

            showAllMenuCube = container.Find("ShowAllMenuCube").GetComponent<Button>();
            showAllMenuCubeText = container.Find("ShowAllMenuCube/Text").GetComponent<Text>();

            showAllMenuCube.onClick.AddListener(()=>{
                if(!isShowAllMenu){
                    
                    panelMediator.MovePanelLevel(EUIPanelType.MainMenuPanel, EUILevel.Level3);
                    showAllMenuCubeText.text = "隐藏菜单";
                }else{
                    panelMediator.MovePanelLevel(EUIPanelType.MainMenuPanel, EUILevel.Level1);
                    showAllMenuCubeText.text = "完整菜单";
                }
                isShowAllMenu = !isShowAllMenu;

            });
        }

        void OnRestorePanel(RestorePanelNotify evt) => RestorePanel();
        void RestorePanel(){
            showAllMenuCubeText.text = "完整菜单";
            isShowAllMenu =false;
        }
    }
}

