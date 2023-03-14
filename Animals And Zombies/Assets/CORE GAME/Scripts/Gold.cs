using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{

    public float speed;

    Rigidbody2D myBody;
    Animator myAnim;

    float stop;
    float dead;

    public int gold;
    public GoldChecker goldChecker;

    // Use this for initialization
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        stop = Time.time + Random.Range(3f, 4f);
        dead = stop - 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        goldChecker = GameObject.Find("EventSystem").GetComponent<GoldChecker>();
        myBody.velocity = new Vector2(myBody.velocity.x, -speed);

        if (Time.time > dead)
        {
            myAnim.SetBool("dead", true);
        }
        if (Time.time > stop)
        {
            goldChecker.gold += gold;
            Destroy(gameObject);
        }
    }
}
