using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float rotationSpeed;
    public GameObject highlight;
    public AudioSource audioSource;
    public AudioClip accelerate;
    public AudioClip bombGet;

    //SpawnPlayerScript spawnPlayerScript;

    void Start()
    {

    }

    private void Update()
    {
        if (BombManager.playerWithBomb == 1)
        {
            highlight.SetActive(true);
        }
        else
        {
            highlight.SetActive(false);
        }

        if(TimerManager.explode == true)
        {
            Destroy(this);
        }
        //if (Input.GetKey("joystick button 0"))
        //{
        //    Debug.Log(Input.GetJoystickNames() + "Controller In");

        //}


    }

    private void Awake()
    {
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {


        if (gameObject.tag == "Player1")
        {
            Vector3 joyDirection = Vector3.zero;
            joyDirection.z = Input.GetAxis("Player1Steer");
            transform.Rotate(joyDirection * -rotationSpeed);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.forward * -rotationSpeed);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.forward * rotationSpeed);
            }

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("joystick 1 button 0"))
            {
                rb.AddForce(gameObject.transform.up * speed);
                audioSource.clip = accelerate;
                audioSource.Play();
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("joystick 1 button 1"))
            {
                rb.AddForce(gameObject.transform.up * -speed);

            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Player2" && BombManager.playerWithBomb == 2 && ImmuneChecker.p2Immune == false)
        {
            BombManager.playerWithBomb = 1;
            audioSource.PlayOneShot(bombGet);
            Debug.Log(BombManager.playerWithBomb);
            StartCoroutine("immuneClock");

        }

        if (coll.gameObject.tag == "Player3" && BombManager.playerWithBomb == 3 && ImmuneChecker.p3Immune == false)
        {
            BombManager.playerWithBomb = 1;
            audioSource.PlayOneShot(bombGet);
            Debug.Log(BombManager.playerWithBomb);
            StartCoroutine("immuneClock");

        }


    }



    IEnumerator immuneClock()
    {

        ImmuneChecker.p1Immune = true;
        yield return new WaitForSeconds(2);
        ImmuneChecker.p1Immune = false;


    }


}
