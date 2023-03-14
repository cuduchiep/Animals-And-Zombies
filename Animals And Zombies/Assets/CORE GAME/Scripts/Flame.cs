using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{

    public GameObject flame_ball;
    public Transform ballShot;

    float nextDamage;
    bool hit = false;
   
    SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
        nextDamage = Time.time + 0.75f;

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
    void FixedUpdate()
    {
        if(Time.time > nextDamage && !hit)
        {

            GameObject ballLeft = Instantiate(flame_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            RockBall rockBallLeft = ballLeft.GetComponent<RockBall>();
            rockBallLeft.speed = -15f;
            rockBallLeft.transform.localScale = new Vector2(2.5f, 2.5f);

            GameObject ballRight = Instantiate(flame_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            RockBall rockBallRight = ballRight.GetComponent<RockBall>();
            rockBallRight.speed = 15f;

            Destroy(gameObject, 0.25f);
            hit = true;
        }
    }
}