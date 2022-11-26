using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{
    public sealed class BackButtonPanelInfo : UIInfo
    {
        [SerializeField] Button backButton;
        private GameObject point;

        private void Start() {
            Name = "BackButtonPanelInfo";
            Init();
        }

        protected sealed override void Init()
        {
            base.Init();
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
            EventMgr.Broadcast(GameEvents.BackpackPanelCloseNotify);
            point.SetActive(false);
            
        }


    }
}


