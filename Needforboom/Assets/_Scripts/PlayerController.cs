using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float rotationSpeed;
    bool bufferBool = true;


    private Transform myTrans;
    private AudioSource[] audioSource;
    private AudioSource engMoving;
    private AudioSource engAccl;
    private AudioSource engIdle;
    private AudioSource engBrake;
    private AudioSource engReverse;
    private AudioSource getBomb;
    private AudioSource getItem;

    SpawnPlayerScript spawnPlayerScript;

    void Start()
    {

        audioSource = gameObject.GetComponents<AudioSource>();
        engIdle = audioSource[0];
        engAccl = audioSource[1];
        engMoving = audioSource[2];
        engBrake = audioSource[3];
        engReverse = audioSource[4];
        getBomb = audioSource[5];
        getItem = audioSource[6];
    }

    private void Update()
    {

        if (Input.GetKey("joystick button 0"))
        {
            Debug.Log(Input.GetJoystickNames() + "Controller In");

        }
    }

    private void Awake()
    {
        spawnPlayerScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnPlayerScript>();
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
                engMoving.Play();
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("joystick 1 button 1"))
            {
                rb.AddForce(gameObject.transform.up * -speed);
                //PlayOneShot(engIdle);
            }
        }
        if (gameObject.tag == "Player2")
        {
            Vector3 joyDirection = Vector3.zero;
            joyDirection.z = Input.GetAxis("Player2Steer");
            transform.Rotate(joyDirection * -rotationSpeed);

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.forward * -rotationSpeed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward * rotationSpeed);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey("joystick 2 button 0"))
            {
                rb.AddForce(gameObject.transform.up * speed);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey("joystick 2 button 1"))
            {
                rb.AddForce(gameObject.transform.up * -speed);
            }
        }

        if (gameObject.tag == "Player3")
        {
            Vector3 joyDirection = Vector3.zero;
            joyDirection.z = Input.GetAxis("Player3Steer");
            transform.Rotate(joyDirection * -rotationSpeed);

            if (Input.GetKey(KeyCode.L))
            {
                transform.Rotate(Vector3.forward * -rotationSpeed);
            }
            if (Input.GetKey(KeyCode.J))
            {
                transform.Rotate(Vector3.forward * rotationSpeed);
            }

            if (Input.GetKey(KeyCode.I) || Input.GetKey("joystick 3 button 0"))
            {
                rb.AddForce(gameObject.transform.up * speed);
            }

            if (Input.GetKey(KeyCode.K) || Input.GetKey("joystick 3 button 1"))
            {
                rb.AddForce(gameObject.transform.up * -speed);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (gameObject.tag == "Player1")
        {
            if (coll.gameObject.tag == "player2" && BombManager.playerWithBomb == 2)
            {
                StartCoroutine("bufferClock");
                BombManager.playerWithBomb = 1;

            }

            if (coll.gameObject.tag == "player3" && BombManager.playerWithBomb == 3)
            {
                StartCoroutine("bufferClock");
                BombManager.playerWithBomb = 1;

            }
        }

        if (gameObject.tag == "Player2")
        {
            if (coll.gameObject.tag == "player1" && BombManager.playerWithBomb == 1)
            {
                StartCoroutine("bufferClock");
                BombManager.playerWithBomb = 2;

            }

            if (coll.gameObject.tag == "player3" && BombManager.playerWithBomb == 3)
            {
                StartCoroutine("bufferClock");
                BombManager.playerWithBomb = 2;

            }
        }

        if (gameObject.tag == "Player3")
        {
            if (coll.gameObject.tag == "player1" && BombManager.playerWithBomb == 1)
            {
                StartCoroutine("bufferClock");
                BombManager.playerWithBomb = 3;

            }

            if (coll.gameObject.tag == "player2" && BombManager.playerWithBomb == 2)
            {
                StartCoroutine("bufferClock");
                BombManager.playerWithBomb = 3;

            }
        }

    }

    IEnumerator bufferClock()
    {
        while (true)
        {
            bufferBool = false;
            yield return new WaitForSeconds(1);
            bufferBool = true;
            
        }
    }


}
