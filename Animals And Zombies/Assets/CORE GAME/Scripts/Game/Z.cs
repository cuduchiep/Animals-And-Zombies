using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z : MonoBehaviour {

    Rigidbody2D myBody;
    Animator myAnim;

    float nextSleep;

	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        nextSleep = Time.time + 1.5f;
        Destroy(gameObject, 3);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        myBody.velocity = new Vector2(0.2f, 0.2f);
		if(Time.time > nextSleep)
        {
            myAnim.SetBool("sleep", true);
        }
	}
}
