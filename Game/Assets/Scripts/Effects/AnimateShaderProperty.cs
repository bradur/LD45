using UnityEngine;
using System.Collections;

public class AnimateShaderProperty : MonoBehaviour {

    [SerializeField]
    private float minimum = 0f;
    [SerializeField]
    private float pulseMinimum = 0f;
    [SerializeField]
    private float maximum = 1f;
    [SerializeField]
    private float pulseMaximum = 2f;
    [SerializeField]
    private float duration = 1f;
    [SerializeField]
    private float pulseDuration = 0.2f;

    [SerializeField]
    private string propertyName = "";

    private float timer = 0;
    private float pulseTimer = 0;

    private Material material;
    [SerializeField]
    private MeshRenderer meshRenderer;
    private bool pulse = false;
    [SerializeField]
    private bool animate = false;


    [SerializeField]
    private Color color;

    void Start () {
        material = meshRenderer.material;
    }

    void Update () {
        if (pulse) {
            if (propertyName != "") {
                pulseTimer += Time.deltaTime / pulseDuration;
                float value = Mathf.Lerp(pulseMinimum, pulseMaximum, pulseTimer);
                //Debug.Log("Pulsing: " + pulseTimer + "-> " + value);
                //material.SetFloat(propertyName, value);
                material.SetColor(propertyName, color * value);


                if (pulseTimer > 1)
                {
                    material.SetColor(propertyName, color * pulseMinimum);
                    pulse = false;
                    pulseTimer = 0f;
                }
            }
        }
        else if (animate) {
            if (propertyName != "") {
                float value = Mathf.Lerp(minimum, maximum, timer);
                //material.SetFloat(propertyName, value);
                material.SetColor(propertyName, color * value);

                timer += Time.deltaTime / duration;

                if (timer > 1)
                {
                    float temp = maximum;
                    maximum = minimum;
                    minimum = temp;
                    timer = 0.0f;
                }
            }
        }
    }

    public void Pulse() {
        pulse = true;
    }
}
