using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{
    public sealed class BackButtonPanelInfo : UIInfo
    {
        public Button backButton;
        private GameObject point;
        public PanelMediator panelMediator;

        private void Start() {
            Name = "BackButtonPanelInfo";
            Init();
        }

        protected sealed override void Init()
        {
            base.Init();
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            // if(GameLoop.Instance.TryGetComponent<PanelMediator>(out PanelMediator panelMediator)){
            //     panelMediator = panelMediator;
            // }else{
            //     Debug.LogWarning("未拿到对应组件");
            // }
            backButton = transform.Find("Point/BackContainer/BackButton").GetComponent<Button>();
            backButton.onClick.AddListener(() => {
                panelMediator.PopPanel(false);
                if(panelMediator.CheckPanelList())
                    EventMgr.Broadcast(GameEvents.CloseBackButtonPanelNotify);
            });
            point = transform.GetChild(0).gameObject;
            EventMgr.AddListener<ShowBackButtonPanelNotify>(OnShowBackButtonPanel);
            EventMgr.AddListener<CloseBackButtonPanelNotify>(OnCloseBackButtonPanel);
            point.SetActive(false);
        }

        void OnShowBackButtonPanel(ShowBackButtonPanelNotify evt) => ShowPanel();
        void ShowPanel(){
            point.SetActive(true);
        }

        void OnCloseBackButtonPanel(CloseBackButtonPanelNotify evt) => ClosePanel();
        void ClosePanel(){
            point.SetActive(false);
        }


    }
}


