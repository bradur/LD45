// Date   : 05.10.2019 21:15
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class DroneCollisionHandler : MonoBehaviour {

    private Drone parentDrone;
    private void Start() {
        parentDrone = GetComponentInParent<Drone>();
    }

    private void OnCollisionEnter(Collision collision) {
        parentDrone.OnChildCollisionEnter(collision);
    }

    private void OnCollisionExit(Collision collision) {
        parentDrone.OnChildCollisionEnter(collision);
    }

    private void OnCollisionStay(Collision collision) {
        parentDrone.OnChildCollisionStay(collision);
    }
}
