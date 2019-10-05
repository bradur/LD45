// Date   : 05.10.2019 04:25
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[System.Serializable]
public class PlayerMouseOverEffectEvent : UnityEvent
{

}

[System.Serializable]
public class PlayerMouseOutEffectEvent : UnityEvent
{

}


public class PlayerMouseOverEffect : MonoBehaviour {

    [SerializeField]
    public PlayerMouseOverEffectEvent playerMouseOverEffectEvent;

    [SerializeField]
    public PlayerMouseOutEffectEvent playerMouseOutEffectEvent;

    public void MouseOver() {
        if (playerMouseOverEffectEvent == null)
        {
            playerMouseOverEffectEvent = new PlayerMouseOverEffectEvent();
        }
        playerMouseOverEffectEvent.Invoke();
        Debug.Log("MouseOver: " + name);
    }

    public void MouseOut() {
        if (playerMouseOutEffectEvent == null)
        {
            playerMouseOutEffectEvent = new PlayerMouseOutEffectEvent();
        }
        playerMouseOutEffectEvent.Invoke();
        Debug.Log("MouseOut: " + name);
    }
}
