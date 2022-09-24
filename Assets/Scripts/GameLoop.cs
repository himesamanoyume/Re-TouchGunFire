using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    GameManager m_gameMgr = new GameManager();

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        m_gameMgr.m_sceneMgr.SetScene(new InitScene(m_gameMgr.m_sceneMgr), "");
    }

    void Update()
    {
        m_gameMgr.m_sceneMgr.SceneUpdate();
    }
}
