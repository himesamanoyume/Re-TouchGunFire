using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReTouchGunFire.Mediators;
using SocketProtocol;


namespace ReTouchGunFire.PanelInfo{
    public sealed class ShopPanelInfo : UIInfo
    {
        [SerializeField] ShoppingRequest shoppingRequest;
        [SerializeField] EItemList currentItemList;
        bool currentIsGun = true;
        private void Start() {
            Name = "ShopPanelInfo";
            Init();
        }
        protected sealed override void Init()
        {
            base.Init();

            point = transform.Find("Point").GetComponent<Button>();
            point.onClick.AddListener(()=>{
                panelMediator.PopPanel(false);
                if(panelMediator.CheckPanelList())
                    EventMgr.Broadcast(GameEvents.CloseBackButtonPanelNotify);
            });

            InitLeftScrollViewContentPart();
            InitRightItemInfoScrollViewContent();
            InitRightItemScrollViewContent();
            InitRightTop();

            // List<ItemInfo> test = networkMediator.GetItemInfoList(EItemList.ar);
            // foreach (GunInfo item in test)
            // {
            //     Debug.Log(item.GunName);
            // }
            ShowItemList(networkMediator.GetItemInfoList(EItemList.ar), true, EItemList.ar);
            shoppingRequest = (ShoppingRequest)requestMediator.GetRequest(ActionCode.Shopping);
            EventMgr.AddListener<UpdateItemInfoListNotify>(OnUpdateItemInfoList);
        }

        void ShowItemList(List<ItemInfo> list, bool isGun , EItemList currentItemList){
            for (int i = 1; i < rightItemScrollViewContent.childCount; i++)
            {
                Destroy(rightItemScrollViewContent.GetChild(i).gameObject);
            }
            this.currentItemList = currentItemList;
            currentIsGun = isGun;
            foreach (ItemInfo item in list)
            {
                GameObject newItemBar = Instantiate(itemBarTemplate, rightItemScrollViewContent);
                newItemBar.AddComponent<ItemBarInfo>().InitInfo(item, isGun);
                newItemBar.SetActive(true);
                newItemBar.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(()=>{
                    //show detail info
                    if (isGun)
                    {
                        ShowGunModeInfo((GunInfo)item);
                    }else
                    {
                        ShowEquipmentModeInfo((EquipmentInfo)item);
                    }
                    ShowButtonList(item);
                    buyButton.onClick.AddListener(()=>{
                        if (networkMediator.GetPlayerInfo.Coin < item.Price)
                        {
                            panelMediator.ShowTwiceConfirmPanel("金币不足,是否要花费"+ item.DiamondPrice+"钻石购买该物品?",7f, ()=>{
                                shoppingRequest.SendRequest(item.DiamondPrice, item.BaseUid, true);
                            });
                        }else
                        {
                            panelMediator.ShowTwiceConfirmPanel("确认要花费"+ item.Price+"金币购买该物品吗?",7f, ()=>{
                                shoppingRequest.SendRequest(item.Price, item.BaseUid);
                            });
                        }
                        
                    });
                    equipButton.onClick.AddListener(()=>{
                        
                    });
                    refreshButton.onClick.AddListener(()=>{
                        
                    });
                    unlockButton.onClick.AddListener(()=>{
                        
                    });
                });
            }
            if (isGun)
            {
                ShowGunModeInfo((GunInfo)list[0]);
            }else
            {
                ShowEquipmentModeInfo((EquipmentInfo)list[0]);
            }
            ShowButtonList(list[0]);
        }

        void OnUpdateItemInfoList(UpdateItemInfoListNotify evt) => UpdateItemInfoList();

        void UpdateItemInfoList(){
            ShowItemList(networkMediator.GetItemInfoList(currentItemList), currentIsGun, currentItemList);
        }

        void ShowButtonList(ItemInfo itemInfo){
            if(itemInfo.Block){
                buyButton.gameObject.SetActive(true);
                buyButton.onClick.AddListener(()=>{
                    if (networkMediator.GetPlayerInfo.Coin < itemInfo.Price)
                    {
                        panelMediator.ShowTwiceConfirmPanel("金币不足,是否要花费"+ itemInfo.DiamondPrice+"钻石购买该物品?",7f, ()=>{
                            shoppingRequest.SendRequest(itemInfo.DiamondPrice, itemInfo.BaseUid, true);
                        });
                    }else
                    {
                        panelMediator.ShowTwiceConfirmPanel("确认要花费"+ itemInfo.Price+"金币购买该物品吗?",7f, ()=>{
                            shoppingRequest.SendRequest(itemInfo.Price, itemInfo.BaseUid);
                        });
                    }
                    
                });
                equipButton.gameObject.SetActive(false);
                refreshButton.gameObject.SetActive(false);
                unlockButton.gameObject.SetActive(false);
            }else
            {
                buyButton.gameObject.SetActive(false);
                equipButton.gameObject.SetActive(true);
                refreshButton.gameObject.SetActive(true);
                unlockButton.gameObject.SetActive(true);
            }
        }

        void ShowGunModeInfo(GunInfo gunInfo){
            itemNameText.text = gunInfo.GunType;
            itemNameValueText.text = gunInfo.GunName;
            itemSuit.gameObject.SetActive(false);
            itemSuitEffect1.gameObject.SetActive(false);
            itemSuitEffect2.gameObject.SetActive(false);
            itemSuitEffect3.gameObject.SetActive(false);
            itemBaseDMG.gameObject.SetActive(true);
            itemBaseDMGValueText.text = gunInfo.BaseDMG.ToString("f1");
            itemFiringRate.gameObject.SetActive(true);
            itemFiringRateValueText.text = gunInfo.FiringRate.ToString();
            itemMagazine.gameObject.SetActive(true);
            itemMagazineValueText.text = gunInfo.Magazine.ToString();
            itemCoreProp.gameObject.SetActive(true);
            itemCorePropValueText.text = gunInfo.CoreProp;
            itemCorePropValueSlider.maxValue = 0.15f;
            itemCorePropValueSlider.value = gunInfo.CorePropValue;
            // itemSubProp1.gameObject.SetActive(true);
            itemSubProp1ValueText.text = gunInfo.SubProp1;
            itemSubProp1ValueSlider.maxValue = 0.1f;
            itemSubProp1ValueSlider.value = gunInfo.SubProp1Value;
            // itemSubProp2.gameObject.SetActive(true);
            itemSubProp2ValueText.text = gunInfo.SubProp2;
            itemSubProp2ValueSlider.maxValue = 0.1f;
            itemSubProp2ValueSlider.value = gunInfo.SubProp2Value;
            // itemSubProp3.gameObject.SetActive(true);
            itemSubProp3ValueText.text = gunInfo.SubProp3;
            itemSubProp3ValueSlider.maxValue = 0.1f;
            itemSubProp3ValueSlider.value = gunInfo.SubProp3Value;
            itemTalent1.gameObject.SetActive(false);
            itemTalent2.gameObject.SetActive(false);
        }

        void ShowEquipmentModeInfo(EquipmentInfo equipmentInfo){
            itemNameText.text = equipmentInfo.EquipmentType;
            itemNameValueText.text = equipmentInfo.EquipmentName;
            itemSuit.gameObject.SetActive(true);
            itemSuitValueText.text = equipmentInfo.EquipmentSuit;
            itemSuitEffect1.gameObject.SetActive(false);
            itemSuitEffect2.gameObject.SetActive(false);
            itemSuitEffect3.gameObject.SetActive(false);
            itemBaseDMG.gameObject.SetActive(false);
            itemFiringRate.gameObject.SetActive(false);
            itemMagazine.gameObject.SetActive(false);
            itemCoreProp.gameObject.SetActive(false);
            // itemSubProp1.gameObject.SetActive(true);
            itemSubProp1ValueText.text = equipmentInfo.SubProp1;
            itemSubProp1ValueSlider.maxValue = 0.1f;
            itemSubProp1ValueSlider.value = equipmentInfo.SubProp1Value;
            // itemSubProp2.gameObject.SetActive(true);
            itemSubProp2ValueText.text = equipmentInfo.SubProp2;
            itemSubProp2ValueSlider.maxValue = 0.1f;
            itemSubProp2ValueSlider.value = equipmentInfo.SubProp2Value;
            // itemSubProp3.gameObject.SetActive(true);
            itemSubProp3ValueText.text = equipmentInfo.SubProp3;
            itemSubProp3ValueSlider.maxValue = 0.1f;
            itemSubProp3ValueSlider.value = equipmentInfo.SubProp3Value;
            itemTalent1.gameObject.SetActive(true);
            itemTalent1ValueText.text = equipmentInfo.Talent1.ToString();
            itemTalent2.gameObject.SetActive(true);
            itemTalent2ValueText.text = equipmentInfo.Talent2.ToString();
        }

        [SerializeField] Button point;

        [SerializeField] Transform leftScrollViewContent;
        [SerializeField] Button arButton;
        [SerializeField] Button dmrButton;
        [SerializeField] Button smgButton;
        [SerializeField] Button sgButton;
        [SerializeField] Button mgButton;
        [SerializeField] Button hgButton;
        [SerializeField] Button armorButton;
        [SerializeField] Button headButton;
        [SerializeField] Button handButton;
        [SerializeField] Button legButton;
        [SerializeField] Button kneeButton;
        [SerializeField] Button bootsButton;
        void InitLeftScrollViewContentPart(){
            leftScrollViewContent = transform.Find("Point/Left/Bottom/Scroll View/Viewport/Content");
            arButton = leftScrollViewContent.Find("AR_Button").GetComponent<Button>();
            dmrButton = leftScrollViewContent.Find("DMR_Button").GetComponent<Button>();
            smgButton = leftScrollViewContent.Find("SMG_Button").GetComponent<Button>();
            sgButton = leftScrollViewContent.Find("SG_Button").GetComponent<Button>();
            mgButton = leftScrollViewContent.Find("MG_Button").GetComponent<Button>();
            hgButton = leftScrollViewContent.Find("HG_Button").GetComponent<Button>();
            armorButton = leftScrollViewContent.Find("Armor_Button").GetComponent<Button>();
            headButton = leftScrollViewContent.Find("Head_Button").GetComponent<Button>();
            handButton = leftScrollViewContent.Find("Hand_Button").GetComponent<Button>();
            legButton = leftScrollViewContent.Find("Leg_Button").GetComponent<Button>();
            kneeButton = leftScrollViewContent.Find("Knee_Button").GetComponent<Button>();
            bootsButton = leftScrollViewContent.Find("Boots_Button").GetComponent<Button>();

            //
            arButton.onClick.AddListener(()=>{
                ShowItemList(networkMediator.GetItemInfoList(EItemList.ar), true, EItemList.ar);
            });
            dmrButton.onClick.AddListener(()=>{
                ShowItemList(networkMediator.GetItemInfoList(EItemList.dmr), true, EItemList.dmr);
            });
            smgButton.onClick.AddListener(()=>{
                ShowItemList(networkMediator.GetItemInfoList(EItemList.smg), true, EItemList.smg);
            });
            sgButton.onClick.AddListener(()=>{
                ShowItemList(networkMediator.GetItemInfoList(EItemList.sg), true, EItemList.sg);
            });
            mgButton.onClick.AddListener(()=>{
                ShowItemList(networkMediator.GetItemInfoList(EItemList.mg), true, EItemList.mg);
            });
            hgButton.onClick.AddListener(()=>{
                ShowItemList(networkMediator.GetItemInfoList(EItemList.hg), true, EItemList.hg);
            });
            armorButton.onClick.AddListener(()=>{
                ShowItemList(networkMediator.GetItemInfoList(EItemList.armor), false, EItemList.armor);
            });
            headButton.onClick.AddListener(()=>{
                ShowItemList(networkMediator.GetItemInfoList(EItemList.head), false, EItemList.head);
            });
            handButton.onClick.AddListener(()=>{
                ShowItemList(networkMediator.GetItemInfoList(EItemList.hand), false, EItemList.hand);
            });
            legButton.onClick.AddListener(()=>{
                ShowItemList(networkMediator.GetItemInfoList(EItemList.leg), false, EItemList.leg);
            });
            kneeButton.onClick.AddListener(()=>{
                ShowItemList(networkMediator.GetItemInfoList(EItemList.knee), false, EItemList.knee);
            });
            bootsButton.onClick.AddListener(()=>{
                ShowItemList(networkMediator.GetItemInfoList(EItemList.boots), false, EItemList.boots);
            });
            //end
        }

        [SerializeField] Transform rightItemScrollViewContent;
        [SerializeField] GameObject itemBarTemplate;

        void InitRightItemScrollViewContent(){
            rightItemScrollViewContent = transform.Find("Point/Right/Bottom/Scroll View/Viewport/Content");
            itemBarTemplate = rightItemScrollViewContent.Find("ItemBar").gameObject;
        }

        [SerializeField] Transform rightItemInfoScrollViewContent;
        [SerializeField] Transform itemName;
        [SerializeField] Text itemNameText;
        [SerializeField] Text itemNameValueText;

        [SerializeField] Transform itemSuit;
        [SerializeField] Text itemSuitText;
        [SerializeField] Text itemSuitValueText;

        [SerializeField] Transform itemSuitEffect1;
        [SerializeField] Text itemSuitEffect1Text;
        [SerializeField] Text itemSuitEffect1ValueText;

        [SerializeField] Transform itemSuitEffect2;
        [SerializeField] Text itemSuitEffect2Text;
        [SerializeField] Text itemSuitEffect2ValueText;

        [SerializeField] Transform itemSuitEffect3;
        [SerializeField] Text itemSuitEffect3Text;
        [SerializeField] Text itemSuitEffect3ValueText;

        [SerializeField] Transform itemBaseDMG;
        [SerializeField] Text itemBaseDMGText;
        [SerializeField] Text itemBaseDMGValueText;

        [SerializeField] Transform itemFiringRate;
        [SerializeField] Text itemFiringRateText;
        [SerializeField] Text itemFiringRateValueText;

        [SerializeField] Transform itemMagazine;
        [SerializeField] Text itemMagazineText;
        [SerializeField] Text itemMagazineValueText;

        [SerializeField] Transform itemCoreProp;
        [SerializeField] Text itemCorePropText;
        [SerializeField] Text itemCorePropValueText;
        [SerializeField] Slider itemCorePropValueSlider;

        [SerializeField] Transform itemSubProp1;
        [SerializeField] Text itemSubProp1Text;
        [SerializeField] Text itemSubProp1ValueText;
        [SerializeField] Slider itemSubProp1ValueSlider;

        [SerializeField] Transform itemSubProp2;
        [SerializeField] Text itemSubProp2Text;
        [SerializeField] Text itemSubProp2ValueText;
        [SerializeField] Slider itemSubProp2ValueSlider;

        [SerializeField] Transform itemSubProp3;
        [SerializeField] Text itemSubProp3Text;
        [SerializeField] Text itemSubProp3ValueText;
        [SerializeField] Slider itemSubProp3ValueSlider;

        [SerializeField] Transform itemTalent1;
        [SerializeField] Text itemTalent1Text;
        [SerializeField] Text itemTalent1ValueText;

        [SerializeField] Transform itemTalent2;
        [SerializeField] Text itemTalent2Text;
        [SerializeField] Text itemTalent2ValueText;

        void InitRightItemInfoScrollViewContent(){
            rightItemInfoScrollViewContent = transform.Find("Point/Right/Bottom/ItemInfoDetail/Scroll View/Viewport/Content");

            itemName = rightItemInfoScrollViewContent.Find("ItemName");
            itemNameText = itemName.Find("Text").GetComponent<Text>();
            itemNameValueText = itemName.Find("Value").GetComponent<Text>();

            itemSuit = rightItemInfoScrollViewContent.Find("ItemSuit");
            itemSuitText = itemSuit.Find("Text").GetComponent<Text>();
            itemSuitValueText = itemSuit.Find("Value").GetComponent<Text>();

            itemSuitEffect1 = rightItemInfoScrollViewContent.Find("ItemSuitEffect1");
            itemSuitEffect1Text = itemSuitEffect1.Find("Text").GetComponent<Text>();
            itemSuitEffect1ValueText = itemSuitEffect1.Find("Value").GetComponent<Text>();

            itemSuitEffect2 = rightItemInfoScrollViewContent.Find("ItemSuitEffect2");
            itemSuitEffect2Text = itemSuitEffect2.Find("Text").GetComponent<Text>();
            itemSuitEffect2ValueText = itemSuitEffect2.Find("Value").GetComponent<Text>();

            itemSuitEffect3 = rightItemInfoScrollViewContent.Find("ItemSuitEffect3");
            itemSuitEffect3Text = itemSuitEffect3.Find("Text").GetComponent<Text>();
            itemSuitEffect3ValueText = itemSuitEffect3.Find("Value").GetComponent<Text>();

            itemBaseDMG = rightItemInfoScrollViewContent.Find("ItemBaseDMG");
            itemBaseDMGText = itemBaseDMG.Find("Text").GetComponent<Text>();
            itemBaseDMGValueText = itemBaseDMG.Find("Value").GetComponent<Text>();

            itemFiringRate = rightItemInfoScrollViewContent.Find("ItemFiringRate");
            itemFiringRateText = itemFiringRate.Find("Text").GetComponent<Text>();
            itemFiringRateValueText = itemFiringRate.Find("Value").GetComponent<Text>();

            itemMagazine = rightItemInfoScrollViewContent.Find("ItemMagazine");
            itemMagazineText = itemMagazine.Find("Text").GetComponent<Text>();
            itemMagazineValueText = itemMagazine.Find("Value").GetComponent<Text>();

            itemCoreProp = rightItemInfoScrollViewContent.Find("ItemCoreProp");
            itemCorePropText = itemCoreProp.Find("Text").GetComponent<Text>();
            itemCorePropValueText = itemCoreProp.Find("Value").GetComponent<Text>();
            itemCorePropValueSlider = itemCoreProp.Find("ValueBar").GetComponent<Slider>();

            itemSubProp1 = rightItemInfoScrollViewContent.Find("ItemSubProp1");
            itemSubProp1Text = itemSubProp1.Find("Text").GetComponent<Text>();
            itemSubProp1ValueText = itemSubProp1.Find("Value").GetComponent<Text>();
            itemSubProp1ValueSlider = itemSubProp1.Find("ValueBar").GetComponent<Slider>();

            itemSubProp2 = rightItemInfoScrollViewContent.Find("ItemSubProp2");
            itemSubProp2Text = itemSubProp2.Find("Text").GetComponent<Text>();
            itemSubProp2ValueText = itemSubProp2.Find("Value").GetComponent<Text>();
            itemSubProp2ValueSlider = itemSubProp2.Find("ValueBar").GetComponent<Slider>();

            itemSubProp3 = rightItemInfoScrollViewContent.Find("ItemSubProp3");
            itemSubProp3Text = itemSubProp3.Find("Text").GetComponent<Text>();
            itemSubProp3ValueText = itemSubProp3.Find("Value").GetComponent<Text>();
            itemSubProp3ValueSlider = itemSubProp3.Find("ValueBar").GetComponent<Slider>();

            itemTalent1 = rightItemInfoScrollViewContent.Find("ItemTalent1");
            itemTalent1Text = itemTalent1.Find("Text").GetComponent<Text>();
            itemTalent1ValueText = itemTalent1.Find("Value").GetComponent<Text>();

            itemTalent2 = rightItemInfoScrollViewContent.Find("ItemTalent2");
            itemTalent2Text = itemTalent2.Find("Text").GetComponent<Text>();
            itemTalent2ValueText = itemTalent2.Find("Value").GetComponent<Text>();
        }

        [SerializeField] Transform rightTop;

        [SerializeField] Button buyButton;
        [SerializeField] Button equipButton;
        [SerializeField] Button refreshButton;
        [SerializeField] Button unlockButton;

        void InitRightTop(){
            rightTop = transform.Find("Point/Right/Top");
            buyButton = rightTop.Find("BuyButton").GetComponent<Button>();
            equipButton = rightTop.Find("EquipButton").GetComponent<Button>();
            refreshButton = rightTop.Find("RefreshButton").GetComponent<Button>();
            unlockButton = rightTop.Find("UnlockButton").GetComponent<Button>();


        }
    }
}

