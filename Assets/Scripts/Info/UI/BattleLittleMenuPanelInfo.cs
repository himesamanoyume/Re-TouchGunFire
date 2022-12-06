using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{

    public class BattleLittleMenuPanelInfo : UIInfo
    {
        [SerializeField] Transform container;
        [SerializeField] Transform point;
        [SerializeField] Button showAllMenuCube;
        [SerializeField] Button leaveBattleCube;
        [SerializeField] Text showAllMenuCubeText;
        void Start()
        {
            Name = "BattleLittleMenuPanelInfo";
            Init();
        }

        bool isShowAllMenu = false;
        bool isShowPlayerProps = false;

        protected sealed override void Init()
        {
            base.Init();
            container = transform.Find("Point/RightCenter/Container");
            point = transform.GetChild(0);
            
            EventMgr.AddListener<RestorePanelNotify>(OnRestorePanel);
            EventMgr.AddListener<ShowBattleLittleMenuPanelNotify>(OnShowThisPanel);
            EventMgr.AddListener<HideBattleLittleMenuPanelNotify>(OnHideThisPanel);

            showAllMenuCube = container.Find("ShowAllMenuCube").GetComponent<Button>();
            leaveBattleCube = container.Find("LeaveBattleCube").GetComponent<Button>();
            showAllMenuCubeText = container.Find("ShowAllMenuCube/Text").GetComponent<Text>();

            showAllMenuCube.onClick.AddListener(()=>{
                if(!isShowAllMenu){
                    
                    panelMediator.MovePanelLevel(EUIPanelType.MainMenuPanel, EUILevel.Level3);
                    showAllMenuCubeText.text = "隐藏菜单";
                }else{
                    panelMediator.MovePanelLevel(EUIPanelType.MainMenuPanel, EUILevel.Level1);
                    showAllMenuCubeText.text = "显示菜单";
                }
                isShowAllMenu = !isShowAllMenu;

            });

            leaveBattleCube.onClick.AddListener(()=>{
                panelMediator.ShowTwiceConfirmPanel("确定要撤退吗?", 10, ()=>{
                    EventMgr.Broadcast(GameEvents.ShowBattleLittleMenuPanelNotify);
                    sceneMediator.SetScene(new MainScene(sceneMediator));
                });
            });

            point.gameObject.SetActive(false);
        }

        void OnRestorePanel(RestorePanelNotify evt) => RestorePanel();
        void RestorePanel(){
            showAllMenuCubeText.text = "完整菜单";
            isShowAllMenu = false;
            isShowPlayerProps = false;
        }

        void OnShowThisPanel(ShowBattleLittleMenuPanelNotify evt) => ShowThisPanel();

        void ShowThisPanel(){
            point.gameObject.SetActive(true);
        }

        void OnHideThisPanel(HideBattleLittleMenuPanelNotify evt) => HideThisPanel();

        void HideThisPanel(){
            point.gameObject.SetActive(false);
        }
    }
}

