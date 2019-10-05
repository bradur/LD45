// Date   : 05.10.2019 05:51
// Project: Game
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private CrossHair crossHair;
    [SerializeField]
    private AnimateTextPerCharacter animateText;

    public void MouseDetectObjectOn() {
        crossHair.TurnOn();
        animateText.TurnOn("Test this thing\n how about next row?\nnice!");
    }

    public void MouseDetectObjectOff() {
        crossHair.TurnOff();
        animateText.TurnOff();
    }

}
