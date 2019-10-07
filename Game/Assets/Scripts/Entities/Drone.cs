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
    private bool draggable = true;
    private MouseDrag3D mouseDrag3D;

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
    private List<string> info;


    [SerializeField]
    [TextArea]
    private List<string> repairedInfo;

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
        mouseDrag3D = GetComponent<MouseDrag3D>();
    }

    public void Repair()
    {
        if (innerLight)
        {
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
        if (animateIntensity)
        {
            animateIntensity.enabled = true;
        }
        needsRepair = false;
        /*if (flickerLightIntensity) {
            flickerLightIntensity.enabled = true;
        }*/

        /*if (mouseDrag3D) {
            mouseDrag3D.enabled = true;
        }*/
        orbiter.SetSpeed(repairedOrbitSpeed);
    }


    private void Update()
    {
        if (draggable && mouseDrag3D)
        {
            if (Input.GetMouseButton(0))
            {
                if (targeted)
                {
                    mouseDrag3D.StartDragging();
                }
            }
            else
            {
                if (mouseDrag3D.Dragging && !targeted)
                {
                    TargetOffForReal();
                }
                mouseDrag3D.StopDragging();
            }
        }
    }

    public void TargetOn()
    {
        targeted = true;
        if (!mouseDrag3D.Dragging)
        {
            TargetOnForReal();
        }
    }

    private void TargetOnForReal()
    {
        UIManager.main.MouseDetectObjectOn(
            needsRepair ? messages : repairedMessages,
            needsRepair ? info : repairedInfo
        );
        orbiter.StopOrbiting();
    }

    private void TargetOffForReal()
    {
        orbiter.SetSpeed(needsRepair ? originalOrbitSpeed : repairedOrbitSpeed);
        UIManager.main.MouseDetectObjectOff();
        orbiter.StartOrbiting();

    }

    public void TargetOff()
    {
        targeted = false;
        if (!mouseDrag3D.Dragging)
        {
            TargetOffForReal();
        }
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
