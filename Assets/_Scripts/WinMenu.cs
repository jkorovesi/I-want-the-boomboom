using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour {

    public GameObject restartObj;
    public GameObject menuObj;
    public GameObject winTextObj;
    public Text deadText;
    public Text winText;
    public Button restart;
    public Button menu;
    int winner;

	// Use this for initialization
	void Start () {
        Invoke("DisplayWinText", 3.0f);
        restart.onClick.AddListener(RestartGame);
        menu.onClick.AddListener(MenuGame);
    }
	
	// Update is called once per frame
	void Update () {
        winner = PlayerDeath.winner;
        deadText.text = ("Player " + winner + " has exploded...");
        winText.text = ("Player " + winner + " WINS!");
    }

    void DisplayWinText()
    {
        winTextObj.SetActive(true);
        restartObj.SetActive(true);
        menuObj.SetActive(true);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void MenuGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
