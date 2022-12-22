
using UnityEngine;
using XLua;

[LuaCallCSharp]
public enum EGunCoreProp
{
    Null,
    [Tooltip("全武器伤害加成")]
    AllDmgBonus,
    [Tooltip("自动步枪伤害加成")]
    ArDmgBonus,
    [Tooltip("精确射手步枪伤害加成")]
    DmrDmgBonus,
    [Tooltip("微型冲锋枪伤害加成")]
    SmgDmgBonus,
    [Tooltip("霰弹枪伤害加成")]
    SgDmgBonus,
    [Tooltip("狙击步枪伤害加成")]
    SrDmgBonus,
    [Tooltip("轻机枪伤害加成")]
    MgDmgBonus,
    [Tooltip("手枪伤害加成")]
    HgDmgBonus
}
