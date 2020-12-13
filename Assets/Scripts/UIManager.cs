using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject zigZagPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public Text score;
    public Text highScore1;
    public Text highScore2;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
    }
    public void GameStart()
    {
        tapText.SetActive(false);
        zigZagPanel.GetComponent<Animator>().Play("panelUp");
    }
    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
    }
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
