using SocketProtocol;

public abstract class EquipmentInfo : ItemInfo
{
   string equipmentSuit;
   string equipmentName;
   string subProp1;
   float subProp1Value;
   string subProp2;
   float subProp2Value;
   string subProp3;
   float subProp3Value;
   EEquipmentTalent talent1;
   EEquipmentTalent talent2;
   int equipmentId;
   bool use;
   bool block;
   float price;

   public string EquipmentSuit { get => equipmentSuit; }
   public string EquipmentName { get => equipmentName; }
   public string SubProp1 { get => subProp1; }
   public float SubProp1Value { get => subProp1Value; }
   public string SubProp2 { get => subProp2; }
   public float SubProp2Value { get => subProp2Value; }
   public string SubProp3 { get => subProp3; }
   public float SubProp3Value { get => subProp3Value; }
   public EEquipmentTalent Talent1 { get => talent1; }
   public EEquipmentTalent Talent2 { get => talent2; }
   public int EquipmentId { get => equipmentId; }
   public bool Use { get => use; }
   public bool Block { get => block; }
   public float Price { get => price; }

    public void Init(EquipmentPack equipmentPack){
        use = equipmentPack.Use;
        equipmentId = equipmentPack.EquipmentId;
        block = equipmentPack.Block;
        equipmentSuit = equipmentPack.EquipmentSuit;
        equipmentName = equipmentPack.EquipmentName;
        subProp1 = equipmentPack.SubProp1;
        subProp1Value = equipmentPack.SubProp1Value;
        subProp2 = equipmentPack.SubProp2;
        subProp2Value = equipmentPack.SubProp2Value;
        subProp3 = equipmentPack.SubProp3;
        subProp3Value = equipmentPack.SubProp3Value;
        talent1 = (EEquipmentTalent)equipmentPack.Talent1;
        talent2 = (EEquipmentTalent)equipmentPack.Talent2;
        price = equipmentPack.Price;
    }
}
