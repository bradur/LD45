// Date   : 05.10.2019 05:51
// Project: Game
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

    public static UIManager main;

    void Awake() {
        main = this;
    }

    [SerializeField]
    private CrossHair crossHair;
    [SerializeField]
    private AnimateTextPerCharacter animateMessage;
    [SerializeField]
    private AnimateTextPerCharacter animateInfo;

    public void MouseDetectObjectOn(List<string> messages, List<string> info) {
        crossHair.TurnOn();
        animateMessage.TurnOn(messages, 20f);
        animateInfo.TurnOn(info, 100f);
    }

    public void MouseDetectObjectOff() {
        crossHair.TurnOff();
        animateMessage.TurnOff();
        animateInfo.TurnOff();
    }

}
