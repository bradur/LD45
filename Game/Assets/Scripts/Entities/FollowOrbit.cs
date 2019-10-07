// Date   : 05.10.2019 20:47
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class FollowOrbit : MonoBehaviour
{

    private Transform orbitTarget;

    private bool isOrbiting = true;

    [SerializeField]
    private float degreesPerSecond = 15;

    void Start()
    {
        orbitTarget = GameObject.FindGameObjectWithTag("Dome").transform;
    }

    public void SetSpeed(float orbitSpeed) {
        degreesPerSecond = orbitSpeed;
    }

    public void StopOrbiting () {
        isOrbiting = false;
    }

    public void StartOrbiting() {
        isOrbiting = true;
    }

    void Update()
    {
        if (isOrbiting)
        {
            transform.RotateAround(
                orbitTarget.transform.position,
                Vector3.up,
                degreesPerSecond * Time.deltaTime
            );
        }
    }

}
