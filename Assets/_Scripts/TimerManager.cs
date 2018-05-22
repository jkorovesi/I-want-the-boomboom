using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{

    public int timeLeft = 10;
    public Text countdownText;
    public bool timerRunning = false;
    public static bool explode;

    // Use this for initialization
    void Awake()
    {
        explode = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = ("Time Left " + timeLeft);

        if (BombManager.playerHasBomb && !timerRunning)
        {
            StartCoroutine("LoseTime");
            timerRunning = true;
        }
        else if(!BombManager.playerHasBomb && timerRunning)
        {
            StopCoroutine("LoseTime");
            timerRunning = false;
        }

        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            explode = true;

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
