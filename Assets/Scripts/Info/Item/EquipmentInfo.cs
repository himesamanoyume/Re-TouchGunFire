using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInfo : ItemInfo
{
   private EEquipmentSuit equipmentSuit;
   private EEquipmentQuality equipmentQuality;

   public EEquipmentSuit EquipmentSuit{
      get{ return equipmentSuit;}
      set{ equipmentSuit = value;}
   }

   public EEquipmentQuality EquipmentQuality{
      get{ return equipmentQuality;}
      set{ equipmentQuality = value;}
   }

   public string EquipmentName{
      get;set;
   }

   private float maxDefense = 0;
   public float MaxDefense{
      get{ return maxDefense;}
      set{ 
         if(value<=0){
            maxDefense=0;
         }else{
            maxDefense = value;
         }
      }
   }

   private float minDefense = 0;
   public float MinDefense{
      get{ return minDefense;}
      set{ 
         if(value<=0){
            minDefense=0;
         }else{
            minDefense = value;
         }
      }
   }

   private float defense;
   public float Defense{
      get{ return defense;}
      set{ 
         if(MaxDefense <= value && MinDefense >= value){
            defense = value;
         }else{
            Debug.LogError("Defense value error:"+value);
         }
      }
   }

   public void SetDefense(){
      if(MaxDefense >= MinDefense){
         Defense = Random.Range(MinDefense,MaxDefense);
      }
   }
}
