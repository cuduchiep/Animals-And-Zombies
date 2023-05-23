using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBall : MonoBehaviour {

    public float speedX, speedY, time;
    Rigidbody2D myBody;

	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, time);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        myBody.velocity = new Vector2(speedX, speedY);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            MonsterHealth monsterHealth = collision.gameObject.GetComponent<MonsterHealth>();
            monsterHealth.health = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            MonsterHealth monsterHealth = collision.gameObject.GetComponent<MonsterHealth>();
            monsterHealth.health = 0;
        }
    }
}
