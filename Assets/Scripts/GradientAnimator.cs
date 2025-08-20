using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GradientAnimator : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI titleText;

    private Color colorA = new Color(0f, 0.9f, 1f);
    private Color colorB = Color.white;

    private float speed = 2.5f; 

    private VertexGradient gradient;
    
    void Update(){
        float t = (Mathf.Sin(Time.time * speed) + 1f) / 2f;
        Color currentA = Color.Lerp(colorA, colorB, t);
        Color currentB = Color.Lerp(colorB, colorA, t);

        gradient = new VertexGradient(currentA, currentB, currentA, currentB);
        titleText.colorGradient = gradient;
    }
}
