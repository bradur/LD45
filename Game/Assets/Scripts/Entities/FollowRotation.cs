// Date   : 05.10.2019 16:13
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class FollowRotation : MonoBehaviour {

    [SerializeField]
    Transform target;

    [SerializeField]
    private bool followX = true;
    [SerializeField]
    private bool followY = true;
    [SerializeField]
    private bool followZ = true;

    [SerializeField]
    private bool clampX = false;
    [SerializeField]
    private float maxX = 25;
    [SerializeField]
    private float minX = -1;

    [SerializeField]
    private Transform xTarget;

    void Start () {
    
    }

    void LateUpdate () {
        float xRot;
        if (xTarget != null) {
            xRot = followX ? xTarget.localEulerAngles.x : transform.localEulerAngles.x;
        } else {
            xRot = followX ? target.eulerAngles.x : transform.eulerAngles.x;
        }
        if (clampX) {
            
            if (xRot > 180) {
                xRot -= 360f;
            } else {
                //Debug.Log(xRot);
            }
            //Debug.Log(xRot);
            //Debug.Log(xRot + " -> " + (xRot - 360f));
            //Debug.Log(xRot + ", " + minX + ", " + maxX);
            xRot = Mathf.Clamp(xRot, minX, maxX);
            
            //Debug.Log(xRot + ", " + minX + ", " + maxX);
            //xRot = Mathf.Clamp(xRot, minX, maxX);
            //Debug.Log(xRot);
        }

        Vector3 rot = new Vector3(
            xRot,
            followY ? target.eulerAngles.y : transform.eulerAngles.y,
            followZ ? target.eulerAngles.z : transform.eulerAngles.z
        );

        transform.eulerAngles = rot;
    }
}
