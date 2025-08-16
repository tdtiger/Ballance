using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;

    private float spawnInterval = 3f;

    private float timer;

    void Update(){
        timer += Time.deltaTime;
        if(timer >= spawnInterval){
            GameObject ball = Instantiate(ballPrefab, new Vector3(0f, 8f, 0f), Quaternion.identity);
            timer = 0f;
        }
    }
}
