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
    string subProp1;
    float subProp1Value;
    string subProp2;
    float subProp2Value;
    string subProp3;
    float subProp3Value;
    int gunId;
    bool use;
    bool block;

    public string GunName { get => gunName; }
    public string GunType { get => gunType; }
    public float BaseDMG { get => baseDMG; }
    public float FiringRate { get => firingRate; }
    public float CurrentFiringRatePerSecond { get => currentFiringRatePerSecond; }
    public int Magazine { get => magazine; }
    public string CoreProp { get => coreProp; }
    public float CorePropValue { get => corePropValue; }
    public string SubProp1 { get => subProp1; }
    public float SubProp1Value { get => subProp1Value; }
    public string SubProp2 { get => subProp2;}
    public float SubProp2Value { get => subProp2Value; }
    public string SubProp3 { get => subProp3; }
    public float SubProp3Value { get => subProp3Value; }
    public int GunId { get => gunId; }
    public bool Use { get => use;}
    public bool Block { get => block; }

    public void Init(GunPack gunPack){
        use = gunPack.Use;
        gunId = gunPack.GunId;
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
    }
}
