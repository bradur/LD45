// Date   : 07.10.2019 19:01
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public void StartGame() {
        SceneManager.LoadScene(1);
    }
}
