using SocketProtocol;
public class GunInfo : ItemInfo
{
    EGunName gunName;
    EGunType gunType;
    float baseDMG;
    float firingRate;
    float currentFiringRatePerSecond;
    int magazine;
    int magazineCount;
    EGunCoreProp coreProp;
    float corePropValue;
    ESubProp subProp1;
    float subProp1Value;
    ESubProp subProp2;
    float subProp2Value;
    ESubProp subProp3;
    float subProp3Value;
    int uid;
    bool use;
    bool block;

    public EGunName GunName { get => gunName; }
    public EGunType GunType { get => gunType; }
    public float BaseDMG { get => baseDMG; }
    public float FiringRate { get => firingRate; }
    public float CurrentFiringRatePerSecond { get => currentFiringRatePerSecond; }
    public int Magazine { get => magazine; }
    public int MagazineCount { get => magazineCount; }
    public EGunCoreProp CoreProp { get => coreProp; }
    public float CorePropValue { get => corePropValue; }
    public ESubProp SubProp1 { get => subProp1; }
    public float SubProp1Value { get => subProp1Value; }
    public ESubProp SubProp2 { get => subProp2;}
    public float SubProp2Value { get => subProp2Value; }
    public ESubProp SubProp3 { get => subProp3; }
    public float SubProp3Value { get => subProp3Value; }
    public int Uid { get => uid; }
    public bool Use { get => use;}
    public bool Block { get => block; }

    public void Init(GunPack gunPack){
        use = gunPack.Use;
        uid = gunPack.GunId;
        block = gunPack.Block;
        gunName = (EGunName)gunPack.GunName;
        gunType = (EGunType)gunPack.GunType;
        baseDMG = gunPack.BaseDMG;
        firingRate = gunPack.FiringRate;
        currentFiringRatePerSecond = gunPack.CurrentFiringRatePerSecond;
        magazine = gunPack.Magazine;
        magazineCount = gunPack.MagazineCount;
        coreProp = (EGunCoreProp)gunPack.CoreProp;
        corePropValue = gunPack.CorePropValue;
        subProp1 = (ESubProp)gunPack.SubProp1;
        subProp1Value = gunPack.SubProp1Value;
        subProp2 = (ESubProp)gunPack.SubProp2;
        subProp2Value = gunPack.SubProp2Value;
        subProp3 = (ESubProp)gunPack.SubProp3;
        subProp3Value = gunPack.SubProp3Value;
    }
}
