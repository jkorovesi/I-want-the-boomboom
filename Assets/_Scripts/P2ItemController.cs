using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2ItemController : MonoBehaviour
{


    public string p2Item;

    public Image image2;
    public Sprite speedBoostImg;
    public Sprite bumperImg;
    public Sprite sizeImg;
    public Sprite pushImg;
    public Sprite pikeImg;

    public P2Controller playerController;

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

        image2 = GameObject.FindGameObjectWithTag("image2").GetComponent<Image>();

    }


    // Update is called once per frame
    void Update()
    {


       

        if (this.tag == "Player2")
        {
            if (p2Item == null)
            {
                image2.sprite = null;
            }

            switch (p2Item)
            {
                case "Speed Boost":
                    image2.sprite = speedBoostImg;
                    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey("joystick 2 button 3"))
                    {
                        StartCoroutine(SpeedTime());
                        playerController.speed = 60;
                        p2Item = null;
                    }
                    break;

                case "Bumper":
                    image2.sprite = bumperImg;
                    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey("joystick 2 button 3"))
                    {
                        Destroy(bumperObj);
                        bumperObj = Instantiate(bumperPref, bumperSpawn.position, bumperSpawn.rotation);
                        p2Item = null;

                    }
                    break;

                case "Size":
                    image2.sprite = sizeImg;
                    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey("joystick 2 button 3"))
                    {
                        StartCoroutine(SizeTime());
                        if (BombManager.playerWithBomb == 2)
                        {
                            transform.localScale = new Vector3(5f, 5f, 1f);
                        }
                        else
                        {
                            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                        }
                        p2Item = null;
                    }
                    break;

                case "Push":
                    image2.sprite = pushImg;
                    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey("joystick 2 button 3"))
                    {
                        Instantiate(pushPref, pushSpawn.position, pushSpawn.rotation);
                        p2Item = null;
                    }
                    break;

                case "Pike":
                    image2.sprite = pikeImg;
                    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey("joystick 2 button 3"))
                    {
                        pikeObj = Instantiate(pikePrefab, pikeSpawn.position, pikeSpawn.rotation);
                        pikeObj.GetComponent<PikePosition>().pikeSpawnTransform = pikeSpawn;
                        p2Item = null;
                    }
                    break;
            }
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

                p2Item = ItemGenerator.GetRandomItem();
                Destroy(coll.gameObject);



            SpawnItemScript.itemsOnStage--;
        }
    }


}
