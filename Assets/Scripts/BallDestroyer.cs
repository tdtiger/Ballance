using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    void Update(){
        if(this.transform.position.y < -6f)
            Destroy(this.gameObject);
    }
}
