using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroller : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed;

    void Update(){
        this.transform.position += Vector3.up * scrollSpeed * Time.deltaTime;
    }
}
