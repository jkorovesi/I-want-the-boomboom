using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BombManager : MonoBehaviour {


    public static int playerWithBomb;
    public static bool playerHasBomb;

    private void Update()
    {
        if(TimerUI.explode == true)
        {
            StartCoroutine("endGame");

        }
    }


    IEnumerator endGame()
    {

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }
}
