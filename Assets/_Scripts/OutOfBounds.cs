using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutOfBounds : MonoBehaviour {

    public Image p1Image;
    public Image p2Image;
    public Image p3Image;

    private SpawnPlayerScript spawnPlayerScript;
    private SpawnItemScript spawnItemScript;

    // Use this for initialization
    void Start () {
        spawnPlayerScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnPlayerScript>();
        spawnItemScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnItemScript>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1")
        {
            if(BombManager.playerWithBomb == 1)
            {
                BombManager.playerWithBomb = 0;
                BombManager.playerHasBomb = false;
                spawnItemScript.SpawnBomb();
                
            }
            Destroy(other.gameObject);
            spawnPlayerScript.player1Exist = false;
            spawnPlayerScript.SpawnPlayer1();
            p1Image.sprite = null;
            

        }
        if (other.gameObject.tag == "Player2")
        {
            if (BombManager.playerWithBomb == 2)
            {
                BombManager.playerWithBomb = 0;
                BombManager.playerHasBomb = false;
                spawnItemScript.SpawnBomb();

            }
            Destroy(other.gameObject);
            spawnPlayerScript.player2Exist = false;
            spawnPlayerScript.SpawnPlayer2();
            p2Image.sprite = null;


        }
        if (other.gameObject.tag == "Player3")
        {
            if (BombManager.playerWithBomb == 3)
            {
                BombManager.playerWithBomb = 0;
                BombManager.playerHasBomb = false;
                spawnItemScript.SpawnBomb();

            }
            Destroy(other.gameObject);
            spawnPlayerScript.player3Exist = false;
            spawnPlayerScript.SpawnPlayer3();
            p3Image.sprite = null;


        }

    }
}
