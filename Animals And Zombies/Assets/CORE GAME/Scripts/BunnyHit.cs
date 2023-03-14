using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyHit : MonoBehaviour
{

    public GameObject ball;
    public Transform ballShot;
    float nextHit, hitRate;
    Animator myAnim;
    bool hit = false, onHit = false, hide = false;
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
        if(hide)
        {
            myAnim.SetBool("hide", true);
        } else
        {
            myAnim.SetBool("hide", false);
            if (hit)
            {
                if (Time.time < nextHit + hitRate)
                {
                    myAnim.SetBool("hit", false);
                }
                if (Time.time > nextHit)
                {
                    myAnim.SetBool("hit", true);
                    hitRate = Random.Range(1f, 1.3f);
                }
                if (Time.time > nextHit + 0.5f)
                {
                    Instantiate(ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    nextHit = Time.time + hitRate;
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        BunnyHit bunnyHit = GetComponent<BunnyHit>();
        if (collision.gameObject.tag == "Enemy" && bunnyHit.enabled)
        {
            hit = true;
            if (!onHit)
            {
                nextHit = Time.time + Random.Range(1.5f, 2f);
                onHit = true;
            }
            Transform trans = GetComponentInParent<Transform>();
            Debug.Log(trans.position.x);
            if(trans.position.x + 3.5f >= collision.transform.position.x)
            {
                hide = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        BunnyHit bunnyHit = GetComponent<BunnyHit>();
        if (collision.gameObject.tag == "Enemy" && bunnyHit.enabled)
        {
            hit = false;
            onHit = false;
            hide = false;
            myAnim.SetBool("hit", false);
        }
    }
}
