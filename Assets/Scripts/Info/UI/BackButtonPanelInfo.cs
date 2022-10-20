using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mgrs;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{
    public class BackButtonPanelInfo : UIInfo
    {
        public Button m_backButton;
        private GameObject m_point;
        public PanelMediator m_panelMediator;

        private void Start() {
            Init();
        }

        public override void Init()
        {
            m_panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            // if(GameLoop.Instance.TryGetComponent<PanelMediator>(out PanelMediator panelMediator)){
            //     m_panelMediator = panelMediator;
            // }else{
            //     Debug.LogWarning("未拿到对应组件");
            // }
            m_backButton = transform.Find("Point/BackContainer/BackButton").GetComponent<Button>();
            m_backButton.onClick.AddListener(() => {m_panelMediator.PopPanel();});
            m_point = transform.GetChild(0).gameObject;
            EventMgr.AddListener<ShowBackButtonPanelNotify>(OnShowBackButtonPanel);
            EventMgr.AddListener<CloseBackButtonPanelNotify>(OnCloseBackButtonPanel);
            m_point.SetActive(false);
        }

        void OnShowBackButtonPanel(ShowBackButtonPanelNotify evt) => ShowPanel();
        void ShowPanel(){
            m_point.SetActive(true);
        }

        void OnCloseBackButtonPanel(CloseBackButtonPanelNotify evt) => ClosePanel();
        void ClosePanel(){
            m_point.SetActive(false);
        }


    }
}


