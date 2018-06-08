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

    public AudioSource audioSource;
    public AudioClip itemGet;
    public AudioClip bombGet;

    GameObject bumperObj;
    GameObject pikeObj;

    private void Awake()
    {

        image2 = GameObject.FindGameObjectWithTag("image2").GetComponent<Image>();

    }


    // Update is called once per frame
    void Update()
    {
        if (TimerManager.explode == true)
        {
            Destroy(this);
        }



        if (this.tag == "Player2")
        {


            switch (p2Item)
            {
                case "Speed Boost":
                    image2.enabled = true;
                    image2.sprite = speedBoostImg;
                    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey("joystick 2 button 3"))
                    {
                        StartCoroutine(SpeedTime());
                        playerController.speed = 60;
                        p2Item = null;
                        image2.enabled = false;
                    }
                    break;

                case "Bumper":
                    image2.enabled = true;
                    image2.sprite = bumperImg;
                    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey("joystick 2 button 3"))
                    {
                        transform.localScale = new Vector3(1f, 1f, 1f);
                        Destroy(bumperObj);
                        bumperObj = Instantiate(bumperPref, bumperSpawn.position, bumperSpawn.rotation);
                        p2Item = null;
                        image2.enabled = false;

                    }
                    break;

                case "Size":
                    image2.enabled = true;
                    image2.sprite = sizeImg;
                    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey("joystick 2 button 3"))
                    {
                        StartCoroutine(SizeTime());
                        if (BombManager.playerWithBomb == 2)
                        {
                            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                        }
                        else
                        {
                            
                            transform.localScale = new Vector3(4f, 4f, 1f);
                        }
                        p2Item = null;
                        image2.enabled = false;
                    }
                    break;

                case "Push":
                    image2.enabled = true;
                    image2.sprite = pushImg;
                    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey("joystick 2 button 3"))
                    {
                        transform.localScale = new Vector3(1f, 1f, 1f);
                        Instantiate(pushPref, pushSpawn.position, pushSpawn.rotation);
                        p2Item = null;
                        image2.enabled = false;
                    }
                    break;

                case "Pike":
                    image2.enabled = true;
                    image2.sprite = pikeImg;
                    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey("joystick 2 button 3"))
                    {
                        transform.localScale = new Vector3(1f, 1f, 1f);
                        pikeObj = Instantiate(pikePrefab, pikeSpawn.position, pikeSpawn.rotation);
                        pikeObj.GetComponent<PikePosition>().pikeSpawnTransform = pikeSpawn;
                        pikeObj.transform.parent = this.transform;
                        p2Item = null;
                        image2.enabled = false;
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
                audioSource.PlayOneShot(itemGet);
                Destroy(coll.gameObject);



            SpawnItemScript.itemsOnStage--;
        }

        if (coll.gameObject.tag == "Bomb")
        {
            BombManager.playerWithBomb = 2;
            BombManager.playerHasBomb = true;
            audioSource.PlayOneShot(bombGet);
            Destroy(coll.gameObject);
        }
    }


}
