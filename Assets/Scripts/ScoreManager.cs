using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private int score = 0;

    void Reset(){
        ResetScore();
    }

    public void ResetScore(){
        score = 0;
        UpdateUI();
    }

    public void AddScore(int value){
        score += value;
        UpdateUI();
    }

    public int GetScore(){
        return score;
    }

    public void SaveScore(){
        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if(score > currentHighScore){
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }
    
    private void UpdateUI(){
        if(scoreText != null){
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
