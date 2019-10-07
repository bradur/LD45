// Date   : 07.10.2019 21:28
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class ShootAtEnemyPeriodically : MonoBehaviour {

    [SerializeField]
    private Projectile projectilePrefab;
    
    [SerializeField]
    private float projectileSpeed = 5f;

    private RotateRandomly rotateRandomly;


    private float rotateDuration = 0.1f;
    private float rotateTimer;
    private bool isRotating = false;

    [SerializeField]
    private float findEnemyInterval = 1f;
    private float findEnemyTimer;


    [SerializeField]
    private float shootInterval = 0.5f;
    private float shootTimer;

    private Transform currentTarget;

    [SerializeField]
    private float detectDistance = 20f;

    private bool isShooting = false;

    private Transform dome;

    private Quaternion targetRotation;
    private Quaternion fromRotation;

    [SerializeField]
    private LayerMask enemyMask;

    private AnimateShaderProperty pulse;
    void Start () {
        rotateRandomly = GetComponent<RotateRandomly>();
        pulse = GetComponent<AnimateShaderProperty>();
        findEnemyTimer = findEnemyInterval;
        rotateTimer = rotateDuration;
        shootTimer = shootInterval;
        dome = GameObject.FindGameObjectWithTag("Dome").transform;
    }

    void AcquireTarget(Transform target) {
        fromRotation = new Quaternion(
            transform.rotation.x,
            transform.rotation.y,
            transform.rotation.z,
            transform.rotation.w
        );
        targetRotation = Quaternion.LookRotation(transform.position - target.position);
        rotateRandomly.enabled = false;
        currentTarget = target;
        isRotating = true;
    }

    private Vector3 spherePosition = Vector3.zero;

    private void FindEnemy() {
        findEnemyTimer = findEnemyInterval;
        spherePosition = transform.position + (transform.position - dome.position).normalized * detectDistance / 2f;
        Collider[] enemies = Physics.OverlapSphere(spherePosition, detectDistance / 2f, enemyMask);
        //Debug.Log("Finding enemy at " + spherePosition);
        if (enemies.Length > 0) {
            bool enemyFound = false;
            for (int index = 0; index < enemies.Length; index += 1) {
                if (enemies[index].gameObject.layer == LayerMask.NameToLayer("Enemy")) {
                    AcquireTarget(enemies[index].gameObject.transform);
                    enemyFound = true;
                    break;
                }
            }
            if (!enemyFound) {
                for (int index = 0; index < enemies.Length; index += 1) {
                    if (enemies[index].gameObject.layer == LayerMask.NameToLayer("EnemyProjectile")) {
                        AcquireTarget(enemies[index].gameObject.transform);
                        break;
                    }
                }
            }
        } else {
            currentTarget = null;
            StopShooting();
        }
    }

    [SerializeField]
    private bool drawDebugSphere;
    void OnDrawGizmos() {
        if (drawDebugSphere) {
            Gizmos.color = new Color(0, 1, 1, 0.2f);
            Gizmos.DrawSphere(spherePosition, detectDistance / 2f);
        }
    }

    void Shoot() {
        Vector3 direction = (transform.position - currentTarget.position).normalized;
        Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.Initialize(currentTarget, projectileSpeed);
        pulse.Pulse();
        SoundManager.main.PlaySound(SoundType.PlayerShoot);
        
    }

    void StopShooting() {
        isShooting = false;
        rotateRandomly.enabled = true;
    }

    void StartShooting() {
        isRotating = false;
        rotateTimer = rotateDuration;
        shootTimer = shootInterval;
        isShooting = true;
    }

    void Update () {
        findEnemyTimer -= Time.deltaTime;
        if (findEnemyTimer <= 0) {
            FindEnemy();
        }
        if (isRotating) {
            rotateTimer += Time.deltaTime / rotateDuration;
            transform.rotation = Quaternion.Slerp(
                fromRotation,
                targetRotation,
                rotateTimer
            );
            if (rotateTimer > 1) {
                StartShooting();
            }
        }
        if (isShooting) {
            if (currentTarget == null) {
                StopShooting();
            }
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0) {
                Shoot();
                shootTimer = shootInterval;
            }
        }
    }
}
