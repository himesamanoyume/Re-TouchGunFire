using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInfo
{
   private EquipmentSuitEnum m_equipmentSuit;
   private EquipmentQualityEnum m_equipmentQuality;

   public EquipmentSuitEnum EquipmentSuit{
      get{ return m_equipmentSuit;}
      set{ m_equipmentSuit = value;}
   }

   public EquipmentQualityEnum EquipmentQuality{
      get{ return m_equipmentQuality;}
      set{ m_equipmentQuality = value;}
   }

   public string EquipmentName{
      get;set;
   }

   private float m_maxDefense = 0;
   public float MaxDefense{
      get{ return m_maxDefense;}
      set{ 
         if(value<=0){
            m_maxDefense=0;
         }else{
            m_maxDefense = value;
         }
      }
   }

   private float m_minDefense = 0;
   public float MinDefense{
      get{ return m_minDefense;}
      set{ 
         if(value<=0){
            m_minDefense=0;
         }else{
            m_minDefense = value;
         }
      }
   }

   private float m_defense;
   public float Defense{
      get{ return m_defense;}
      set{ 
         if(MaxDefense <= value && MinDefense >= value){
            m_defense = value;
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
