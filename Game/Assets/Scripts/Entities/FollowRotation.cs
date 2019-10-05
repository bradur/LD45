// Date   : 05.10.2019 16:13
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class FollowRotation : MonoBehaviour {

    [SerializeField]
    Transform target;
    void Start () {
        
    }

    void Update () {
        transform.rotation = target.rotation;
    }
}
