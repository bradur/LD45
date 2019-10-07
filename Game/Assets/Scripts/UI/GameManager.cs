// Date   : 07.10.2019 19:01
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager main;

    void Awake()
    {
        main = this;
        Time.timeScale = 1f;
    }

    [SerializeField]
    private GameObject gameOverScreen;
    [SerializeField]
    private GameObject escScreen;
    private bool toRestart = false;
    private bool escMenu = false;
    void Update()
    {
        if ((escMenu || toRestart) && Input.GetKeyDown(KeyCode.R))
        {
            StartGame();
        }
        if ((escMenu || toRestart) && Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenEscMenu();
        }
    }

    public void OpenEscMenu() {
        if (!toRestart) {
            if (!escMenu) {
                escScreen.SetActive(true);
                Time.timeScale = 0f;
            } else {
                escScreen.SetActive(false);
                Time.timeScale = 1f;
            }
            escMenu = !escMenu;
        }
    }

    public void GameOver()
    {
        Debug.Log("Game over!");
        toRestart = true;
        gameOverScreen.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
