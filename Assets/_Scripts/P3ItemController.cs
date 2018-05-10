using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P3ItemController : MonoBehaviour
{


    public string p3Item;

    public Image image3;
    public Sprite speedBoostImg;
    public Sprite bumperImg;
    public Sprite sizeImg;
    public Sprite pushImg;
    public Sprite pikeImg;

    public P3Controller playerController;

    public GameObject bumperPref;
    public Transform bumperSpawn;
    public GameObject pikePrefab;
    public Transform pikeSpawn;
    public GameObject pushPref;
    public Transform pushSpawn;

    GameObject bumperObj;
    GameObject pikeObj;

    private void Awake()
    {

        image3 = GameObject.FindGameObjectWithTag("image3").GetComponent<Image>();

    }


    // Update is called once per frame
    void Update()
    {

            if (p3Item == null)
            {
                image3.sprite = null;
            }

            switch (p3Item)
            {
                case "Speed Boost":
                    image3.sprite = speedBoostImg;
                    if (Input.GetKeyDown(KeyCode.B) || Input.GetKey("joystick 3 button 3"))
                    {
                        StartCoroutine(SpeedTime());
                        playerController.speed = 60;
                        p3Item = null;
                    }
                    break;

                case "Bumper":
                    image3.sprite = bumperImg;
                    if (Input.GetKeyDown(KeyCode.B))
                    {
                        Destroy(bumperObj);
                        bumperObj = Instantiate(bumperPref, bumperSpawn.position, bumperSpawn.rotation);
                        p3Item = null;

                    }
                    break;

                case "Size":
                    image3.sprite = sizeImg;
                    if (Input.GetKeyDown(KeyCode.B) || Input.GetKey("joystick 3 button 3"))
                    {
                        StartCoroutine(SizeTime());
                        if (BombManager.playerWithBomb == 3)
                        {
                            transform.localScale = new Vector3(5f, 5f, 1f);
                        }
                        else
                        {
                            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                        }
                        p3Item = null;
                    }
                    break;

                case "Push":
                    image3.sprite = pushImg;
                    if (Input.GetKeyDown(KeyCode.B) || Input.GetKey("joystick 3 button 3"))
                    {
                        Instantiate(pushPref, pushSpawn.position, pushSpawn.rotation);
                        p3Item = null;
                    }
                    break;

                case "Pike":
                    image3.sprite = pikeImg;
                    if (Input.GetKeyDown(KeyCode.B) || Input.GetKey("joystick 3 button 3"))
                    {
                        pikeObj = Instantiate(pikePrefab, pikeSpawn.position, pikeSpawn.rotation);
                        pikeObj.GetComponent<PikePosition>().pikeSpawnTransform = pikeSpawn;
                        p3Item = null;
                    }
                    break;
            }

    }


    IEnumerator SpeedTime()
    {

        yield return new WaitForSeconds(5);
        playerController.speed = 35;
        yield break;

    }

    IEnumerator SizeTime()
    {

        yield return new WaitForSeconds(5);
        transform.localScale = new Vector3(1f, 1f, 1f);
        yield break;

    }

    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.tag == "Box")
        {

            p3Item = ItemGenerator.GetRandomItem();
            Destroy(coll.gameObject);



            SpawnItemScript.itemsOnStage--;
        }
    }


}
