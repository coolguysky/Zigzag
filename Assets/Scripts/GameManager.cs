using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameOver;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        gameOver = false;
    }

    void Update()
    {
        
    }

    public void GameStart()
    {
        UIManager.instance.GameStart();
        ScoreManager.instance.startScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawningPlatforms();
    }

    public void GameStop()
    {
        UIManager.instance.GameOver();
        ScoreManager.instance.stopScore();
        gameOver = true;
    }
}
