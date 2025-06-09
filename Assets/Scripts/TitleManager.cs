using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScoreText;

    void Start(){
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if(highScoreText != null){
            highScoreText.text = $"High Score: {highScore}";
        }
    }

    public void StartGame(){
        SceneManager.LoadScene("PlayScene");
    }
}