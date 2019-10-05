// Date   : 05.10.2019 05:05
// Project: Game
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CrossHair : MonoBehaviour {

    [SerializeField]
    private Text txtComponent;

    [SerializeField]
    private Color targetColor;
    private Color originalColor;

    [SerializeField]
    private float targetScale;
    private float originalScale;
    private Vector2 originalSize;

    [SerializeField]
    private Image detectIndicatorImage;

    float minScale;
    float maxScale;
    private Color minColor;
    private Color maxColor;

    private bool turning = false;

    private float timer = 0f;

    [SerializeField]
    private float duration = 0.3f;

    void Start() {
        originalColor = detectIndicatorImage.color;
        originalSize = detectIndicatorImage.rectTransform.lossyScale;
        originalScale = detectIndicatorImage.rectTransform.lossyScale.x;
    }

    public void ObjectDetected() {
        Debug.Log("Yes");
        TurnOn();
        //detectIndicatorImage.color = colorOnDetect;
    }

    public void NoObjectsDetected() {
        Debug.Log("No");
        TurnOff();
        //detectIndicatorImage.color = originalColor;
    }


    public void TurnOn() {
        //lightObject.intensity = Mathf.Lerp(minScale, maxScale, noise);
        minScale = detectIndicatorImage.rectTransform.lossyScale.x;
        maxScale = targetScale;
        minColor = detectIndicatorImage.color;
        maxColor = targetColor;
        turning = true;
    }

    public void TurnOff() {
        minScale = detectIndicatorImage.rectTransform.lossyScale.x;
        maxScale = originalScale;
        minColor = detectIndicatorImage.color;
        maxColor = originalColor;
        turning = true;
    }

    void Update() {
        if (turning) {
            timer += Time.deltaTime / duration;
            float scale = Mathf.Lerp(minScale, maxScale, timer);
            //detectIndicatorImage.rectTransform.sizeDelta = originalSize * scale;
            detectIndicatorImage.rectTransform.localScale = originalSize * scale; 
            detectIndicatorImage.color = Color.Lerp(minColor, maxColor, timer);
            if (timer > 1)
            {
                turning = false;
                timer = 0f;
            }
        }
    }

}
