using SocketProtocol;

public abstract class EquipmentInfo : ItemInfo
{
   EEquipmentSuit equipmentSuit;
   EEquipmentName equipmentName;
   ESubProp subProp1;
   float subProp1Value;
   ESubProp subProp2;
   float subProp2Value;
   ESubProp subProp3;
   float subProp3Value;
   EEquipmentTalent talent1;
   EEquipmentTalent talent2;
   int uid;
   bool use;
   bool block;

   public EEquipmentSuit EquipmentSuit { get => equipmentSuit; }
   public EEquipmentName EquipmentName { get => equipmentName; }
   public ESubProp SubProp1 { get => subProp1; }
   public float SubProp1Value { get => subProp1Value; }
   public ESubProp SubProp2 { get => subProp2; }
   public float SubProp2Value { get => subProp2Value; }
   public ESubProp SubProp3 { get => subProp3; }
   public float SubProp3Value { get => subProp3Value; }
   public EEquipmentTalent Talent1 { get => talent1; }
   public EEquipmentTalent Talent2 { get => talent2; }
   public int Uid { get => uid; }
   public bool Use { get => use; }
   public bool Block { get => block; }

    public void Init(EquipmentPack equipmentPack){
        use = equipmentPack.Use;
        uid = equipmentPack.EquipmentId;
        block = equipmentPack.Block;
        equipmentSuit = (EEquipmentSuit)equipmentPack.EquipmentSuit;
        equipmentName = (EEquipmentName)equipmentPack.EquipmentName;
        subProp1Value = equipmentPack.SubProp1Value;
        subProp2 = (ESubProp)equipmentPack.SubProp2;
        subProp2Value = equipmentPack.SubProp2Value;
        subProp3 = (ESubProp)equipmentPack.SubProp3;
        subProp3Value = equipmentPack.SubProp3Value;
        talent1 = (EEquipmentTalent)equipmentPack.Talent1;
        talent2 = (EEquipmentTalent)equipmentPack.Talent2;
    }
}
