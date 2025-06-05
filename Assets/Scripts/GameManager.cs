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
    private GameObject ball;

    private bool isGameOver = false;

    void Update(){
        if(ball.transform.position.y < -6f)
            GameOver();
    }

    public void GameOver(){
        if(isGameOver)
            return;

        isGameOver = true;
        Time.timeScale = 0f;
        Debug.Log("Game Over");
        if(gameOverUI != null){
            gameOverUI.SetActive(true);
        }
    }

    public void Retry(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
