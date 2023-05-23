using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBall : MonoBehaviour {

    public float speed;
    Rigidbody2D myBody;

    public GameObject ballHit;

    // Use this for initialization
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            MonsterHealth monsterHealth = collision.gameObject.GetComponent<MonsterHealth>();
            monsterHealth.health--;

            if (collision.gameObject.layer == LayerMask.NameToLayer("Horse"))
            {
                Horse horse = collision.gameObject.GetComponent<Horse>();
                horse.move = 0.6f;
                horse.fast = 1.5f;

            }
            else if (collision.gameObject.layer == LayerMask.NameToLayer("Witch"))
            {
                Witch witch = collision.gameObject.GetComponent<Witch>();
                witch.move = 0.6f;
                witch.fast = 1.5f;
            }
            else
            {
                Monster monster = collision.gameObject.GetComponent<Monster>();
                monster.move = 0.6f;
                monster.fast = 1.5f;
            }
            monsterHealth.slower = true;
            Instantiate(ballHit, collision.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
    }
}
