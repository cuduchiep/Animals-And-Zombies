using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBall : MonoBehaviour {

    public float speed;
    Rigidbody2D myBody;

	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 0.2f);
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
            monsterHealth.health = -10;
            Destroy(gameObject);
        }
    }
}
