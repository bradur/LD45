// Date   : 05.10.2019 04:16
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

/*[System.Serializable]
public class RayCastOnEvent : UnityEvent
{

}

[System.Serializable]
public class RayCastOutEvent : UnityEvent
{

}*/

public class RayCastDetectObject : MonoBehaviour {

    [SerializeField]
    private LayerMask targetLayers;
    [SerializeField]
    private float maxDistance = 1000;

    /*public RayCastOnEvent rayCastOnEvent;
    public RayCastOutEvent rayCastOutEvent;*/

    private List<PlayerMouseOverEffect> mouseOverEffects = new List<PlayerMouseOverEffect>();

    void Update () {
        RaycastHit hitInfo;
        bool somethingWasHit = Physics.Raycast(
            transform.position,
            transform.forward,
            out hitInfo,
            maxDistance,
            targetLayers,
            QueryTriggerInteraction.Collide
        );
        PlayerMouseOverEffect mouseOver = null;
        if (somethingWasHit) {
            GameObject hitObject = hitInfo.collider.gameObject;
            mouseOver = hitObject.GetComponent<PlayerMouseOverEffect>();
            if (mouseOver) {
                if (!mouseOverEffects.Contains(mouseOver)) {
                    mouseOverEffects.Add(mouseOver);
                    mouseOver.MouseOver();
                    //rayCastOnEvent.Invoke();
                }
            }
        }
        /*else if (mouseOverEffects.Count > 0) {
            rayCastOutEvent.Invoke();
        }*/
        for(int index = mouseOverEffects.Count - 1; index >= 0; index -= 1) {
            PlayerMouseOverEffect mouseOverEffect = mouseOverEffects[index];
            if (mouseOverEffect != mouseOver) {
                mouseOverEffect.MouseOut();
                mouseOverEffects.Remove(mouseOverEffect);
            }
        }
    }
}
