using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 100f;

    void Update(){
        float input = Input.GetAxis("Horizontal");
        this.transform.Rotate(Vector3.forward, -input * rotationSpeed * Time.deltaTime);
    }
}