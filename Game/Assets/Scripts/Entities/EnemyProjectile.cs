// Date   : 07.10.2019 20:34
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

    private Transform target;
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

    void OnCollisionEnter(Collision collision) {
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile != null) {
            projectile.Die();
            Die();
        }
    }
}
