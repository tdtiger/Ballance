using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGroup : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;

    private bool hasScored = false;

    void Update(){
        this.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        if(this.transform.position.y < 0f && !hasScored){
            hasScored = true;
            FindObjectOfType<ScoreManager>()?.AddScore(1);
        }

        if(this.transform.position.y < -10f)
            Destroy(this.gameObject);
    }
}