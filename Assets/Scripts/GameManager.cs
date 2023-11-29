using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject StartMenu, EndMenu, GameMenu;
    int score;
    [SerializeField] Text scoreText, finalScore;

    private void Awake()
    {
        Time.timeScale = 0f;
    }

    private void Start()
    {
        InvokeRepeating("IncreaseScore", 2f, 1f);
    }

    void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
        finalScore.text = "Final Score: " + score.ToString();

    }
    public void StartGame()
    {
        Time.timeScale = 1.0f;
        StartMenu.SetActive(false);
    }
    public void GameOver()
    {
        EndMenu.SetActive(true);
        GameMenu.SetActive(false);
        Debug.Log("Game Over");
        Time.timeScale = 0;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }
}
