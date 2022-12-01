using SocketProtocol;

public class EquipmentInfo : ItemInfo
{
   string equipmentSuit;
   string equipmentName;
   
   EEquipmentTalent talent1;
   EEquipmentTalent talent2;
   int equipmentId;
   

   public string EquipmentSuit { get => equipmentSuit; }
   public string EquipmentName { get => equipmentName; }
   
   public EEquipmentTalent Talent1 { get => talent1; }
   public EEquipmentTalent Talent2 { get => talent2; }
   public int EquipmentId { get => equipmentId; }
   

    public void Init(EquipmentPack equipmentPack){
        use = equipmentPack.Use;
        itemId = equipmentPack.ItemId;
        itemType = equipmentPack.ItemType;
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
        diamondPrice = price/10000f;
        unlockAllSubPropPrice = price/4f;
        refreshAllPropPrice = price/10f;
    }
}
