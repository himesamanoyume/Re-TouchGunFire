
using UnityEngine;
using XLua;

[LuaCallCSharp]
enum ESubProp
{
    Null,
    [Tooltip("生命值百分比加成")]
    healthBonus,
    [Tooltip("基础伤害加成")]
    baseDmgBonus,
    [Tooltip("暴击率加成")]
    cDmgRateBonus,
    [Tooltip("暴击伤害加成")]
    cDmgBonus,
    [Tooltip("爆头伤害加成")]
    headshotDmgBonus,
    [Tooltip("穿透率加成")]
    pRateBonus,
    [Tooltip("破甲效率加成")]
    abeBonus,
    [Tooltip("自动步枪伤害加成")]
    arDmgBonus,
    [Tooltip("精确射手步枪伤害加成")]
    dmrDmgBonus,
    [Tooltip("微型冲锋枪伤害加成")]
    smgDmgBonus,
    [Tooltip("霰弹枪伤害加成")]
    sgDmgBonus,
    [Tooltip("狙击步枪伤害加成")]
    srDmgBonus,
    [Tooltip("轻机枪伤害加成")]
    mgDmgBonus,
    [Tooltip("手枪伤害加成")]
    hgDmgBonus,
    [Tooltip("护甲值百分比加成")]
    armorBonus,

}

public enum EItemList{
    ar,
    dmr,
    smg,
    sg,
    mg,
    hg,
    armor,
    head,
    hand,
    leg,
    knee,
    boots
}
