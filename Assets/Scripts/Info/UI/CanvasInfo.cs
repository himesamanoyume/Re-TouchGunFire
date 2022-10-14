using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInfo : UIInfo
{
    private Transform m_level1;
    private Transform m_level2;
    private Transform m_level3;
    private Transform m_level4;
    private Transform m_levelLoading;
    public CanvasInfo(){
        
        InitCanvasChild();
    }

    private void InitCanvasChild(){
        m_level1 = gameObject.transform.GetChild(0);
        m_level2 = gameObject.transform.GetChild(1);
        m_level3 = gameObject.transform.GetChild(2);
        m_level4 = gameObject.transform.GetChild(3);
        m_levelLoading = gameObject.transform.GetChild(4);
    }

    public Transform Canvas{
        get{ return this.transform;}
    }
    public Transform Level1{
        get{ return m_level1;}
    }
    public Transform Level2{
        get{ return m_level2;}
    }
    public Transform Level3{
        get{ return m_level3;}
    }
    public Transform Level4{
        get{ return m_level4;}
    }
    public Transform LevelLoading{
        get{ return m_levelLoading;}
    }
}
