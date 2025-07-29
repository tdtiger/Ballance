using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject blockPrefab;

    [SerializeField]
    private Transform spawnPoint;

    private int columns = 6;

    private int blockWidth = 2;

    [SerializeField]
    private float spawnInterval = 0.97f;

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
        wallGroup.transform.position = spawnPoint.position;
        wallGroup.AddComponent<WallGroup>();

        int holeIndex = Random.Range(0, columns);

        for(int i = 0; i < columns; i++){
            if(i == holeIndex)
                continue;
            
            Vector3 pos = spawnPoint.position + new Vector3((i - columns / 2f) * blockWidth, 0, 0);
            GameObject block = Instantiate(blockPrefab, pos, Quaternion.identity, wallGroup.transform);
        }
    }
}