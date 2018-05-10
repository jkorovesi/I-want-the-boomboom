//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class ItemController : MonoBehaviour {

//    public string p1Item;
//    public string p2Item;
//    public string p3Item;
//    Image image1;
//    public Image image2;
//    public Image image3;
//    public Sprite speedBoostImg;
//    public Sprite bumperImg;
//    public Sprite sizeImg;
//    public Sprite pushImg;
//    public Sprite pikeImg;
//    //public PlayerController playerController;
//    public GameObject bumperPref;
//    public Transform bumperSpawn;
//    public GameObject pikePrefab;
//    public Transform pikeSpawn;
//    public GameObject pushPref;
//    public Transform pushSpawn;

//    GameObject bumperObj;
//    GameObject pikeObj;

//    private void Awake()
//    {
//        image1 = GameObject.FindGameObjectWithTag("image1").GetComponent<Image>();
//        image2 = GameObject.FindGameObjectWithTag("image2").GetComponent<Image>();
//        image3 = GameObject.FindGameObjectWithTag("image3").GetComponent<Image>();
//    }


//    // Update is called once per frame
//    void Update () {


//        if (this.tag == "Player1")
//        {
//            if (p1Item == null)
//            {
//                image1.sprite = null;
//            }

//            switch (p1Item)
//            {
//                case "Speed Boost":
//                    image1.sprite = speedBoostImg;
//                    if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKey("joystick 1 button 3"))
//                    {
//                        StartCoroutine(SpeedTime());
//                        playerController.speed = 35;
//                        p1Item = null;
//                    }
//                    break;

//                case "Bumper":
//                    image1.sprite = bumperImg;
//                    if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKey("joystick 1 button 3"))
//                    {
//                        Destroy(bumperObj);
//                        bumperObj = Instantiate(bumperPref, bumperSpawn.position, bumperSpawn.rotation);
//                        p1Item = null;
                        
//                    }
//                    break;

//                case "Size":
//                    image1.sprite = sizeImg;
//                    if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKey("joystick 1 button 3"))
//                    {
//                        StartCoroutine(SizeTime());
//                        if (BombManager.playerWithBomb == 1)
//                        {
//                            transform.localScale = new Vector3(5f, 5f, 1f);
//                        } else
//                        {
//                            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
//                        }
//                        p1Item = null;
//                    }
//                    break;

//                case "Push":
//                    image1.sprite = pushImg;
//                    if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKey("joystick 1 button 3"))
//                    {
//                        Instantiate(pushPref, pushSpawn.position, pushSpawn.rotation);
//                        p1Item = null;
//                    }
//                    break;

//                case "Pike":
//                    image1.sprite = pikeImg;
//                    if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKey("joystick 1 button 3"))
//                    {
//                        pikeObj = Instantiate(pikePrefab, pikeSpawn.position, pikeSpawn.rotation);
//                        pikeObj.GetComponent<PikePosition>().pikeSpawnTransform = pikeSpawn;
//                        p1Item = null;
//                    }
//                    break;
//            }
//        }

//        if (this.tag == "Player2")
//        {
//            if (p2Item == null)
//            {
//                image2.sprite = null;
//            }

//            switch (p2Item)
//            {
//                case "Speed Boost":
//                    image2.sprite = speedBoostImg;
//                    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey("joystick 2 button 3"))
//                    {
//                        StartCoroutine(SpeedTime());
//                        playerController.speed = 35;
//                        p2Item = null;
//                    }
//                    break;

//                case "Bumper":
//                    image2.sprite = bumperImg;
//                    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey("joystick 2 button 3"))
//                    {
//                        Destroy(bumperObj);
//                        bumperObj = Instantiate(bumperPref, bumperSpawn.position, bumperSpawn.rotation);
//                        p2Item = null;

//                    }
//                    break;

//                case "Size":
//                    image2.sprite = sizeImg;
//                    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey("joystick 2 button 3"))
//                    {
//                        StartCoroutine(SizeTime());
//                        if (BombManager.playerWithBomb == 2)
//                        {
//                            transform.localScale = new Vector3(5f, 5f, 1f);
//                        }
//                        else
//                        {
//                            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
//                        }
//                        p2Item = null;
//                    }
//                    break;

//                case "Push":
//                    image2.sprite = pushImg;
//                    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey("joystick 2 button 3"))
//                    {
//                        Instantiate(pushPref, pushSpawn.position, pushSpawn.rotation);
//                        p2Item = null;
//                    }
//                    break;

//                case "Pike":
//                    image2.sprite = pikeImg;
//                    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey("joystick 2 button 3"))
//                    {
//                        pikeObj = Instantiate(pikePrefab, pikeSpawn.position, pikeSpawn.rotation);
//                        pikeObj.GetComponent<PikePosition>().pikeSpawnTransform = pikeSpawn;
//                        p2Item = null;
//                    }
//                    break;
//            }
//        }

//        if (this.tag == "Player3")
//        {
//            if (p3Item == null)
//            {
//                image3.sprite = null;
//            }

//            switch (p3Item)
//            {
//                case "Speed Boost":
//                    image3.sprite = speedBoostImg;
//                    if (Input.GetKeyDown(KeyCode.B) || Input.GetKey("joystick 3 button 3"))
//                    {
//                        StartCoroutine(SpeedTime());
//                        playerController.speed = 35;
//                        p3Item = null;
//                    }
//                    break;

//                case "Bumper":
//                    image3.sprite = bumperImg;
//                    if (Input.GetKeyDown(KeyCode.B))
//                    {
//                        Destroy(bumperObj);
//                        bumperObj = Instantiate(bumperPref, bumperSpawn.position, bumperSpawn.rotation);
//                        p3Item = null;

//                    }
//                    break;

//                case "Size":
//                    image3.sprite = sizeImg;
//                    if (Input.GetKeyDown(KeyCode.B) || Input.GetKey("joystick 3 button 3"))
//                    {
//                        StartCoroutine(SizeTime());
//                        if (BombManager.playerWithBomb == 3)
//                        {
//                            transform.localScale = new Vector3(5f, 5f, 1f);
//                        }
//                        else
//                        {
//                            transform.localScale = new Vector3(0.5f, 0.5f, 1f);
//                        }
//                        p3Item = null;
//                    }
//                    break;

//                case "Push":
//                    image3.sprite = pushImg;
//                    if (Input.GetKeyDown(KeyCode.B) || Input.GetKey("joystick 3 button 3"))
//                    {
//                        Instantiate(pushPref, pushSpawn.position, pushSpawn.rotation);
//                        p3Item = null;
//                    }
//                    break;

//                case "Pike":
//                    image3.sprite = pikeImg;
//                    if (Input.GetKeyDown(KeyCode.B) || Input.GetKey("joystick 3 button 3"))
//                    {
//                        pikeObj = Instantiate(pikePrefab, pikeSpawn.position, pikeSpawn.rotation);
//                        pikeObj.GetComponent<PikePosition>().pikeSpawnTransform = pikeSpawn;
//                        p3Item = null;
//                    }
//                    break;
//            }
//        }

//    }


//    IEnumerator SpeedTime()
//    {

//        yield return new WaitForSeconds(5);
//        playerController.speed = 15;
//        yield break;

//    }

//    IEnumerator SizeTime()
//    {

//        yield return new WaitForSeconds(5);
//        transform.localScale = new Vector3(1f, 1f, 1f);
//        yield break;

//    }

//    private void OnTriggerEnter2D(Collider2D coll)
//    {

//        if (coll.tag == "Box")
//        {

//            if (gameObject.tag == "Player1")
//            {
//                p1Item = ItemGenerator.GetRandomItem();
//                Destroy(coll.gameObject);
//            }
//            if (gameObject.tag == "Player2")
//            {
//                p2Item = ItemGenerator.GetRandomItem();
//                Destroy(coll.gameObject);
//            }
//            if (gameObject.tag == "Player3")
//            {
//                p3Item = ItemGenerator.GetRandomItem();
//                Destroy(coll.gameObject);
//            }


//            SpawnItemScript.itemsOnStage--;
//        }
//    }


//}
