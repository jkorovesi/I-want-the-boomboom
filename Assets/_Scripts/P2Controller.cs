﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Controller : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float rotationSpeed;


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


    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player1" && BombManager.playerWithBomb == 1 && ImmuneChecker.p1Immune == false)
        {
            BombManager.playerWithBomb = 2;
            Debug.Log(BombManager.playerWithBomb);
            StartCoroutine("immuneClock");

        }

        if (coll.gameObject.tag == "Player3" && BombManager.playerWithBomb == 3 && ImmuneChecker.p3Immune == false)
        {
            BombManager.playerWithBomb = 1;
            Debug.Log(BombManager.playerWithBomb);
            StartCoroutine("immuneClock");

        }

    }

    IEnumerator immuneClock()
    {

        ImmuneChecker.p2Immune = true;
        yield return new WaitForSeconds(2);
        ImmuneChecker.p2Immune = false;


    }


}
