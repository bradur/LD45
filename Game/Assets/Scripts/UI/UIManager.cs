// Date   : 05.10.2019 05:51
// Project: Game
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    public static UIManager main;

    void Awake() {
        main = this;
    }

    [SerializeField]
    private CrossHair crossHair;
    [SerializeField]
    private AnimateTextPerCharacter animateText;

    public void MouseDetectObjectOn(string message) {
        crossHair.TurnOn();
        animateText.TurnOn(message);
    }

    public void MouseDetectObjectOff() {
        crossHair.TurnOff();
        animateText.TurnOff();
    }

}
