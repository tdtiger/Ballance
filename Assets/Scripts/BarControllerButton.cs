using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarControllerButton : MonoBehaviour
{
    private float rotateSpeed = 50f;
    private float maxTilt = 30f;
    private int inputDirection = 0;

    void Update(){
        if(inputDirection != 0){
            float tilt = inputDirection * rotateSpeed * Time.deltaTime;
            transform.Rotate(0, 0, tilt);

            float currentZ = this.transform.eulerAngles.z;
            if(currentZ > 180f)
                currentZ -= 360f;
            currentZ = Mathf.Clamp(currentZ, -maxTilt, maxTilt);
            this.transform.rotation = Quaternion.Euler(0, 0, currentZ);
        }
    }

    public void OnPressLeft() => inputDirection = 1;

    public void OnPressRight() => inputDirection = -1;

    public void OnRelease() => inputDirection = 0;
}
