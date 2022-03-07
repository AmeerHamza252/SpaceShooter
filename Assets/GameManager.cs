using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Score;
    public GameObject pausePanel;
    public GameObject gameoverPanel;
    public bool isGamePaused;

    public TextMeshProUGUI scoreText;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
           
        }
    }
        

    public void CalculateScore(int score)
    {
        Score += score;
        scoreText.text = "Score: " + Score;
    }

    public void restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    void PauseGame()
    {
        if (isGamePaused)
        {
            GetComponent<GameManager>().pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            GetComponent<GameManager>().pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void GameOver() 
    {
        gameoverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
