// Date   : 07.10.2019 22:58
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class Dome : MonoBehaviour {

    [SerializeField]
    private int health = 10;

    private AnimateShaderProperty animateShader;

    void Start () {
        animateShader = GetComponent<AnimateShaderProperty>();
    }

    void Update () {
    
    }

    void TakeDamage() {
        health -= 1;
        animateShader.Pulse();
        if (health <= 0) {
            health = 0;
            Die();
        }
        SoundManager.main.PlaySound(SoundType.Hurt);
    }

    public void Die() {
        GameManager.main.GameOver();
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyProjectile")) {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }
}
