using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    float nextHit = 0f, hitRate = 0.5f;

    Animator myAnim;

    SpriteRenderer sprite;

    private void Start()
    {
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            myAnim.SetBool("hit", true);
            if (Time.time > nextHit)
            {
                MonsterHealth monsterHealth = collision.gameObject.GetComponent<MonsterHealth>();
                monsterHealth.health--;
                nextHit = Time.time + hitRate + 0.15f;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            myAnim.SetBool("hit", false);
        }
    }
}
