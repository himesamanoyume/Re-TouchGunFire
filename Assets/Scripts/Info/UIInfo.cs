using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// [CreateAssetMenu(menuName = "UIInfo/New UIInfo")]
public abstract class UIInfo : MonoBehaviour//: ScriptableObject
{
    private string _name = "UIInfo";
    public string Name{
        get{ return _name;}
        set{ _name = value;}
    }

    public EUILevel currentLevel;
    protected Vector2 offScreen = new Vector2(0, -5000);
    protected Vector2 inTheScreen = new Vector2(0, 0);

    protected virtual void Init(){
        if(Name.Contains("UIInfo")) 
            Debug.LogWarning(this.gameObject.name + " Info name not set.");
    }

    protected virtual void CountDownRunning(Transform transform, Slider countdownLeft, Slider countdownRight, bool isCountdown){
        if(!isCountdown) return;
        countdownLeft.value -= Time.deltaTime;
        countdownRight.value -= Time.deltaTime;
        if(countdownLeft.value <= 0 && countdownRight.value <= 0){
            isCountdown = false;
            transform.GetComponent<RectTransform>().offsetMax = offScreen;
        }
    }

    protected virtual void CountDownRunning(){
        //do nothing
    }
}
