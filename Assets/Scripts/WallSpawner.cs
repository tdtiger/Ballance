using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject blockPrefab;

    private int columns = 6;

    private int blockWidth = 2;

    private int spawnY = 5;

    private float spawnInterval = 2f;

    private float timer = 0f;

    void Update(){
        timer += Time.deltaTime;
        if(timer >= spawnInterval){
            SpawnWall();
            timer = 0f;
        }
    }

    private void SpawnWall(){
        GameObject wallGroup = new GameObject("WallGroup");
        int holeIndex = Random.Range(0, columns);

        for(int i = 0; i < columns; i++){
            if(i == holeIndex)
                continue;

            GameObject block = Instantiate(blockPrefab, wallGroup.transform);

            float x = (i - columns / 2f + 0.5f) * blockWidth;
            block.transform.position = new Vector3(x, spawnY, 0f);
        }
    }
}