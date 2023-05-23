using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHit : MonoBehaviour
{

    public GameObject ball;//, dead;
    public Transform ballShot;

    float nextHit;

    Animator myAnim;

    public bool hit;


    // Use this for initialization
    void Start()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hit)
        {
            if (Time.time > nextHit)
            {
                myAnim.SetBool("hit", true);
            }
            if (Time.time > nextHit + 0.4f)
            {
                Instantiate(ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                hit = false;
                Destroy(gameObject, 1.5f);
            }
        } else
        {
            //Instantiate(dead, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hit = true;
            nextHit = Time.time;
            MonsterHealth monsterHealth = collision.gameObject.GetComponent<MonsterHealth>();
            monsterHealth.health = 0;
        }
    }
}

