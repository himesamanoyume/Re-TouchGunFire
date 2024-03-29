using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;

namespace ReTouchGunFire.PanelInfo{
    public sealed class BattleGunInfoPanelInfo : UIInfo
    {

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
        // [SerializeField] Image mainGunQuality;
        // [SerializeField] Image handGunQuality;
        [SerializeField] Button mainGunReloadButton;
        [SerializeField] Button handGunReloadButton;


        [SerializeField] GunInfo mainGunInfo;
        [SerializeField] int standardMainGunAmmo;
        [SerializeField] int currentMainGunAmmo;
        [SerializeField] int currentMainGunAllAmmo;
        public bool isMainGun = true;
        [SerializeField] GunInfo handGunInfo;
        [SerializeField] int standardHandGunAmmo;
        [SerializeField] int currentHandGunAmmo;
        [SerializeField] int currentHandGunAllAmmo;
        public bool isHandGun = false;

        [SerializeField] bool isReloading;

        private Color uncheckedColor = new Color(0,0,0,0.4f);
        private Color checkedColor = new Color(0.7f,0.7f,0.7f,0.4f);

        protected sealed override void Init()
        {
            base.Init();
            playerInfo = networkMediator.GetPlayerInfo;
    
            mainGun = transform.Find("Point/BottomMiddleCenter/Container/MainGunCube");
            handGun = transform.Find("Point/BottomMiddleCenter/Container/HandGunCube");
            mainGunCube = mainGun.Find("ButtonCube").GetComponent<Button>();
            handGunCube = handGun.Find("ButtonCube").GetComponent<Button>();

            mainGunReloadingBar = mainGun.Find("ReloadingBar").GetComponent<Slider>();
            mainGunBG = mainGun.GetComponent<Image>();
            mainGunNameText = mainGun.Find("GunName/GunNameText").GetComponent<Text>();
            // mainGunQuality = mainGun.Find("GunName/GunQuality").GetComponent<Image>();
            mainGunAmmoText = mainGun.Find("AmmoText").GetComponent<Text>();
            mainGunReloadButton = mainGun.Find("ReloadingCube").GetComponent<Button>();

            handGunReloadingBar = handGun.Find("ReloadingBar").GetComponent<Slider>();
            handGunBG = handGun.GetComponent<Image>();
            handGunNameText = handGun.Find("GunName/GunNameText").GetComponent<Text>();
            // handGunQuality = handGun.Find("GunName/GunQuality").GetComponent<Image>();
            handGunAmmoText = handGun.Find("AmmoText").GetComponent<Text>();
            handGunReloadButton = handGun.Find("ReloadingCube").GetComponent<Button>();

            mainGunBG.color = checkedColor;

            

            mainGunCube.onClick.AddListener(()=>{
                if (!isReloading)
                {
                    mainGunBG.color = checkedColor;
                    handGunBG.color = uncheckedColor;
                    isMainGun = true;
                    isHandGun = false;
                    if (currentMainGunAmmo < standardMainGunAmmo)
                    {
                        mainGunReloadButton.gameObject.SetActive(true);
                    }
                    handGunReloadButton.gameObject.SetActive(false);
                }
            });

            handGunCube.onClick.AddListener(()=>{
                if (!isReloading)
                {
                    mainGunBG.color = uncheckedColor;
                    handGunBG.color = checkedColor;
                    isMainGun = false;
                    isHandGun = true;
                    if (currentHandGunAmmo < standardHandGunAmmo)
                    {
                        handGunReloadButton.gameObject.SetActive(true);
                    }
                    mainGunReloadButton.gameObject.SetActive(false);
                }
            });

            mainGunReloadButton.onClick.AddListener(()=>{
                isReloading = true;
                gunFiringColdDown = false;
            });
            handGunReloadButton.onClick.AddListener(()=>{
                isReloading = true;
                gunFiringColdDown = false;
            });

            mainGunReloadButton.gameObject.SetActive(false);
            handGunReloadButton.gameObject.SetActive(false);

            EventMgr.AddListener<PlayerMainGunUpdateNotify>(OnPlayerMainGunUpdate);
            EventMgr.AddListener<PlayerHandGunUpdateNotify>(OnPlayerHandGunUpdate);
            EventMgr.AddListener<PlayerRayHitEnemy>(OnPlayerRayHitEnemy);
            // EventMgr.AddListener<RestorePanelNotify>(OnRestorePanel);
        }

        bool gunFiringColdDown = true;

        void OnPlayerRayHitEnemy(PlayerRayHitEnemy evt) => PlayerRayHitEnemy();
        void PlayerRayHitEnemy(){
            
            // Debug.Log("gunFiring");
            if (isMainGun)
            {
                if (currentMainGunAmmo>0)
                {
                    if (gunFiringColdDown)
                    {
                        gunFiringColdDown = false;
                        currentMainGunAmmo -= 1;
                    }
                    
                    // EventMgr.Broadcast(GameEvents.PlayerShootingNotify);
                    if (currentMainGunAmmo < standardMainGunAmmo)
                    {
                        if (currentMainGunAllAmmo > 0)
                        {
                            mainGunReloadButton.gameObject.SetActive(true);
                        }
                    }
                    Invoke("SetGunShootingColdDownReady", mainGunInfo.CurrentFiringRatePerSecond);
                }
            }else if(isHandGun){
                if (currentHandGunAmmo>0)
                {
                    if (gunFiringColdDown)
                    {
                        gunFiringColdDown = false;
                        currentHandGunAmmo -= 1;
                    }        
                    
                    // EventMgr.Broadcast(GameEvents.PlayerShootingNotify);
                    if (currentHandGunAmmo < standardHandGunAmmo)
                    {
                        if (currentHandGunAllAmmo > 0)
                        {
                            handGunReloadButton.gameObject.SetActive(true);
                        }
                    }
                    Invoke("SetGunShootingColdDownReady", handGunInfo.CurrentFiringRatePerSecond);
                }
            }      
        }

        void Update(){
            if(gunFiringColdDown){
                
                if(Input.GetMouseButton(0) && currentHandGunAmmo > 0 && isHandGun || Input.GetMouseButton(0) && currentMainGunAmmo > 0 && isMainGun){
                    EventMgr.Broadcast(GameEvents.PlayerShootingRayNotify);
                }
            }

            if (mainGun!=null && handGun!=null)
            {
                mainGunAmmoText.text = currentMainGunAmmo+"/"+currentMainGunAllAmmo;
                handGunAmmoText.text = currentHandGunAmmo+"/" + currentHandGunAllAmmo;
            }
            MainGunReloadingFunc();
            HandGunReloadingFunc();
        }

        void SetGunShootingColdDownReady(){
            if (!isReloading)
            {
                gunFiringColdDown = true;
            } 
        }

        void MainGunReloadingFunc(){
            if (isReloading && isMainGun)
            {
                mainGunReloadingBar.value -= Time.deltaTime;
                if (mainGunReloadingBar.value<=0)
                {
                    isReloading = false;

                    //计算装填弹药至标准数量需要多少子弹
                    int changeCount = standardMainGunAmmo - currentMainGunAmmo;

                    //当备弹需求大于真实总备弹数时
                    if (changeCount > currentMainGunAllAmmo)
                    {
                        currentMainGunAmmo += currentMainGunAllAmmo;
                        currentMainGunAllAmmo = 0;
                    }else
                    {
                        currentMainGunAmmo = standardMainGunAmmo;
                        currentMainGunAllAmmo -= changeCount;
                    }

                    if (currentMainGunAllAmmo<=0)
                    {
                        currentMainGunAllAmmo = 0;
                    }

                    
                    
                    mainGunReloadingBar.value = mainGunReloadingBar.maxValue;
                    mainGunReloadButton.gameObject.SetActive(false);
                    gunFiringColdDown = true;
                }
            }
        }

        void HandGunReloadingFunc(){
            if (isReloading && isHandGun)
            {
                handGunReloadingBar.value -= Time.deltaTime;
                if (handGunReloadingBar.value<=0)
                {
                    isReloading = false;

                    //计算装填弹药至标准数量需要多少子弹
                    int changeCount = standardHandGunAmmo - currentHandGunAmmo;

                    //当备弹需求大于真实总备弹数时
                    if (changeCount > currentHandGunAllAmmo)
                    {
                        currentHandGunAmmo += currentHandGunAllAmmo;
                        currentHandGunAllAmmo = 0;
                    }else
                    {
                        currentHandGunAmmo = standardHandGunAmmo;
                        currentHandGunAllAmmo -= changeCount;
                    }

                    if (currentHandGunAllAmmo<=0)
                    {
                        currentHandGunAllAmmo = 0;
                    }

                    handGunReloadingBar.value = handGunReloadingBar.maxValue;
                    handGunReloadButton.gameObject.SetActive(false);
                    gunFiringColdDown = true;
                }
            }
        }

        void OnPlayerMainGunUpdate(PlayerMainGunUpdateNotify evt) => PlayerMainGunUpdate();
        void PlayerMainGunUpdate(){
            if (playerInfo.allItemDict.TryGetValue(playerInfo.mainGunId, out ItemInfo itemInfo))
            {
                mainGunInfo = itemInfo as GunInfo;
                mainGunNameText.text = mainGunInfo.GunName;
                standardMainGunAmmo = mainGunInfo.Magazine;
                currentMainGunAmmo = mainGunInfo.Magazine;
                currentMainGunAllAmmo = mainGunInfo.MaxMagazine;
                mainGunAmmoText.text = currentMainGunAmmo+"/"+currentMainGunAllAmmo;
                mainGunReloadingBar.maxValue = mainGunInfo.ReloadingTime;
                mainGunReloadingBar.value = mainGunReloadingBar.maxValue;

            }
        }

        void OnPlayerHandGunUpdate(PlayerHandGunUpdateNotify evt) => PlayerHandGunUpdate();
        void PlayerHandGunUpdate(){
            if (playerInfo.allItemDict.TryGetValue(playerInfo.handGunId, out ItemInfo itemInfo))
            {
                handGunInfo = itemInfo as GunInfo;
                handGunNameText.text = handGunInfo.GunName;
                standardHandGunAmmo = handGunInfo.Magazine;
                currentHandGunAmmo = handGunInfo.Magazine;
                currentHandGunAllAmmo = handGunInfo.MaxMagazine;
                handGunAmmoText.text = currentHandGunAmmo+"/" + currentHandGunAllAmmo;
                handGunReloadingBar.maxValue = handGunInfo.ReloadingTime;
                handGunReloadingBar.value = mainGunReloadingBar.maxValue;

            }
        }

        public void BeatEnemyCallback(){
            
            float per = Random.Range(0f, 1f);
            if (per>= 0.65f)
            {
                currentHandGunAllAmmo += standardHandGunAmmo * 2;
                currentMainGunAllAmmo += standardMainGunAmmo * 2;
            }else if(currentMainGunAllAmmo <= standardMainGunAmmo)
            {
                if (per>= 0.3f)
                {
                    currentMainGunAllAmmo += standardMainGunAmmo * 3;
                }
            }else if(currentHandGunAllAmmo <= standardHandGunAmmo)
            {
                if (per>= 0.3f)
                {
                    currentHandGunAllAmmo += standardHandGunAmmo * 3;
                }
            }
        }

        public void AttackEndAndLeaveCallback(){
            currentHandGunAllAmmo = standardHandGunAmmo * 15;
            currentMainGunAllAmmo = standardMainGunAmmo * 15;
        }
    }
}

