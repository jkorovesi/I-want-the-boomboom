using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBomb : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
            BombManager.playerWithBomb = 1;
            BombManager.playerHasBomb = true;
            Destroy(gameObject);
        }
        if (other.tag == "Player2")
        {
            BombManager.playerWithBomb = 2;
            BombManager.playerHasBomb = true;
            Destroy(gameObject);
        }
        if (other.tag == "Player3")
        {
            BombManager.playerWithBomb = 3;
            BombManager.playerHasBomb = true;
            Destroy(gameObject);
        }

    }
}
