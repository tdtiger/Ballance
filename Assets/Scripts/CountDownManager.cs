using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI countDownText;

    [SerializeField]
    private float countDownTime = 3f;

    [SerializeField]
    private Vector3 startScale = new Vector3(3f, 3f, 3f);

    [SerializeField]
    private Vector3 endScale = Vector3.one;

    void Start(){
        Time.timeScale = 0f;
        StartCoroutine(StartCountDown());
    }

    private IEnumerator StartCountDown(){
        float timeLeft = countDownTime;
        while(timeLeft > 0){
            countDownText.text = Mathf.Ceil(timeLeft).ToString();
            yield return StartCoroutine(AnimateText());
            timeLeft -= 1;
        }

        countDownText.text = "Go!";
        yield return StartCoroutine(AnimateText());

        countDownText.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    private IEnumerator AnimateText(){
        countDownText.color = new Color(1f, 0.4f, 0.7f, 1f);
        countDownText.transform.localScale = startScale;

        float elapsed = 0f;
        float duration = 1f;

        while(elapsed < duration){
            elapsed += Time.unscaledDeltaTime;
            float t = elapsed / duration;

            countDownText.transform.localScale = Vector3.Lerp(startScale, endScale, t);

            Color c = countDownText.color;
            c.a = Mathf.Lerp(1f, 0f, t);
            countDownText.color = c;

            yield return null;
        }
    }
}