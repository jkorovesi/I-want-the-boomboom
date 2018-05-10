using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushMove : MonoBehaviour {

    public Rigidbody2D rb;

	
	// Update is called once per frame
	void FixedUpdate () {
        rb.AddForce(gameObject.transform.up * 40);
    }
}
