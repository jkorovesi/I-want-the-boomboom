using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float rotationSpeed;

    bool bufferBool = true;


    //SpawnPlayerScript spawnPlayerScript;

    void Start()
    {

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
        //spawnPlayerScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnPlayerScript>();
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

            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("joystick 1 button 1"))
            {
                rb.AddForce(gameObject.transform.up * -speed);
                //PlayOneShot(engIdle);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(BombManager.playerWithBomb != 1)
        {
            if (coll.gameObject.tag == "Player2" && BombManager.playerWithBomb == 2 && bufferBool == true)
            {
                BombManager.playerWithBomb = 1;
                StartCoroutine("bufferClock");
                

            }

            if (coll.gameObject.tag == "Player3" && BombManager.playerWithBomb == 3 && bufferBool == true)
            {
                BombManager.playerWithBomb = 1;
                StartCoroutine("bufferClock");
                

            }
        }

        if (BombManager.playerWithBomb == 1)
        {
            if (coll.gameObject.tag == "Player2" || coll.gameObject.tag == "Player3")
                {
                    StartCoroutine("bufferClock");
                }
        }



    }

    IEnumerator bufferClock()
    {

            bufferBool = false;
            yield return new WaitForSeconds(2);
            bufferBool = true;

    }


}
