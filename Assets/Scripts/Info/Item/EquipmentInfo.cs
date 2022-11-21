using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquipmentInfo : ItemInfo
{
   EEquipmentSuit equipmentSuit;
   EQuality equipmentQuality;
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

   public EEquipmentSuit EquipmentSuit { get => equipmentSuit; }
   public EQuality EquipmentQuality { get => equipmentQuality; }
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
   public bool Using { get; set;}
}
