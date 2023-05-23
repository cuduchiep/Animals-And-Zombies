using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearHit : MonoBehaviour {

    public GameObject ball;
    public Transform ballShot;
    public GameObject bear_dead;

    public bool isHit = false, hit = true, canHit = true;
    float nextHit;

    Animator myAnim;

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
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if(isHit)
        {
            myAnim.SetBool("hit", true);
            if (canHit)
            {
                nextHit = Time.time + 0.2f;
                canHit = false;
            }
            if (Time.time > nextHit)
            {
                if (hit)
                {
                    GameObject left = Instantiate(ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                    GameObject right = Instantiate(ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                    WizardBall ballLeft = left.GetComponent<WizardBall>();
                    WizardBall ballRight = right.GetComponent<WizardBall>();
                    ballLeft.speedX = -12f;
                    ballRight.speedX = 12f;
                    hit = false;
                }
            }
            if(Time.time > nextHit + 0.5f)
            {
                Instantiate(bear_dead, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                Destroy(gameObject);
            }
        }
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            isHit = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            isHit = true;
        }
    }
}
