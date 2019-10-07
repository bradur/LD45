// Date   : 08.10.2019 01:40
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;

public class TheEnd : MonoBehaviour {

    void Start () {
    
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Q)) {
            Application.Quit();
        }
    }
}
