using UnityEngine;
using System.Collections;

public class AnimateShaderColorPropertyIntensity : MonoBehaviour {

    [SerializeField]
    private float duration = 1f;

    [SerializeField]
    private string propertyName = "";

    [SerializeField]
    [Range(0f, 5f)]
    private float originalIntensity;

    [SerializeField]
    [Range(0, 5f)]
    private float targetIntensity;

    private float minimum;
    private float maximum;

    private float timer = 0;

    private Material material;

    [SerializeField]
    private Color color;

    [SerializeField]
    private MeshRenderer meshRenderer;

    void Start () {
        material = meshRenderer.material;
        minimum = originalIntensity;
        maximum = targetIntensity;
    }

    void Update () {
        if (propertyName != "") {
            timer += Time.deltaTime / duration;
            float value = Mathf.Lerp(minimum, maximum, timer);

            material.SetColor(propertyName, color * value);

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
