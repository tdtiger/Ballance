using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFallDetector : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    private bool isFalling = false;

    void OnTriggerEnter(Collider other){
        if(isFalling)
            return;

        if(other.CompareTag("FallZone")){
            isFalling = true;
            Debug.Log("Ball has fallen!");

            gameManager.GameOver();
        }
    }
}