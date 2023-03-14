using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHit : MonoBehaviour
{

    public GameObject ball;
    public Transform ballShot;

    float nextHit, hitRate;

    Animator myAnim;

    public bool hit = false;

    SpriteRenderer sprite;

    // Use this for initialization
    void Start()
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
        nextHit = Time.time + Random.Range(1.5f, 2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hit)
        {
            if (Time.time > nextHit - 1.5f)
            {
                myAnim.SetBool("hit", false);
                hit = false;
            }
            if (Time.time > nextHit)
            {
                myAnim.SetBool("hit", true);
                hitRate = Random.Range(30f, 35f);
            }
            if (Time.time > nextHit + 0.2f)
            {
                Instantiate(ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                nextHit = Time.time + hitRate;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hit = true;
        }
    }
}
