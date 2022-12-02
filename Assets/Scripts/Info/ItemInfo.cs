using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemInfo
{
    protected int itemId;
    public int ItemId { get => itemId;}
    protected long price;
    public long Price { get => price; }
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
    protected string subProp2;
    protected float subProp2Value;
    protected string subProp3;
    protected float subProp3Value;
    public string SubProp1 { get => subProp1; }
    public float SubProp1Value { get => subProp1Value; }
    public string SubProp2 { get => subProp2; }
    public float SubProp2Value { get => subProp2Value; }
    public string SubProp3 { get => subProp3; }
    public float SubProp3Value { get => subProp3Value; }
    protected string itemType;
    public string ItemType { get => itemType; }

}
