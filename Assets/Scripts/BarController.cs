using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    private float rotationSpeed = 100f;

    void Update(){
        float input = Input.GetAxis("Horizontal");
        this.transform.Rotate(0f, 0f, -input * rotationSpeed * Time.deltaTime);
    }
}