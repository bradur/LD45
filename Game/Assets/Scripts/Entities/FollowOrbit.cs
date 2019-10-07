// Date   : 05.10.2019 20:47
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class FollowOrbit : MonoBehaviour
{

    [SerializeField]
    private Transform orbitTarget;

    private bool isOrbiting = true;

    [SerializeField]
    private float degreesPerSecond = 15;

    void Start()
    {

    }

    public void SetSpeed(float orbitSpeed) {
        degreesPerSecond = orbitSpeed;
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
