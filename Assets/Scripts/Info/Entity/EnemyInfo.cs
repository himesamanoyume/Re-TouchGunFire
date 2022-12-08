using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class EnemyInfo : EntityInfo
{
    public EFloorPos floorPos = EFloorPos.Null;
    [SerializeField] Slider healthSlider;
    [SerializeField] Slider armorSlider;
    [SerializeField] Text enemyName;

    private void Start() {
        Init();
        
    }

    protected override void Init()
    {
        base.Init();
        healthSlider = transform.Find("ImagePart/HealthSlider").GetComponent<Slider>();
        armorSlider = transform.Find("ImagePart/ArmorSlider").GetComponent<Slider>();
        enemyName = transform.Find("InfoPart/Text").GetComponent<Text>();
    }
}
