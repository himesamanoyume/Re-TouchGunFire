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
            Init();
        }

        bool isShowAllMenu = false;

        protected sealed override void Init()
        {
            base.Init();
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            container = transform.Find("Point/RightCenter/Container");

            showAllMenuCube = container.Find("ShowAllMenuCube").GetComponent<Button>();
            showAllMenuCubeText = showAllMenuCube.GetComponent<Text>();

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
    }
}

