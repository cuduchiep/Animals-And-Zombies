using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Otter : MonoBehaviour {
    
    public GameObject shrew_exp;

    SpriteRenderer sprite;

    // Use this for initialization
    void Start () {

        sprite = GetComponentInParent<SpriteRenderer>();
        if (transform.position.y >= 2.0f)
        {
            sprite.sortingOrder = 20;
        }
        else if (transform.position.y >= 0.65f)
        {
            sprite.sortingOrder = 22;
        }
        else if (transform.position.y >= -0.7f)
        {
            sprite.sortingOrder = 24;
        }
        else if (transform.position.y >= -2.05f)
        {
            sprite.sortingOrder = 26;
        }
        else if (transform.position.y >= -3.4f)
        {
            sprite.sortingOrder = 28;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            MonsterHealth monsterHealth = collision.gameObject.GetComponent<MonsterHealth>();
            monsterHealth.health = 0;
            Instantiate(shrew_exp, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            MonsterHealth monsterHealth = collision.gameObject.GetComponent<MonsterHealth>();
            monsterHealth.health = 0;
            Instantiate(shrew_exp, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
    }
}
