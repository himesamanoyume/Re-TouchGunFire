public class GunInfo : ItemInfo
{
    EGunName gunName;
    EGunType gunType;
    EQuality gunQuality;
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

    public EGunName GunName { get => gunName; }
    public EGunType GunType { get => gunType; }
    public EQuality GunQuality { get => gunQuality; }
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
    public bool Using { get; set;}
}
