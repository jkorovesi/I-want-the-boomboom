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

    public AudioSource audioSource;
    public AudioClip itemGet;
    public AudioClip bombGet;

    GameObject bumperObj;
    GameObject pikeObj;

    private void Awake()
    {

        image3 = GameObject.FindGameObjectWithTag("image3").GetComponent<Image>();

    }


    // Update is called once per frame
    void Update()
    {
        if (TimerManager.explode == true)
        {
            Destroy(this);
        }

        switch (p3Item)
            {
                case "Speed Boost":
                    image3.enabled = true;
                    image3.sprite = speedBoostImg;
                    if (Input.GetKeyDown(KeyCode.B) || Input.GetKey("joystick 3 button 3"))
                    {
                        StartCoroutine(SpeedTime());
                        playerController.speed = 60;
                        p3Item = null;
                        image3.enabled = false;
                    }
                    break;

                case "Bumper":
                    image3.enabled = true;
                    image3.sprite = bumperImg;
                    if (Input.GetKeyDown(KeyCode.B))
                    {
                        transform.localScale = new Vector3(1f, 1f, 1f);
                        Destroy(bumperObj);
                        bumperObj = Instantiate(bumperPref, bumperSpawn.position, bumperSpawn.rotation);
                        p3Item = null;
                        image3.enabled = false;
                    }
                    break;

                case "Size":
                    image3.enabled = true;
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
                        image3.enabled = false;
                    }
                    break;

                case "Push":
                    image3.enabled = true;
                    image3.sprite = pushImg;
                    if (Input.GetKeyDown(KeyCode.B) || Input.GetKey("joystick 3 button 3"))
                    {
                        transform.localScale = new Vector3(1f, 1f, 1f);
                        Instantiate(pushPref, pushSpawn.position, pushSpawn.rotation);
                        p3Item = null;
                        image3.enabled = false;
                    }
                    break;

                case "Pike":
                    image3.enabled = true;
                    image3.sprite = pikeImg;
                    if (Input.GetKeyDown(KeyCode.B) || Input.GetKey("joystick 3 button 3"))
                    {
                        transform.localScale = new Vector3(1f, 1f, 1f);
                        pikeObj = Instantiate(pikePrefab, pikeSpawn.position, pikeSpawn.rotation);
                        pikeObj.GetComponent<PikePosition>().pikeSpawnTransform = pikeSpawn;
                        pikeObj.transform.parent = this.transform;
                        p3Item = null;
                        image3.enabled = false;
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
            audioSource.PlayOneShot(itemGet);
            Destroy(coll.gameObject);



            SpawnItemScript.itemsOnStage--;
        }

        if (coll.gameObject.tag == "Bomb")
        {
            BombManager.playerWithBomb = 3;
            BombManager.playerHasBomb = true;
            audioSource.PlayOneShot(bombGet);
            Destroy(coll.gameObject);
        }
    }


}
