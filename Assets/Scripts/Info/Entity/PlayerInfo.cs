using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using Google.Protobuf.Collections;
using ReTouchGunFire.Mediators;

public class PlayerInfo : EntityInfo
{
    #region info
    [SerializeField] int uid;
    public int Uid {
        get { return uid; }
    }
    [SerializeField] string playerName;
    public string PlayerName
    {
        get { return playerName; }
    }
    [SerializeField] int level;
    public int Level
    {
        get { return level; }
    }
    [SerializeField] float currentExp;
    public float CurrentExp
    {
        get { return currentExp; }
    }
    [SerializeField] float maxExp;
    public float MaxExp
    {
        get { return maxExp; }
    }
    [SerializeField] float currentHealth;
    [SerializeField] float maxHealth;
    [SerializeField] float currentArmor;
    [SerializeField] float maxArmor;
    public float CurrentHealth
    {
        get { return currentHealth; }
    }
    public float CurrentArmor
    {
        get { return currentArmor; }
    }
    public float MaxHealth
    {
        get { return maxHealth; }
    }
    public float MaxArmor
    {
        get { return maxArmor; }
    }
    [SerializeField] float baseDmgBonus;
    public float BaseDmgBonus
    {
        get { return baseDmgBonus; }
    }
    [SerializeField] float critDmgRateBonus;
    public float CritDmgRateBonus 
    {
        get { return critDmgRateBonus; }
    }
    [SerializeField] float critDmgBonus;
    public float CritDmgBonus
    {
        get { return critDmgBonus; }
    }
    [SerializeField] float headshotDmgBonus;
    public float HeadshotDmgRateBonus
    {
        get { return headshotDmgBonus; }
    }
    [SerializeField] float pRateBonus;//穿透率加成
    public float PRateBonus
    {
        get { return pRateBonus; }
    }
    [SerializeField] float abeBonus;//破甲效率加成
    public float AbeBonus
    {
        get { return abeBonus; }
    }
    [SerializeField] float arDmgBonus;
    public float ArDmgBonus
    {
        get { return arDmgBonus; }
    }
    [SerializeField] float dmrDmgBonus;
    public float DmrDmgBonus
    {
        get { return dmrDmgBonus; }
    }
    [SerializeField] float smgDmgBonus;
    public float SmgDmgBonus
    {
        get { return smgDmgBonus; }
    }
    [SerializeField] float sgDmgBonus;
    public float SgDmgBonus
    {
        get { return sgDmgBonus; }
    }
    [SerializeField] float mgDmgBonus;
    public float MgDmgBonus
    {
        get { return mgDmgBonus; }
    }
    [SerializeField] float srDmgBonus;
    public float SrDmgBonus
    {
        get { return srDmgBonus; }
    }
    [SerializeField] float hgDmgBonus;
    public float HgDmgBonus
    {
        get { return hgDmgBonus; }
    }
    [SerializeField] float diamond;
    public float Diamond
    {
        get { return diamond; }
    }
    [SerializeField] long coin;
    public long Coin
    {
        get { return coin; }
    }
    #endregion

    private void Start() {
        base.Init();
        regenerationRequest = (RegenerationRequest)requestMediator.GetRequest(ActionCode.Regeneration);
        EventMgr.AddListener<MainSceneBeginNotify>(OnMainSceneBegin);
    }

    void OnMainSceneBegin(MainSceneBeginNotify evt) => MainSceneBegin();
    void MainSceneBegin(){
        InvokeRepeating("Regeneration", 0, 1f/10f);
    }

    public void UpdatePlayerInfo(UpdatePlayerInfoPack updatePlayerInfoPack){
        uid = updatePlayerInfoPack.Uid;
        playerName = updatePlayerInfoPack.PlayerName;
        level = updatePlayerInfoPack.Level;
        currentExp = updatePlayerInfoPack.CurrentExp;
        maxExp = updatePlayerInfoPack.MaxExp;
        currentHealth = updatePlayerInfoPack.CurrentHealth;
        maxHealth = updatePlayerInfoPack.MaxHealth;
        currentArmor = updatePlayerInfoPack.CurrentArmor;
        maxArmor = updatePlayerInfoPack.MaxArmor;
        baseDmgBonus = updatePlayerInfoPack.BaseDmgRateBonus;
        critDmgRateBonus  = updatePlayerInfoPack.CritDmgRateBonus;
        critDmgBonus = updatePlayerInfoPack.CritDmgBonus;
        headshotDmgBonus = updatePlayerInfoPack.HeadshotDmgBonus;
        pRateBonus = updatePlayerInfoPack.PRateBonus;
        abeBonus = updatePlayerInfoPack.AbeBonus;
        arDmgBonus = updatePlayerInfoPack.ArDmgBonus;
        dmrDmgBonus = updatePlayerInfoPack.DmrDmgBonus;
        smgDmgBonus = updatePlayerInfoPack.SmgDmgBonus;
        sgDmgBonus = updatePlayerInfoPack.SgDmgBonus;
        mgDmgBonus = updatePlayerInfoPack.MgDmgBonus;
        srDmgBonus = updatePlayerInfoPack.SrDmgBonus;
        hgDmgBonus = updatePlayerInfoPack.HgDmgBonus;
        diamond = updatePlayerInfoPack.Diamond;
        coin = updatePlayerInfoPack.Coin;

        playerInfoUpdateCallback?.Invoke(updatePlayerInfoPack);

    }

    public delegate void PlayerInfoUpdateCallback(UpdatePlayerInfoPack updatePlayerInfoPack);
    public PlayerInfoUpdateCallback playerInfoUpdateCallback;


    RegenerationRequest regenerationRequest;
    void Regeneration(){
        // Debug.Log("Regeneration");
        if ((currentHealth<maxHealth && currentHealth > 0) || (currentArmor < maxArmor && currentArmor > 0))
        {
            //每1秒回复10次最大生命值的(1/20)/10
            regenerationRequest.SendRequest();
        }
    }

    Dictionary<string,ItemInfo> arDict = new Dictionary<string, ItemInfo>();
    Dictionary<string,ItemInfo> dmrDict = new Dictionary<string, ItemInfo>();
    Dictionary<string,ItemInfo> smgDict = new Dictionary<string, ItemInfo>();
    Dictionary<string,ItemInfo> sgDict = new Dictionary<string, ItemInfo>();
    Dictionary<string,ItemInfo> mgDict = new Dictionary<string, ItemInfo>();
    Dictionary<string,ItemInfo> hgDict = new Dictionary<string, ItemInfo>();
    Dictionary<string,ItemInfo> armorDict = new Dictionary<string, ItemInfo>();
    Dictionary<string,ItemInfo> headDict = new Dictionary<string, ItemInfo>();
    Dictionary<string,ItemInfo> handDict = new Dictionary<string, ItemInfo>();
    Dictionary<string,ItemInfo> legDict = new Dictionary<string, ItemInfo>();
    Dictionary<string,ItemInfo> kneeDict = new Dictionary<string, ItemInfo>();
    Dictionary<string,ItemInfo> bootsDict = new Dictionary<string, ItemInfo>();

    // public List<GunInfo> GetGunInfoList(Dictionary<string, GunInfo> gunDict){
    //     List<GunInfo> list = new List<GunInfo>();
    //     foreach (var item in gunDict)
    //     {
    //         list.Add(item.Value);
    //     }
    //     return list;
    // }

    // public List<EquipmentInfo> GetEquipmentInfoList(Dictionary<string, EquipmentInfo> equipmentDict){
    //     List<EquipmentInfo> list = new List<EquipmentInfo>();
    //     foreach (var item in equipmentDict)
    //     {
    //         list.Add(item.Value);
    //     }
    //     return list;
    // }

    public List<ItemInfo> GetItemInfoList(EItemList eItemList){
        switch (eItemList)
        {
            case EItemList.ar:
                return GetItemInfo(arDict);
            case EItemList.dmr:
                return GetItemInfo(dmrDict);
            case EItemList.smg:
                return GetItemInfo(smgDict);
            case EItemList.sg:
                return GetItemInfo(sgDict);
            case EItemList.mg:
                return GetItemInfo(mgDict);
            case EItemList.hg:
                return GetItemInfo(hgDict);
            case EItemList.armor:
                return GetItemInfo(armorDict);
            case EItemList.head:
                return GetItemInfo(headDict);
            case EItemList.hand:
                return GetItemInfo(handDict);
            case EItemList.leg:
                return GetItemInfo(legDict);
            case EItemList.knee:
                return GetItemInfo(kneeDict);
            case EItemList.boots:
                return GetItemInfo(bootsDict);
        }
        return null;
    }

    List<ItemInfo> GetItemInfo(Dictionary<string, ItemInfo> itemDict){
        List<ItemInfo> list = new List<ItemInfo>();
        foreach (var item in itemDict)
        {
            list.Add(item.Value);
        }
        return list;
    }

    public void UpdatePlayerGunInfoCallback(RepeatedField<GunPack> gunPacks){
        foreach (GunPack item in gunPacks)
        {
            // Debug.Log(item);
            switch(item.ItemType){
                case "AR":
                    UpdatePlayerGunInfoList(arDict, item);
                break;
                case "DMR":
                    UpdatePlayerGunInfoList(dmrDict, item);
                break;
                case "SMG":
                    UpdatePlayerGunInfoList(smgDict, item);
                break;
                case "SG":
                    UpdatePlayerGunInfoList(sgDict, item);
                break;
                case "MG":
                    UpdatePlayerGunInfoList(mgDict, item);
                break;
                case "HG":
                    UpdatePlayerGunInfoList(hgDict, item);
                break;
                default:
                    Debug.LogWarning("不正常情况");
                break;
            }
        }
        EventMgr.Broadcast(GameEvents.UpdateItemInfoListNotify);
    }

    public void UpdatePlayerEquipmentInfoCallback(RepeatedField<EquipmentPack> equipmentPacks){
        foreach (EquipmentPack item in equipmentPacks)
        {
            // Debug.Log(item);
            switch(item.ItemType){
                case "Armor":
                    UpdateEquipmentInfoList(armorDict, item);
                break;
                case "Head":
                    UpdateEquipmentInfoList(headDict, item);
                break;
                case "Hand":
                    UpdateEquipmentInfoList(handDict, item);
                break;
                case "Leg":
                    UpdateEquipmentInfoList(legDict, item);
                break;
                case "Knee":
                    UpdateEquipmentInfoList(kneeDict, item);
                break;
                case "Boots":
                    UpdateEquipmentInfoList(bootsDict, item);
                break;
                default:
                    Debug.LogWarning("不正常情况");
                break;
            }
        }
        EventMgr.Broadcast(GameEvents.UpdateItemInfoListNotify);
    }

    void UpdatePlayerGunInfoList(Dictionary<string,ItemInfo> list, GunPack gunPack){
        if (list.TryGetValue(gunPack.GunName, out ItemInfo gunInfo))
        {
            ((GunInfo)gunInfo).Init(gunPack);
        }else
        {
            GunInfo newGunInfo = new GunInfo();
            newGunInfo.Init(gunPack);
            list.Add(gunPack.GunName, newGunInfo);
        }
    }

    void UpdateEquipmentInfoList(Dictionary<string,ItemInfo> list, EquipmentPack equipmentPack){
        if (list.TryGetValue(equipmentPack.EquipmentName, out ItemInfo equipmentInfo))
        {
            ((EquipmentInfo)equipmentInfo).Init(equipmentPack);
        }else
        {
            EquipmentInfo newEquipmentInfo = new EquipmentInfo();
            newEquipmentInfo.Init(equipmentPack);
            list.Add(equipmentPack.EquipmentName, newEquipmentInfo);
        }
    }
}
