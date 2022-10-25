using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReTouchGunFire.PanelInfo{
    public sealed class LoadingPanelInfo : UIInfo
    {
        public Transform point;
        
        void Start()
        {
            Name = "LoadingPanelInfo";
            Init();
        }

        protected sealed override void Init()
        {
            base.Init();
            point = transform.GetChild(0);
            point.gameObject.SetActive(false);
            EventMgr.AddListener<ShowLoadingPanelNotify>(OnShowLoadingPanelNotify);
            EventMgr.AddListener<CloseLoadingPanelNotify>(OnCloseLoadingPanelNotify);
        }

        void OnShowLoadingPanelNotify(ShowLoadingPanelNotify evt) => ShowPanel();
        void OnCloseLoadingPanelNotify(CloseLoadingPanelNotify evt) => ClosePanel();

        void ShowPanel(){
            point.gameObject.SetActive(true);
        }

        void ClosePanel(){
            point.gameObject.SetActive(false);
        }
    }
}

