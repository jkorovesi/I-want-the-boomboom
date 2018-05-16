using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour {

    private SpawnPlayerScript spawnPlayerScript;

	// Use this for initialization
	void Start () {
        spawnPlayerScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnPlayerScript>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1")
        {
            Destroy(other.gameObject);
            spawnPlayerScript.player1Exist = false;
            spawnPlayerScript.SpawnPlayer1();
            

        }
        if (other.gameObject.tag == "Player2")
        {
            Destroy(other.gameObject);
            spawnPlayerScript.player2Exist = false;
            spawnPlayerScript.SpawnPlayer2();


        }
        if (other.gameObject.tag == "Player3")
        {
            Destroy(other.gameObject);
            spawnPlayerScript.player3Exist = false;
            spawnPlayerScript.SpawnPlayer3();


        }

    }
}
