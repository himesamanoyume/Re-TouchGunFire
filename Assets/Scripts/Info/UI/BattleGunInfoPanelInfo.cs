using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{
    public sealed class BattleGunInfoPanelInfo : UIInfo
    {
        //temp
        // public class Ak47Info : GunInfo {
        //     public Ak47Info(){
        //         gunName = EGunName.AK47;
        //         gunType = EGunType.AR;
        //         baseDMG = 100;
        //         firingRate = 600f;
        //         magazine = 30;
        //         magazineCount = 16;
        //         currentFiringRatePerSecond = (firingRate / 60f) / 100f;
        //     }
        // }
        //end

        void Start()
        {
            Name = "BattleGunInfoPanelInfo";
            Init();
        }
        PlayerInfo playerInfo;
        [SerializeField] Transform mainGun;
        [SerializeField] Transform handGun;
        [SerializeField] Button mainGunCube;
        [SerializeField] Button handGunCube;
        [SerializeField] Slider mainGunReloadingBar;
        [SerializeField] Slider handGunReloadingBar;
        [SerializeField] Image mainGunBG;
        [SerializeField] Image handGunBG;
        [SerializeField] Text mainGunNameText;
        [SerializeField] Text handGunNameText;
        [SerializeField] Text mainGunAmmoText;
        [SerializeField] Text handGunAmmoText;
        [SerializeField] Image mainGunQuality;
        [SerializeField] Image handGunQuality;

        [SerializeField] GunInfo mainGunInfo;
        [SerializeField] GunInfo handGunInfo;

        private Color uncheckedColor = new Color(0,0,0,0.4f);
        private Color checkedColor = new Color(0.7f,0.7f,0.7f,0.4f);

        protected sealed override void Init()
        {
            base.Init();
            playerInfo = networkMediator.GetPlayerInfo;
    
            mainGun = transform.Find("Point/BottomMiddleCenter/Container/MainGunCube");
            handGun = transform.Find("Point/BottomMiddleCenter/Container/HandGunCube");
            mainGunCube = mainGun.GetComponent<Button>();
            handGunCube = handGun.GetComponent<Button>();

            mainGunReloadingBar = mainGun.Find("ReloadingBar").GetComponent<Slider>();
            mainGunBG = mainGun.GetComponent<Image>();
            mainGunNameText = mainGun.Find("GunName/GunNameText").GetComponent<Text>();
            mainGunQuality = mainGun.Find("GunName/GunQuality").GetComponent<Image>();
            mainGunAmmoText = mainGun.Find("AmmoText").GetComponent<Text>();
            

            handGunReloadingBar = handGun.Find("ReloadingBar").GetComponent<Slider>();
            handGunBG = handGun.GetComponent<Image>();
            handGunNameText = handGun.Find("GunName/GunNameText").GetComponent<Text>();
            handGunQuality = handGun.Find("GunName/GunQuality").GetComponent<Image>();
            handGunAmmoText = handGun.Find("AmmoText").GetComponent<Text>();

            mainGunBG.color = checkedColor;

            mainGunCube.onClick.AddListener(()=>{
                mainGunBG.color = checkedColor;
                handGunBG.color = uncheckedColor;
            });

            handGunCube.onClick.AddListener(()=>{
                mainGunBG.color = uncheckedColor;
                handGunBG.color = checkedColor;
            });

            //temp
            // Ak47Info ak47Info = new Ak47Info();
            // mainGunInfo = ak47Info;
            //end

            EventMgr.AddListener<PlayerMainGunUpdateNotify>(OnPlayerMainGunUpdate);
            EventMgr.AddListener<PlayerHandGunUpdateNotify>(OnPlayerHandGunUpdate);
            // EventMgr.AddListener<RestorePanelNotify>(OnRestorePanel);
        }

        bool gunFiringColdDown = true;

        void Update(){
            if(gunFiringColdDown){
                if(Input.GetMouseButton(0)){
                    gunFiringColdDown = false;
                    // EventMgr.Broadcast(GameEvents.PlayerShootingNotify);
                    // Invoke("SetGunShootingColdDownReady", mainGunInfo.currentFiringRatePerSecond);
                    //上为错误写法
                    //应为1/(FiringRate/60)
                }
            }
                
        }

        void SetGunShootingColdDownReady(){
            gunFiringColdDown = true;
        }

        void OnPlayerMainGunUpdate(PlayerMainGunUpdateNotify evt) => PlayerMainGunUpdate();
        void PlayerMainGunUpdate(){
            // playerInfo.Get
        }

        void OnPlayerHandGunUpdate(PlayerHandGunUpdateNotify evt) => PlayerHandGunUpdate();
        void PlayerHandGunUpdate(){
            
        }
    }
}

