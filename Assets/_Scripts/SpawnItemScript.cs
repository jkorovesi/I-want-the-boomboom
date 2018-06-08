using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemScript : MonoBehaviour
{

    public float sphereRadius = 2;
    public Transform bombSpawn;
    public GameObject bomb;
    public Transform[] itemSpawn;
    public GameObject itemBox;
    public static int itemsOnStage = 0;



    // Use this for initialization
    void Awake()
    {
        itemsOnStage = 0;
        SpawnBomb();
        InvokeRepeating("SpawnItem", 2.0f, 5.0f);
    }



    public void SpawnBomb()
    {
        Instantiate(bomb, bombSpawn.transform.position, bombSpawn.transform.rotation);

    }

    public void SpawnItem()
    {
        
        if(itemsOnStage >= 8)
        {
            return;
        }
        int spawnPointIndex = Random.Range(0, itemSpawn.Length);

        if (Physics2D.OverlapCircle(itemSpawn[spawnPointIndex].position, 2, 1 << 8))
        {
            SpawnItem();
        }
        else
        {
            Instantiate(itemBox, itemSpawn[spawnPointIndex].position, itemSpawn[spawnPointIndex].rotation);
            itemsOnStage++;
        }



    }

}
