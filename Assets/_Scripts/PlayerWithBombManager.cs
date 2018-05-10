using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWithBombManager : MonoBehaviour {

    public Text playerWithBombText;

    private void Update()
    {
        if (BombManager.playerHasBomb)
        {
            playerWithBombText.text = "Player with bomb \n" + BombManager.playerWithBomb;
        }
        else
        {
            playerWithBombText.text = "Player with bomb \n None";
        }

    }
}
