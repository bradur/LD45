// Date   : 05.10.2019 04:44
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class TurnUpTheLight : MonoBehaviour {


    [SerializeField]
    private Light lightObject;

    private float random;

    private float originalIntensity;
    [SerializeField]
    private float targetIntensity;


    private float originalRange;
    [SerializeField]
    private float targetRange;

    private bool turning = false;

    [SerializeField]
    private float duration = 1f;

    private float timer = 0f;

    private float minIntensity;
    private float maxIntensity;

    private float minRange;
    private float maxRange;
    

    void Start () {
        originalIntensity = lightObject.intensity;
        originalRange = lightObject.range;
    }

    public void TurnUp() {
        //lightObject.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
        minIntensity = originalIntensity;
        maxIntensity = targetIntensity;
        minRange = originalRange;
        maxRange = targetRange;
        turning = true;
    }

    public void TurnOff() {
        minIntensity = targetIntensity;
        maxIntensity = originalIntensity;
        minRange = targetRange;
        maxRange = originalRange;
        turning = true;
    }

    void Update() {
        if (turning) {
            timer += Time.deltaTime / duration;
            lightObject.intensity = Mathf.Lerp(minIntensity, maxIntensity, timer);
            lightObject.range = Mathf.Lerp(minRange, maxRange, timer);
            if (timer > 1)
            {
                turning = false;
                timer = 0f;
            }
        }
    }

}
