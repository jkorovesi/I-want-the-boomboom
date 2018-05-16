using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{

    public int timeLeft = 60;
    public Text countdownText;
    public bool timerRunning = false;
    public static bool explode = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = ("Time Left \n" + timeLeft);

        if (BombManager.playerHasBomb && !timerRunning)
        {
            StartCoroutine("LoseTime");
            timerRunning = true;
        }

        if(!BombManager.playerHasBomb && timerRunning)
        {
            StopCoroutine("LoseTime");
            timerRunning = false;
        }

        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            explode = true;
            countdownText.text = "BOOM!";
        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
