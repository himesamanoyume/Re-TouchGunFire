using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{
    public sealed class BackpackPanelInfo : UIInfo
    {
        [SerializeField] Button point;
        [SerializeField] Transform equippedPart;
        [SerializeField] Transform idlePart;
        [SerializeField] Button backEquippedPartCube;
        [SerializeField] Button mainGunCube;
        [SerializeField] Button handgunCube;
        [SerializeField] Button armorCube;
        [SerializeField] Button headCube;
        [SerializeField] Button handCube;
        [SerializeField] Button kneeCube;
        [SerializeField] Button legCube;
        [SerializeField] Button bootsCube;

        void Start()
        {
            Name = "BackpackPanelInfo";
            Init();
        }

        protected sealed override void Init()
        {
            base.Init();
            point = transform.GetChild(0).GetComponent<Button>();
            point.onClick.AddListener(()=>{
                panelMediator.PopPanel(false);
                EventMgr.Broadcast(GameEvents.BackpackPanelCloseNotify);
                isEquippedPartShowed = false;
                // ShowIdlePart();
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

        /// <summary>
        /// 显示背包列表
        /// </summary>
        void ShowIdlePart(){
            // if(isEquippedPartShowed){
            //     equippedPart.GetComponent<RectTransform>().offsetMax = offScreen;
            //     idlePart.GetComponent<RectTransform>().offsetMax = inTheScreen;
            // }else{
            //     idlePart.GetComponent<RectTransform>().offsetMax = offScreen;
            //     equippedPart.GetComponent<RectTransform>().offsetMax = inTheScreen;
            // }
            // isEquippedPartShowed = !isEquippedPartShowed;

            panelMediator.PushPanel(EUIPanelType.ShopPanel, panelMediator.GetPanelLevelUp(currentLevel), true, (GameObject obj)=>{
                    obj.AddComponent<ShopPanelInfo>().currentLevel = panelMediator.GetPanelLevelUp(currentLevel);
                });
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

