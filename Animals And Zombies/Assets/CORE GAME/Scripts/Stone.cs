using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

    Animator myAnim;
    Health health;

    SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
        health = GetComponent<Health>();
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
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if(health.health <= 10)
        {
            myAnim.SetBool("hit", true);
        }
	}
}
