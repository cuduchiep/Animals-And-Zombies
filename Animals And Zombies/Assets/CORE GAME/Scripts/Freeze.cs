using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{

    public GameObject freeze_ball;
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

            GameObject ball1 = Instantiate(freeze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            FreezeBall freezeBall1 = ball1.GetComponent<FreezeBall>();
            freezeBall1.speedX = 12f;
            freezeBall1.speedY = 0f;

            GameObject ball2 = Instantiate(freeze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            FreezeBall freezeBall2 = ball2.GetComponent<FreezeBall>();
            freezeBall2.speedX = -12f;
            freezeBall2.speedY = 0f;

            GameObject ball3 = Instantiate(freeze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            FreezeBall freezeBall3 = ball3.GetComponent<FreezeBall>();
            freezeBall3.speedX = 8.5f;
            freezeBall3.speedY = 8.5f;

            GameObject ball4 = Instantiate(freeze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            FreezeBall freezeBall4 = ball4.GetComponent<FreezeBall>();
            freezeBall4.speedX = -8.5f;
            freezeBall4.speedY = 8.5f;

            GameObject ball5 = Instantiate(freeze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            FreezeBall freezeBall5 = ball5.GetComponent<FreezeBall>();
            freezeBall5.speedX = 8.5f;
            freezeBall5.speedY = -8.5f;

            GameObject ball6 = Instantiate(freeze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            FreezeBall freezeBall6 = ball6.GetComponent<FreezeBall>();
            freezeBall6.speedX = -8.5f;
            freezeBall6.speedY = -8.5f;

            GameObject ball7 = Instantiate(freeze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            FreezeBall freezeBall7 = ball7.GetComponent<FreezeBall>();
            freezeBall7.speedX = 0f;
            freezeBall7.speedY = 12f;

            GameObject ball8 = Instantiate(freeze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            FreezeBall freezeBall8 = ball8.GetComponent<FreezeBall>();
            freezeBall8.speedX = 0f;
            freezeBall8.speedY = -12f;

            GameObject ball9 = Instantiate(freeze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            FreezeBall freezeBall9 = ball9.GetComponent<FreezeBall>();
            freezeBall9.speedX = 5f;
            freezeBall9.speedY = -11f;

            GameObject ball10 = Instantiate(freeze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            FreezeBall freezeBall10 = ball10.GetComponent<FreezeBall>();
            freezeBall10.speedX = 11f;
            freezeBall10.speedY = -5f;

            GameObject ball11 = Instantiate(freeze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            FreezeBall freezeBall11 = ball11.GetComponent<FreezeBall>();
            freezeBall11.speedX = -11f;
            freezeBall11.speedY = -5f;

            GameObject ball12 = Instantiate(freeze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            FreezeBall freezeBall12 = ball12.GetComponent<FreezeBall>();
            freezeBall12.speedX = 11f;
            freezeBall12.speedY = 5f;

            GameObject ball13 = Instantiate(freeze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            FreezeBall freezeBall13 = ball13.GetComponent<FreezeBall>();
            freezeBall13.speedX = -11f;
            freezeBall13.speedY = 5f;

            GameObject ball14 = Instantiate(freeze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            FreezeBall freezeBall14 = ball14.GetComponent<FreezeBall>();
            freezeBall14.speedX = 5f;
            freezeBall14.speedY = 11f;

            GameObject ball15 = Instantiate(freeze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            FreezeBall freezeBall15 = ball15.GetComponent<FreezeBall>();
            freezeBall15.speedX = -5f;
            freezeBall15.speedY = -11f;

            GameObject ball16 = Instantiate(freeze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            FreezeBall freezeBall16 = ball16.GetComponent<FreezeBall>();
            freezeBall16.speedX = -5f;
            freezeBall16.speedY = 11f;


            Destroy(gameObject, 0.25f);
            hit = true;
        }
    }
}