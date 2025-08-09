using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    [SerializeField]
    private float fallForce = 20f;

    private void OnTriggerStay(Collider other){
        if(other.CompareTag("Ball")){
            Rigidbody rb = other.attachedRigidbody;
            if(rb != null)
                rb.AddForce(Vector3.forward * fallForce, ForceMode.Acceleration);
        }
    }
}