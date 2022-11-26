using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketProtocol;
using Google.Protobuf.Collections;
using ReTouchGunFire.Mediators;

public class PlayerInfo : EntityInfo
{
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
    [SerializeField] long diamond;
    public long Diamond
    {
        get { return diamond; }
    }
    [SerializeField] long coin;
    public long Coin
    {
        get { return coin; }
    }

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

    Dictionary<string,GunInfo> arList = new Dictionary<string, GunInfo>();
    Dictionary<string,GunInfo> dmrList = new Dictionary<string, GunInfo>();
    Dictionary<string,GunInfo> smgList = new Dictionary<string, GunInfo>();
    Dictionary<string,GunInfo> sgList = new Dictionary<string, GunInfo>();
    Dictionary<string,GunInfo> mgList = new Dictionary<string, GunInfo>();
    Dictionary<string,GunInfo> hgList = new Dictionary<string, GunInfo>();
    Dictionary<string,EquipmentInfo> armorList = new Dictionary<string, EquipmentInfo>();
    Dictionary<string,EquipmentInfo> headList = new Dictionary<string, EquipmentInfo>();
    Dictionary<string,EquipmentInfo> handList = new Dictionary<string, EquipmentInfo>();
    Dictionary<string,EquipmentInfo> legList = new Dictionary<string, EquipmentInfo>();
    Dictionary<string,EquipmentInfo> kneeList = new Dictionary<string, EquipmentInfo>();
    Dictionary<string,EquipmentInfo> bootsList = new Dictionary<string, EquipmentInfo>();

    public void UpdatePlayerGunInfoCallback(RepeatedField<GunPack> gunPacks){
        foreach (GunPack item in gunPacks)
        {
            switch(item.GunType){
                case "AR":
                    UpdatePlayerGunInfoList(arList, item);
                break;
                case "DMR":
                    UpdatePlayerGunInfoList(dmrList, item);
                break;
                case "SMG":
                    UpdatePlayerGunInfoList(smgList, item);
                break;
                case "SG":
                    UpdatePlayerGunInfoList(sgList, item);
                break;
                case "MG":
                    UpdatePlayerGunInfoList(mgList, item);
                break;
                case "HG":
                    UpdatePlayerGunInfoList(hgList, item);
                break;
                default:
                    Debug.LogWarning("不正常情况");
                break;
            }
        }
    }

    public void UpdatePlayerEquipmentInfoCallback(RepeatedField<EquipmentPack> equipmentPacks){
        foreach (EquipmentPack item in equipmentPacks)
        {
            switch(item.EquipmentType){
                case "Armor":
                    UpdateEquipmentInfoList(armorList, item);
                break;
                case "Head":
                    UpdateEquipmentInfoList(headList, item);
                break;
                case "Hand":
                    UpdateEquipmentInfoList(handList, item);
                break;
                case "Leg":
                    UpdateEquipmentInfoList(legList, item);
                break;
                case "Knee":
                    UpdateEquipmentInfoList(kneeList, item);
                break;
                case "Boots":
                    UpdateEquipmentInfoList(bootsList, item);
                break;
                default:
                    Debug.LogWarning("不正常情况");
                break;
            }
        }
    }

    void UpdatePlayerGunInfoList(Dictionary<string,GunInfo> list, GunPack gunPack){
        if (list.TryGetValue(gunPack.GunName, out GunInfo gunInfo))
        {
            gunInfo.Init(gunPack);
        }else
        {
            GunInfo newGunInfo = new GunInfo();
            newGunInfo.Init(gunPack);
            list.Add(gunPack.GunName, newGunInfo);
        }
    }

    void UpdateEquipmentInfoList(Dictionary<string,EquipmentInfo> list, EquipmentPack equipmentPack){
        if (list.TryGetValue(equipmentPack.EquipmentName, out EquipmentInfo equipmentInfo))
        {
            equipmentInfo.Init(equipmentPack);
        }else
        {
            EquipmentInfo newEquipmentInfo = new EquipmentInfo();
            newEquipmentInfo.Init(equipmentPack);
            list.Add(equipmentPack.EquipmentName, newEquipmentInfo);
        }
    }
}
