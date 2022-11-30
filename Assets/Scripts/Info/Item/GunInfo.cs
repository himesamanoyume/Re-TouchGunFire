using SocketProtocol;
public class GunInfo : ItemInfo
{
    string gunName;
    string gunType;
    float baseDMG;
    float firingRate;
    float currentFiringRatePerSecond;
    int magazine;
    string coreProp;
    float corePropValue;
    int gunId;


    public string GunName { get => gunName; }
    public string GunType { get => gunType; }
    public float BaseDMG { get => baseDMG; }
    public float FiringRate { get => firingRate; }
    public float CurrentFiringRatePerSecond { get => currentFiringRatePerSecond; }
    public int Magazine { get => magazine; }
    public string CoreProp { get => coreProp; }
    public float CorePropValue { get => corePropValue; }
    public int GunId { get => gunId; }
    

    public void Init(GunPack gunPack){
        use = gunPack.Use;
        gunId = gunPack.GunId;
        baseUid = gunId;
        block = gunPack.Block;
        gunName = gunPack.GunName;
        gunType = gunPack.GunType;
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
