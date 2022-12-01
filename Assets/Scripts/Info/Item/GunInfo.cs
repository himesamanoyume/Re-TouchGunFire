using SocketProtocol;
public class GunInfo : ItemInfo
{
    string gunName;
    float baseDMG;
    float firingRate;
    float currentFiringRatePerSecond;
    int magazine;
    string coreProp;
    float corePropValue;


    public string GunName { get => gunName; }
    public float BaseDMG { get => baseDMG; }
    public float FiringRate { get => firingRate; }
    public float CurrentFiringRatePerSecond { get => currentFiringRatePerSecond; }
    public int Magazine { get => magazine; }
    public string CoreProp { get => coreProp; }
    public float CorePropValue { get => corePropValue; }
    

    public void Init(GunPack gunPack){
        use = gunPack.Use;
        itemId = gunPack.ItemId;
        block = gunPack.Block;
        gunName = gunPack.GunName;
        itemType = gunPack.ItemType;
        baseDMG = gunPack.BaseDMG;
        firingRate = gunPack.FiringRate;
        currentFiringRatePerSecond = gunPack.CurrentFiringRatePerSecond;
        magazine = gunPack.Magazine;
        coreProp = gunPack.CoreProp;
        corePropValue = gunPack.CorePropValue;
        subProp1 = gunPack.SubProp1;
        subProp1Value = gunPack.SubProp1Value;
        subProp2 = gunPack.SubProp2;
        subProp2Value = gunPack.SubProp2Value;
        subProp3 = gunPack.SubProp3;
        subProp3Value = gunPack.SubProp3Value;
        price = gunPack.Price;
        diamondPrice = price/10000f;
        unlockAllSubPropPrice = price/4f;
        refreshAllPropPrice = price/10f;
    }
}
