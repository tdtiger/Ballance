using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarDemoMotion : MonoBehaviour
{
    private float tiltAmount = 15f;

    private float tiltSpeed = 2.5f;

    void Update(){
        float tilt = Mathf.Sin(Time.time * tiltSpeed) * tiltAmount;
        this.transform.rotation = Quaternion.Euler(0, 0, tilt);
    }
}