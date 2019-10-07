// Date   : 05.10.2019 16:17
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Planetoid : MonoBehaviour {

    private bool targeted = false;

    [SerializeField]
    private bool draggable = true;
    private MouseDrag3D mouseDrag3D;
    private TurnUpTheLight turnUpTheLight;
    private RotateRandomly rotateRandomly;

    [SerializeField]
    [TextArea]
    private List<string> messages;

    private void Start() {
        mouseDrag3D = GetComponent<MouseDrag3D>();
        turnUpTheLight = GetComponent<TurnUpTheLight>();
        rotateRandomly = GetComponent<RotateRandomly>();
    }

    public void TargetOn() {
        targeted = true;
        if (!Input.GetMouseButton(0)) {
            UIManager.main.MouseDetectObjectOn(messages);
        }
    }

    public void TargetOff() {
        targeted = false;
        if (!Input.GetMouseButton(0)) {
            UIManager.main.MouseDetectObjectOff();
        }
    }

    private void Update() {
        if (draggable && mouseDrag3D) { 
            if (Input.GetMouseButton(0)) {
                if (targeted) {
                    mouseDrag3D.StartDragging();
                }
            } else {
                mouseDrag3D.StopDragging();
            }
        }
    }

    public void Die() {
        UIManager.main.MouseDetectObjectOff();
        Destroy(gameObject);
    }
}
