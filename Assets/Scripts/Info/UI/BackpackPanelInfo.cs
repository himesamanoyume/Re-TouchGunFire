using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{
    public sealed class BackpackPanelInfo : UIInfo
    {
        public Button point;
        private Transform equippedPart;
        private Transform idlePart;
        public PanelMediator panelMediator;
        public Button backEquippedPartCube;
        public Button mainGunCube;
        public Button handgunCube;
        public Button armorCube;
        public Button headCube;
        public Button handCube;
        public Button kneeCube;
        public Button legCube;
        public Button bootsCube;

        void Start()
        {
            Name = "BackpackPanelInfo";
            Init();
        }

        protected sealed override void Init()
        {
            base.Init();
            panelMediator = GameLoop.Instance.GetMediator<PanelMediator>();
            point = transform.GetChild(0).GetComponent<Button>();
            point.onClick.AddListener(()=>{
                panelMediator.PopPanel(false);
                isEquippedPartShowed = false;
                ShowIdlePart();
                if(panelMediator.CheckPanelList())
                    EventMgr.Broadcast(GameEvents.CloseBackButtonPanelNotify);
            });
            ua += ShowIdlePart;
            equippedPart = transform.Find("Point/Right/Container/EquippedPart");
            idlePart = transform.Find("Point/Right/Container/IdlePart");
            InitEquippedPart();
            InitIdlePart();
            EventMgr.AddListener<RestorePanelNotify>(OnRestorePanel);
        }

        UnityAction ua;
        bool isEquippedPartShowed = true;
        void ShowIdlePart(){
            if(isEquippedPartShowed){
                equippedPart.GetComponent<RectTransform>().offsetMax = offScreen;
                idlePart.GetComponent<RectTransform>().offsetMax = inTheScreen;
            }else{
                idlePart.GetComponent<RectTransform>().offsetMax = offScreen;
                equippedPart.GetComponent<RectTransform>().offsetMax = inTheScreen;
            }
            isEquippedPartShowed = !isEquippedPartShowed;
        }

        void InitEquippedPart(){
            mainGunCube = equippedPart.Find("Content/MainGunCube").GetComponent<Button>();
            handgunCube = equippedPart.Find("Content/HandGunCube").GetComponent<Button>();
            armorCube = equippedPart.Find("Content/ArmorCube").GetComponent<Button>();
            headCube = equippedPart.Find("Content/HeadCube").GetComponent<Button>();
            handCube = equippedPart.Find("Content/HandCube").GetComponent<Button>();
            kneeCube = equippedPart.Find("Content/KneeCube").GetComponent<Button>();
            legCube = equippedPart.Find("Content/LegCube").GetComponent<Button>();
            bootsCube = equippedPart.Find("Content/BootsCube").GetComponent<Button>();
            mainGunCube.onClick.AddListener(ua);
            handgunCube.onClick.AddListener(ua);
            armorCube.onClick.AddListener(ua);
            headCube.onClick.AddListener(ua);
            handCube.onClick.AddListener(ua);
            kneeCube.onClick.AddListener(ua);
            legCube.onClick.AddListener(ua);
            bootsCube.onClick.AddListener(ua);
        }

        void InitIdlePart(){
            backEquippedPartCube = idlePart.Find("ListPart/BackEquippedPartCube").GetComponent<Button>();
            backEquippedPartCube.onClick.AddListener(ua);
        }

        void OnRestorePanel(RestorePanelNotify evt) => RestorePanel();
        void RestorePanel(){
            panelMediator.MovePanelLevel(EUIPanelType.BackpackPanel, EUILevel.Level2);
        }
    }
}

