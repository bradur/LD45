// Date   : 05.10.2019 16:17
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Drone : MonoBehaviour
{

    private bool targeted = false;

    private TurnUpTheLight turnUpTheLight;
    private RotateRandomly rotateRandomly;
    private PerlinFlickerLightIntensity flickerLightIntensity;
    private AnimateShaderColorPropertyIntensity animateIntensity;
    private FollowOrbit orbiter;

    [SerializeField]
    private Light innerLight;

    [SerializeField]
    private float repairedOrbitSpeed = 5f;

    [SerializeField]
    private float originalOrbitSpeed = 1f;

    [SerializeField]
    private bool needsRepair = true;

    [SerializeField]
    [TextArea]
    private List<string> messages;

    [SerializeField]
    [TextArea]
    private List<string> repairedMessages;

    private void Start()
    {
        turnUpTheLight = GetComponent<TurnUpTheLight>();
        rotateRandomly = GetComponent<RotateRandomly>();
        flickerLightIntensity = GetComponent<PerlinFlickerLightIntensity>();
        orbiter = GetComponent<FollowOrbit>();
        animateIntensity = GetComponent<AnimateShaderColorPropertyIntensity>();
        orbiter.SetSpeed(originalOrbitSpeed);
    }

    public void Repair()
    {
        if (innerLight) {
            innerLight.enabled = true;
        }
        if (rotateRandomly)
        {
            rotateRandomly.enabled = true;
        }
        if (turnUpTheLight)
        {
            turnUpTheLight.TurnUp();
        }
        if (animateIntensity) {
            animateIntensity.enabled = true;
        }
        needsRepair = false;
        /*if (flickerLightIntensity) {
            flickerLightIntensity.enabled = true;
        }*/

        orbiter.SetSpeed(repairedOrbitSpeed);
    }

    public void TargetOn()
    {
        targeted = true;
        UIManager.main.MouseDetectObjectOn(needsRepair ? messages : repairedMessages);
        orbiter.SetSpeed(0);
    }

    public void TargetOff()
    {
        targeted = false;
        UIManager.main.MouseDetectObjectOff();
        orbiter.SetSpeed(needsRepair ? originalOrbitSpeed : repairedOrbitSpeed);
    }

    public void OnChildCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Fuel" && gameObject.tag == "Drone" && needsRepair)
        {
            Repair();
            Planetoid planetoid = collision.gameObject.GetComponentInParent<Planetoid>();
            planetoid.Die();
        }
    }
    public void OnChildCollisionExit(Collision collision)
    {
        //Debug.Log(collision);
    }
    public void OnChildCollisionStay(Collision collision)
    {
        //Debug.Log(collision);
    }
}
