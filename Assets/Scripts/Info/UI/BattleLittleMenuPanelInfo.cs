using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{

    public class BattleLittleMenuPanelInfo : UIInfo
    {
        public Transform container;
        public Transform point;
        public Button showAllMenuCube;
        public Button leaveBattleCube;
        public Button showPlayerPropsCube;
        public Text showAllMenuCubeText;
        public Text showPlayerPropsCubeText;

        public PanelMediator panelMediator;
        public SceneMediator sceneMediator;
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
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            sceneMediator = GameLoop.Instance.GetMediator<SceneMediator>();

            container = transform.Find("Point/RightCenter/Container");
            point = transform.GetChild(0);
            
            EventMgr.AddListener<RestorePanelNotify>(OnRestorePanel);
            EventMgr.AddListener<ShowBattleLittleMenuPanelNotify>(OnShowThisPanel);
            EventMgr.AddListener<HideBattleLittleMenuPanelNotify>(OnHideThisPanel);

            showAllMenuCube = container.Find("ShowAllMenuCube").GetComponent<Button>();
            leaveBattleCube = container.Find("LeaveBattleCube").GetComponent<Button>();
            showPlayerPropsCube = container.Find("ShowPlayerPropsCube").GetComponent<Button>();
            showAllMenuCubeText = container.Find("ShowAllMenuCube/Text").GetComponent<Text>();
            showPlayerPropsCubeText = container.Find("ShowPlayerPropsCube/Text").GetComponent<Text>();

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

            showPlayerPropsCube.onClick.AddListener(()=>{

                if(!isShowPlayerProps){
                    panelMediator.MovePanelLevel(EUIPanelType.PlayerPropsPanel, EUILevel.Level5);
                    showPlayerPropsCubeText.text = "隐藏属性";
                }else{
                    panelMediator.MovePanelLevel(EUIPanelType.PlayerPropsPanel, EUILevel.Level1);
                    showPlayerPropsCubeText.text = "显示属性";
                }
                isShowPlayerProps = !isShowPlayerProps;
            });

            leaveBattleCube.onClick.AddListener(()=>{
                panelMediator.GetPanel(EUIPanelType.TwiceConfirmPanel).GetComponent<TwiceConfirmPanelInfo>().ShowTwiceConfirmPanel("确定要撤退吗?", 10, ()=>{
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

