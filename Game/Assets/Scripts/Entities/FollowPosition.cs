// Date   : 05.10.2019 16:14
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class FollowPosition : MonoBehaviour {

    [SerializeField]
    Transform target;

    [SerializeField]
    private bool followX;
    [SerializeField]
    private bool followY;
    [SerializeField]
    private bool followZ;

    void Start () {
    
    }

    void LateUpdate () {
        Vector3 pos = new Vector3(
            followX ? target.position.x : transform.position.x,
            followY ? target.position.y : transform.position.y,
            followZ ? target.position.z : transform.position.z
        );
        transform.position = pos;
    }
}
