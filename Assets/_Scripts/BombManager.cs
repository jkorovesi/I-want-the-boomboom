using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BombManager : MonoBehaviour {


    public static int playerWithBomb;
    public static bool playerHasBomb;
    public static int winner;
    public Text boomText;

    private void Awake()
    {

        playerHasBomb = false;
        playerWithBomb = 0;
    }

    private void Update()
    {
        if(TimerManager.explode)
        {
            switch (playerWithBomb)
            {
                case 1:
                    winner = 1;
                    break;

                case 2:
                    winner = 2;
                    break;

                case 3:
                    winner = 3;
                    break;


            }
            StartCoroutine("endGame");
            

        }
    }


    IEnumerator endGame()
    {

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }

}
