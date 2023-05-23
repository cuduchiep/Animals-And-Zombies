using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBall : MonoBehaviour {

    public float speedX, speedY;
    Rigidbody2D myBody;

    // Use this for initialization
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speedX, speedY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            MonsterHealth monsterHealth = collision.gameObject.GetComponent<MonsterHealth>();

            if (collision.gameObject.layer == LayerMask.NameToLayer("Horse"))
            {
                Horse horse = collision.gameObject.GetComponent<Horse>();
                horse.move = 0.3f;
                horse.fast = 2f;

            } else if(collision.gameObject.layer == LayerMask.NameToLayer("Witch"))
            {
                Witch witch = collision.gameObject.GetComponent<Witch>();
                witch.move = 0.3f;
                witch.fast = 2f;
            } else
            { 
                Monster monster = collision.gameObject.GetComponent<Monster>();
                monster.move = 0.3f;
                monster.fast = 2f;
            }
            monsterHealth.slower = true;
        }
    }
}
