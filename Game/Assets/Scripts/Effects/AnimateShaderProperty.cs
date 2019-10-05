using UnityEngine;
using System.Collections;

public class AnimateShaderProperty : MonoBehaviour {

    [SerializeField]
    private float minimum = 0f;
    [SerializeField]
    private float maximum = 1f;
    [SerializeField]
    private float duration = 1f;

    [SerializeField]
    private string propertyName = "";

    private float timer = 0;

    private Material material;
    private MeshRenderer meshRenderer;

    void Start () {
        meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.material;
    }

    void Update () {
        if (propertyName != "") {
            float value = Mathf.Lerp(minimum, maximum, timer);
            material.SetFloat(propertyName, value);

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
