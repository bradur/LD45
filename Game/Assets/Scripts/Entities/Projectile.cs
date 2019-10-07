// Date   : 07.10.2019 21:48
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    private Rigidbody rb;
    public void Initialize (Transform target, float speed) {
        transform.LookAt(target);
        rb = GetComponent<Rigidbody>();
        Vector3 direction = target.position - transform.position;
        rb.AddForce(direction * speed, ForceMode.Impulse);
    }

    public void Die() {
        Destroy(gameObject);
    }

}
