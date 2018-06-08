using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1ItemController : MonoBehaviour
{


    public string p1Item;

    public Image image1;
    public Sprite speedBoostImg;
    public Sprite bumperImg;
    public Sprite sizeImg;
    public Sprite pushImg;
    public Sprite pikeImg;

    public P1Controller playerController;

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

        image1 = GameObject.FindGameObjectWithTag("image1").GetComponent<Image>();


    }


    // Update is called once per frame
    void Update()
    {

        if (TimerManager.explode == true)
        {
            Destroy(this);
        }


        switch (p1Item)
            {
                case "Speed Boost":
                image1.enabled = true;
                image1.sprite = speedBoostImg;
                    if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKey("joystick 1 button 3"))
                    {
                        StartCoroutine(SpeedTime());
                        playerController.speed = 60;
                        p1Item = null;
                        image1.enabled = false;
                    }
                    break;

                case "Bumper":
                image1.enabled = true;
                image1.sprite = bumperImg;
                    if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKey("joystick 1 button 3"))
                    {
                        transform.localScale = new Vector3(1f, 1f, 1f);
                        Destroy(bumperObj);
                        bumperObj = Instantiate(bumperPref, bumperSpawn.position, bumperSpawn.rotation);
                        p1Item = null;
                        image1.enabled = false;
                    }
                    break;

                case "Size":
                image1.enabled = true;
                image1.sprite = sizeImg;
                    if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKey("joystick 1 button 3"))
                    {
                        StartCoroutine(SizeTime());
                        if (BombManager.playerWithBomb == 1)
                        {
                            
                            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                        }
                        else
                        {
                            transform.localScale = new Vector3(4f, 4f, 1f);
                        }
                        p1Item = null;
                        image1.enabled = false;
                    }
                    break;

                case "Push":
                image1.enabled = true;
                image1.sprite = pushImg;
                    if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKey("joystick 1 button 3"))
                    {
                        transform.localScale = new Vector3(1f, 1f, 1f);
                        Instantiate(pushPref, pushSpawn.position, pushSpawn.rotation);
                        p1Item = null;
                        image1.enabled = false;
                    }
                    break;

                case "Pike":
                image1.enabled = true;
                image1.sprite = pikeImg;
                    if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKey("joystick 1 button 3"))
                    {
                        transform.localScale = new Vector3(1f, 1f, 1f);
                        pikeObj = Instantiate(pikePrefab, pikeSpawn.position, pikeSpawn.rotation);
                        pikeObj.GetComponent<PikePosition>().pikeSpawnTransform = pikeSpawn;
                        pikeObj.transform.parent = this.transform;
                        p1Item = null;
                        image1.enabled = false;
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

            p1Item = ItemGenerator.GetRandomItem();
            audioSource.PlayOneShot(itemGet);
            Destroy(coll.gameObject);



            SpawnItemScript.itemsOnStage--;
        }

        if (coll.gameObject.tag == "Bomb")
        {
            BombManager.playerWithBomb = 1;
            BombManager.playerHasBomb = true;
            audioSource.PlayOneShot(bombGet);
            Destroy(coll.gameObject);
        }
    }


}
