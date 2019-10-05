// Date   : 05.10.2019 16:11
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class MouseDrag3D : MonoBehaviour
{

    private Transform playerFollower;
    private Transform originalParent;

    private bool dragging = false;
    private void Start()
    {
        originalParent = transform.parent;
        playerFollower = GameObject.FindGameObjectWithTag("PlayerFollower").transform;
    }
    public void StartDragging()
    {
        if (!dragging)
        {
            Debug.Log("Start dragging");
            dragging = true;
            transform.SetParent(playerFollower, true);
        }
    }

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
