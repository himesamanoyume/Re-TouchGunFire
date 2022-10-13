using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : UnitySingleton<GameLoop>
{
    private GameManager m_gameMgr = new GameManager();

    public GameManager GameManager{
        get{ return m_gameMgr;}
    }

    void Start()
    {
        m_gameMgr.SceneMgr.SetScene(new InitScene(m_gameMgr.SceneMgr), "");
        
    }

    void Update()
    {
        m_gameMgr.SceneMgr.SceneUpdate();
    }
}
