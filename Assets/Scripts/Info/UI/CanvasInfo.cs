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

    public void InitCanvasChild(){
        m_level1 = transform.GetChild(0);
        Debug.Log(m_level1.name);
        m_level2 = transform.GetChild(1);
        Debug.Log(m_level2.name);
        m_level3 = transform.GetChild(2);
        Debug.Log(m_level3.name);
        m_level4 = transform.GetChild(3);
        Debug.Log(m_level4.name);
        m_levelLoading = transform.GetChild(4);
        Debug.Log(m_levelLoading.name);
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
