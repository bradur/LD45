using UnityEngine;
using System.Collections;

public class RotateRandomly : MonoBehaviour {

    [SerializeField]
    [Range(1, 10)]
    private float interval = 1f;

    [SerializeField]
    [Range(0, 20)]
    private float speed = 1f;

    private Quaternion targetRotation;
    private float timer = 0;

    void Start () {
        targetRotation = Random.rotation;
    }

    void Update () {
        timer += Time.deltaTime / interval;

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            Time.deltaTime * speed
        );

        if (timer > 1)
        {
            timer = 0.0f;
            targetRotation = Random.rotation;
        }
    }
}
