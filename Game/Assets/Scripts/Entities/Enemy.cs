// Date   : 07.10.2019 20:50
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    private FollowOrbit followOrbit;

    private bool orbiting = false;
    private bool movingCloser = false;

    private Transform target;

    [SerializeField]
    private float minShootDistance = 60f;

    [SerializeField]
    private float orbitSpeed = 15;

    [SerializeField]
    private float moveSpeed = 5;

    [SerializeField]
    private float minDistance = 15f;

    [SerializeField]
    private float movingCloserDuration = 4f;
    private float movingCloserTimer;

    [SerializeField]
    private float shootingInterval = 2f;
    private float shootingTimer;

    [SerializeField]
    private float orbitingDuration = 5f;
    private float orbitingTimer;

    [SerializeField]
    private GameObject spawnOnDeath;

    private Rigidbody rb;

    private AnimateShaderProperty animateShader;

    void Start()
    {
        animateShader = GetComponent<AnimateShaderProperty>();
        target = GameObject.FindGameObjectWithTag("Dome").transform;
        followOrbit = GetComponent<FollowOrbit>();
        followOrbit.SetSpeed(orbitSpeed);
        rb = GetComponent<Rigidbody>();
        StartMovingCloser();
    }

    void StopOrbiting()
    {
        orbiting = false;
        followOrbit.StopOrbiting();
        if (Vector3.Distance(transform.position, target.position) > minDistance)
        {
            StartMovingCloser();
        }
    }

    void StartMovingCloser()
    {
        movingCloser = true;
        movingCloserTimer = movingCloserDuration;
        Vector3 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    void StopMovingCloser()
    {
        movingCloser = false;
        rb.velocity = Vector3.zero;
        StartOrbiting();
    }

    void StartOrbiting()
    {
        orbiting = true;
        orbitingTimer = orbitingDuration;
        shootingTimer = shootingInterval;
        followOrbit.StartOrbiting();
    }

    [SerializeField]
    private EnemyProjectile projectilePrefab;

    void Shoot()
    {
        Debug.Log("Distance: " + Vector3.Distance(transform.position, target.position) + "(" + minShootDistance + ") -> " + name);
        if (Vector3.Distance(transform.position, target.position) < minShootDistance) {
            EnemyProjectile projectile = Instantiate(projectilePrefab);
            SoundManager.main.PlaySound(SoundType.EnemyShoot);
            projectile.transform.position = transform.position;
            projectile.Initialize(target, 5f);
            animateShader.Pulse();
        }
    }

    void Update()
    {
        transform.LookAt(target);
        if (orbiting)
        {
            shootingTimer -= Time.deltaTime;
            if (shootingTimer <= 0)
            {
                Shoot();
                shootingTimer = shootingInterval;
            }
            orbitingTimer -= Time.deltaTime;
            if (orbitingTimer <= 0)
            {
                StopOrbiting();
            }
        }
        if (movingCloser)
        {
            movingCloserTimer -= Time.deltaTime;
            if (movingCloserTimer <= 0)
            {
                StopMovingCloser();
            }
        }
    }

    public void Die()
    {
        if (spawnOnDeath != null) {
            spawnOnDeath.SetActive(true);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile != null)
        {
            projectile.Die();
            Die();
        }
    }
}
