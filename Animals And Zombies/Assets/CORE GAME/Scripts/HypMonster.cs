using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HypMonster : MonoBehaviour
{

    public float speed, move = 1;

    Rigidbody2D myBody;
    Animator myAnim;

    public GameObject ball;
    public Transform ballShot;

    SpriteRenderer sprite;

    bool stand = false, hit = false;

    float nextWalk, walkRate = 1.5f;
    float nextHit = 0, hitRate = 0.5f;
    public float fast = 1;

    // Use this for initialization
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        if (transform.position.y >= 2.5f)
        {
            sprite.sortingOrder = 21;
        }
        else if (transform.position.y >= 1.15f)
        {
            sprite.sortingOrder = 23;
        }
        else if (transform.position.y >= -0.2f)
        {
            sprite.sortingOrder = 25;
        }
        else if (transform.position.y >= -1.55f)
        {
            sprite.sortingOrder = 27;
        }
        else if (transform.position.y >= -2.9f)
        {
            sprite.sortingOrder = 29;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stand)
        {

            myBody.velocity = new Vector2(0, myBody.velocity.y);
            if (hit)
            {
                if (Time.time < nextHit + hitRate)
                {
                    myAnim.SetBool("hit", false);
                }
                if (Time.time > nextHit)
                {
                    myAnim.SetBool("hit", true);
                }
                if (Time.time > nextHit + 0.5f)
                {
                    Instantiate(ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    nextHit = Time.time + (hitRate * fast);
                }
            }
            if (Time.time > nextWalk)
            {
                nextWalk = Time.time + walkRate;
                stand = false;
                hit = false;
                myAnim.SetBool("hit", false);
            }

            myAnim.SetBool("walk", false);
        }
        else
        {
            myBody.velocity = new Vector2(speed * move, myBody.velocity.y);
            myAnim.SetBool("walk", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.isTrigger == true)
            {
                stand = true;
                hit = true;
                nextWalk = Time.time + walkRate;
                nextHit = Time.time + hitRate;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.isTrigger == true)
            {
                stand = true;
                hit = true;
                nextWalk = Time.time + walkRate;
            }
        }
    }
}