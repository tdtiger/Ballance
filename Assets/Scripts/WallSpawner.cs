using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject blockPrefab;

    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private ScoreManager scoreManager;

    [SerializeField]
    private GameObject fallEffect;

    private int columns = 6;

    private int blockWidth = 2;

    private int spawnY = 5;

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
        WallGroup wallScript = wallGroup.AddComponent<WallGroup>();
        wallScript.SetHoleIndices(GenerateHoleIndices());
        wallScript.SetBallReference(ball);
        wallScript.BlockWidth = blockWidth;
        wallScript.Columns = columns;
        wallScript.SetGameManager(gameManager);
        wallScript.SetScoreManager(scoreManager);
        wallScript.FallEffect = fallEffect;
        wallScript.GameOverDelay = 0.5f;

        int holeIndex = Random.Range(0, columns);
        
        List<Rect> holeRects = new List<Rect>();
        foreach(int i in wallScript.holeIndices){
            float xCenter = (i - columns / 2f + 0.5f) * blockWidth;
            Rect holeRect = new Rect(xCenter - blockWidth / 2f, -blockWidth / 2f, blockWidth, blockWidth);
            holeRects.Add(holeRect);
        }

        for(int i = 0; i < columns; i++){
            if(wallScript.holeIndices.Contains(i))
                continue;

            GameObject block = Instantiate(blockPrefab, wallGroup.transform);

            float x = (i - columns / 2f + 0.5f) * blockWidth;
            block.transform.localPosition = new Vector3(x, 0f, 0f);
        }

        wallGroup.transform.position = new Vector3(0f, spawnY, 0f);
    }

    private List<int> GenerateHoleIndices(){
        List<int> holeIndices = new List<int>();

        int holeIndex = Random.Range(0, columns);
        holeIndices.Add(holeIndex);

        return holeIndices;
    }
}