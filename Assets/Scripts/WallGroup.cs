using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGroup : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;

    void Update(){
        this.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        if(transform.position.y < -10f)
            Destroy(this.gameObject);
    }
}