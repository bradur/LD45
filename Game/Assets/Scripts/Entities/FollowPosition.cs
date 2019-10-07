// Date   : 05.10.2019 16:14
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class FollowPosition : MonoBehaviour {

    [SerializeField]
    Transform target;
    void Start () {
    
    }

    void LateUpdate () {
        transform.position = target.position;
    }
}
