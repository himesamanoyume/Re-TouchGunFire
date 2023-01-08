using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemInfo
{
    protected int itemId;
    public int ItemId { get => itemId;}
    protected float price;
    public float Price { get => price; }
    protected float diamondPrice;
    public float DiamondPrice { get => diamondPrice; }
    protected bool use;
    protected bool block;
    public bool Use { get => use;  set => use = value;}
    public bool Block { get => block; }
    protected float unlockAllSubPropPrice;
    public float UnlockAllSubPropPrice { get => unlockAllSubPropPrice; }
    public float RefreshAllPropPrice { get => refreshAllPropPrice; }
    protected float refreshAllPropPrice;
    protected string subProp1;
    protected float subProp1Value;
    protected float subProp1MaxValue;
    protected string subProp2;
    protected float subProp2Value;
    protected float subProp2MaxValue;
    protected string subProp3;
    protected float subProp3Value;
    protected float subProp3MaxValue;
    public string SubProp1 { get => subProp1; }
    public float SubProp1Value { get => subProp1Value; }
    public string SubProp2 { get => subProp2; }
    public float SubProp2Value { get => subProp2Value; }
    public string SubProp3 { get => subProp3; }
    public float SubProp3Value { get => subProp3Value; }
    protected string itemType;
    public string ItemType { get => itemType; }
    public float SubProp1MaxValue { get => subProp1MaxValue; }
    public float SubProp2MaxValue { get => subProp2MaxValue; }
    public float SubProp3MaxValue { get => subProp3MaxValue; }
    public float HealthBonus { get => healthBonus;}
    public float BaseDmgBonus { get => baseDmgBonus;}
    public float CritDmgRateBonus { get => critDmgRateBonus;}
    public float CritDmgBonus { get => critDmgBonus; }
    public float HeadshotDmgBonus { get => headshotDmgBonus; }
    public float PRateBonus { get => pRateBonus; }
    public float AbeBonus { get => abeBonus; }
    public float ArmorBonus { get => armorBonus; }
    protected float healthBonus;
    protected float baseDmgBonus;
    protected float critDmgRateBonus;
    protected float critDmgBonus;
    protected float headshotDmgBonus;
    protected float pRateBonus;
    protected float abeBonus;
    protected float armorBonus;
    protected PlayerInfo playerInfo;

}
