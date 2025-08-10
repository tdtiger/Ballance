using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverUI;

    [SerializeField]
    private ScoreManager scoreManager;

    private bool isGameOver = false;

    void Start(){
        gameOverUI.SetActive(false);
    }
    
    public void GameOver(){
        if(isGameOver)
            return;

        scoreManager.SaveScore();
        isGameOver = true;
        Time.timeScale = 0f;

        if(gameOverUI != null){
            gameOverUI.SetActive(true);
        }
    }

    public void Retry(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToTitle(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
    }
}
