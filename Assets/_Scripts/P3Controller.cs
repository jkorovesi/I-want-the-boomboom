using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3Controller : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float rotationSpeed;

    bool bufferBool = true;


    void Start()
    {

    }

    private void Update()
    {

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


        if (BombManager.playerWithBomb != 3)
        {
            if (coll.gameObject.tag == "Player1" && BombManager.playerWithBomb == 1 && bufferBool == true)
            {
                BombManager.playerWithBomb = 3;
                StartCoroutine("bufferClock");
                

            }

            if (coll.gameObject.tag == "Player2" && BombManager.playerWithBomb == 2 && bufferBool == true)
            {
                BombManager.playerWithBomb = 3;
                StartCoroutine("bufferClock");
                

            }
        }

        if (BombManager.playerWithBomb == 3)
        {
            if (coll.gameObject.tag == "Player1" || coll.gameObject.tag == "Player2")
            {
                StartCoroutine("bufferClock");
            }
        }



    }

    IEnumerator bufferClock()
    {

            bufferBool = false;
            yield return new WaitForSeconds(1);
            bufferBool = true;

    }


}

