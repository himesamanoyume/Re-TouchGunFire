using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : UnitySingleton<GameLoop>
{
    GameManager m_gameMgr = new GameManager();

    void Start()
    {
        m_gameMgr.m_sceneMgr.SetScene(new InitScene(m_gameMgr.m_sceneMgr), "");
        
    }

    void Update()
    {
        m_gameMgr.m_sceneMgr.SceneUpdate();
    }
}
