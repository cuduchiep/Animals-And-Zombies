using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrew : MonoBehaviour {

    Animator myAnim;

    public GameObject shrew_exp;

    float nextUp;

    bool hit = false;

    SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
        myAnim = GetComponent<Animator>();

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
        nextUp = Time.time + Random.Range(5f, 8f);
        Debug.Log("OK");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Time.time > nextUp)
        {
            myAnim.SetBool("up", true);
        }
        if(Time.time > nextUp + 1f)
        {
            hit = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && hit)
        {
            MonsterHealth monsterHealth = collision.gameObject.GetComponent<MonsterHealth>();
            monsterHealth.health = 0;
            Instantiate(shrew_exp, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && hit)
        {
            MonsterHealth monsterHealth = collision.gameObject.GetComponent<MonsterHealth>();
            monsterHealth.health = 0;
            Instantiate(shrew_exp, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
    }
}
