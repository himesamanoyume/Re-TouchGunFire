using SocketProtocol;
public class GunInfo : ItemInfo
{
    string gunName;
    float baseDmg;
    float firingRate;
    float currentFiringRatePerSecond;
    int magazine;
    int maxMagazine;
    string coreProp;
    float corePropValue;
    float reloadingTime;


    public string GunName { get => gunName; }
    public float BaseDmg { get => baseDmg; }
    public float FiringRate { get => firingRate; }
    public float CurrentFiringRatePerSecond { get => currentFiringRatePerSecond; }
    public int Magazine { get => magazine; }
    public int MaxMagazine { get=> maxMagazine; }
    public string CoreProp { get => coreProp; }
    public float CorePropValue { get => corePropValue; }
    public float ReloadingTime { get => reloadingTime; }
    

    public void Init(GunPack gunPack, PlayerInfo playerInfo){
        this.playerInfo = playerInfo;
        use = gunPack.Use;
        itemId = gunPack.ItemId;
        block = gunPack.Block;
        gunName = gunPack.GunName;
        itemType = gunPack.ItemType;
        baseDmg = gunPack.BaseDmg;
        firingRate = gunPack.FiringRate;
        currentFiringRatePerSecond = gunPack.CurrentFiringRatePerSecond;
        magazine = gunPack.Magazine;
        maxMagazine = gunPack.Magazine * 15;
        reloadingTime = gunPack.ReloadingTime;
        coreProp = gunPack.CoreProp;
        corePropValue = gunPack.CorePropValue;
        subProp1 = gunPack.SubProp1;
        subProp1Value = gunPack.SubProp1Value;
        subProp1MaxValue = gunPack.SubProp1MaxValue;
        subProp2 = gunPack.SubProp2;
        subProp2Value = gunPack.SubProp2Value;
        subProp2MaxValue = gunPack.SubProp2MaxValue;
        subProp3 = gunPack.SubProp3;
        subProp3Value = gunPack.SubProp3Value;
        subProp3MaxValue = gunPack.SubProp3MaxValue;
        price = gunPack.Price;
        diamondPrice = price/10000f;
        unlockAllSubPropPrice = price * 0.4f;
        refreshAllPropPrice = price * 0.2f;
        healthBonus = gunPack.HealthBonus;
        baseDmgBonus = gunPack.BaseDmgBonus;
        critDmgRateBonus = gunPack.CritDmgRateBonus;
        critDmgBonus = gunPack.CritDmgBonus;
        headshotDmgBonus = gunPack.HeadshotDmgBonus;
        pRateBonus = gunPack.PRateBonus;
        abeBonus = gunPack.AbeBonus;
        armorBonus = gunPack.ArmorBonus; 
    }
}
