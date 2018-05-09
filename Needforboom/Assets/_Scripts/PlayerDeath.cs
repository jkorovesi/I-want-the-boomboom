using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    public static int winner = 2;
	// Update is called once per frame
	void Update () {
        if (TimerUI.explode)
        {
            switch (BombManager.playerWithBomb)
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
            Destroy(gameObject);
        }
	}
}
