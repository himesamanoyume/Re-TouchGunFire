using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemInfo
{
    protected float price;
    public float Price { get => price; }
    protected bool use;
    protected bool block;
    public bool Use { get => use; }
    public bool Block { get => block; }
}
