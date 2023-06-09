﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyBall : MonoBehaviour {

    public float speed;
    Rigidbody2D myBody;

    public GameObject ballHit;

	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            MonsterHealth monsterHealth = collision.gameObject.GetComponent<MonsterHealth>();
            monsterHealth.health--;
            Instantiate(ballHit, collision.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
    }
}
