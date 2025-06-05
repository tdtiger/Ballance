using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGroup : MonoBehaviour
{
    private float moveSpeed = 2f;

    private float destroyY = -10f;

    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private ScoreManager scoreManager;

    [SerializeField]
    private GameObject fallEffect;
    public GameObject FallEffect {
        get{
            return fallEffect;
        }
        set{
            fallEffect = value;
        }
    }

    private float gameOverDelay = 2f;
    public float GameOverDelay {
        get{
            return gameOverDelay;
        }
        set{
            gameOverDelay = value;
        }
    }

    public List<int> holeIndices = new List<int>();

    private int columns = 6;
    public int Columns {
        get{
            return columns;
        }
        set{
            columns = value;
        }
    }

    private int blockWidth = 2;
    public int BlockWidth {
        get{
            return blockWidth;
        }
        set{
            blockWidth = value;
        }
    }
    
    private bool judged = false;

    void Update(){
        this.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        if(!judged)
            CheckBallInHole();

        if(this.transform.position.y < destroyY)
            Destroy(this.gameObject);
    }

    private void CheckBallInHole(){
        if(ball == null)
            return;

        SpriteRenderer ballRenderer = ball.GetComponent<SpriteRenderer>();
        Bounds ballBounds = ballRenderer.bounds;

        Vector3 ballMin = ballBounds.min;
        Vector3 ballMax = ballBounds.max;

        foreach(int holeIndex in holeIndices){
            float holeLocalX = (holeIndex - columns / 2f + 0.5f) * blockWidth;
            Vector3 holeCenterWorld = transform.TransformPoint(new Vector3(holeLocalX, 0f, 0f));

            float holeLeft = holeCenterWorld.x - blockWidth / 2f;
            float holeRight = holeCenterWorld.x + blockWidth / 2f;
            float holeBottom = holeCenterWorld.y - blockWidth / 2f;
            float holeTop = holeCenterWorld.y + blockWidth / 2f;

            if(holeLeft < ballMin.x && holeRight > ballMax.x && holeBottom < ballMin.y && holeTop > ballMax.y){
                judged = true;
                if(fallEffect != null){
                    Instantiate(fallEffect, ball.transform.position, Quaternion.identity);
                }

                StartCoroutine(DelayedGameOver());

                return;
            }
        }
    }

    private IEnumerator DelayedGameOver(){
        yield return new WaitForSeconds(gameOverDelay);
        if(gameManager != null)
            gameManager.GameOver();
    }

    public void SetHoleIndices(List<int> indices){
        this.holeIndices = indices;
    }

    public void SetBallReference(GameObject ballRef){
        this.ball = ballRef;
    }

    public void SetGameManager(GameManager gm){
        this.gameManager = gm;
    }

    public void SetScoreManager(ScoreManager sm){
        this.scoreManager = sm;
    }
}