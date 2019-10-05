// Date   : 05.10.2019 16:17
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class Planetoid : MonoBehaviour {

    private bool targeted = false;

    private MouseDrag3D mouseDrag3D;
    private TurnUpTheLight turnUpTheLight;

    [SerializeField]
    [TextArea]
    private string message = "";

    private void Start() {
        mouseDrag3D = GetComponent<MouseDrag3D>();
        turnUpTheLight = GetComponent<TurnUpTheLight>();
    }

    public void TargetOn() {
        targeted = true;
        turnUpTheLight.TurnUp();
        if (!Input.GetMouseButton(0)) {
            UIManager.main.MouseDetectObjectOn(message);
        }
    }

    public void TargetOff() {
        targeted = false;
        turnUpTheLight.TurnOff();
        if (!Input.GetMouseButton(0)) {
            UIManager.main.MouseDetectObjectOff();
        }
    }

    private void Update() {
        if (mouseDrag3D) { 
            if (Input.GetMouseButton(0)) {
                if (targeted) {
                    mouseDrag3D.StartDragging();
                }
            } else {
                mouseDrag3D.StopDragging();
            }
        }
    }
}
