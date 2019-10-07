// Date   : 05.10.2019 16:11
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class MouseDrag3D : MonoBehaviour
{

    private Transform playerFollower;
    private Transform originalParent;

    [SerializeField]
    private bool forDrone = false;

    private bool dragging = false;
    public bool Dragging { get { return dragging; } }
    private void Start()
    {
        originalParent = transform.parent;
        if (forDrone)
        {
            playerFollower = GameObject.FindGameObjectWithTag("PlayerFollowerDrone").transform;
        }
        else
        {
            playerFollower = GameObject.FindGameObjectWithTag("PlayerFollower").transform;

        }
    }
    public void StartDragging()
    {
        if (!dragging)
        {
            //Debug.Log("Start dragging " + playerFollower.name);
            dragging = true;

            transform.SetParent(playerFollower, true);
        }
    }

    /*void Update() {
        if (dragging) {
            transform.RotateAround(
                playerFollower.transform.position,
                Vector3.up,
                playerFollower.transform.eulerAngles.y
            );
        }
    }*/

    public void StopDragging()
    {
        if (dragging)
        {
            Debug.Log("STOP dragging");
            dragging = false;
            transform.SetParent(originalParent, true);
        }
    }
}
