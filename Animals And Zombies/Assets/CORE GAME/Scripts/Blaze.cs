using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaze : MonoBehaviour
{

    public GameObject blaze_exp, blaze_ball;
    public Transform ballShot;

    float nextDamage;
    bool hit = false;

    Animator myAnim;
   
    SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
        nextDamage = Time.time + 0.75f;

        myAnim = GetComponentInParent<Animator>();
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
        Destroy(gameObject, Random.Range(40f, 50f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.time > nextDamage && !hit)
        {
            Instantiate(blaze_exp, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0)));

            GameObject ball1 = Instantiate(blaze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            WizardBall freezeBall1 = ball1.GetComponent<WizardBall>();
            freezeBall1.speedX = 12f;
            freezeBall1.speedY = 0f;

            GameObject ball2 = Instantiate(blaze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            WizardBall freezeBall2 = ball2.GetComponent<WizardBall>();
            freezeBall2.speedX = -12f;
            freezeBall2.speedY = 0f;

            GameObject ball3 = Instantiate(blaze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            WizardBall freezeBall3 = ball3.GetComponent<WizardBall>();
            freezeBall3.speedX = 8.5f;
            freezeBall3.speedY = 8.5f;

            GameObject ball4 = Instantiate(blaze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            WizardBall freezeBall4 = ball4.GetComponent<WizardBall>();
            freezeBall4.speedX = -8.5f;
            freezeBall4.speedY = 8.5f;

            GameObject ball5 = Instantiate(blaze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            WizardBall freezeBall5 = ball5.GetComponent<WizardBall>();
            freezeBall5.speedX = 8.5f;
            freezeBall5.speedY = -8.5f;

            GameObject ball6 = Instantiate(blaze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            WizardBall freezeBall6 = ball6.GetComponent<WizardBall>();
            freezeBall6.speedX = -8.5f;
            freezeBall6.speedY = -8.5f;

            GameObject ball7 = Instantiate(blaze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            WizardBall freezeBall7 = ball7.GetComponent<WizardBall>();
            freezeBall7.speedX = 0f;
            freezeBall7.speedY = 12f;

            GameObject ball8 = Instantiate(blaze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            WizardBall freezeBall8 = ball8.GetComponent<WizardBall>();
            freezeBall8.speedX = 0f;
            freezeBall8.speedY = -12f;

            GameObject ball9 = Instantiate(blaze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            WizardBall freezeBall9 = ball9.GetComponent<WizardBall>();
            freezeBall9.speedX = 5f;
            freezeBall9.speedY = -11f;

            GameObject ball10 = Instantiate(blaze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            WizardBall freezeBall10 = ball10.GetComponent<WizardBall>();
            freezeBall10.speedX = 11f;
            freezeBall10.speedY = -5f;

            GameObject ball11 = Instantiate(blaze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            WizardBall freezeBall11 = ball11.GetComponent<WizardBall>();
            freezeBall11.speedX = -11f;
            freezeBall11.speedY = -5f;

            GameObject ball12 = Instantiate(blaze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            WizardBall freezeBall12 = ball12.GetComponent<WizardBall>();
            freezeBall12.speedX = 11f;
            freezeBall12.speedY = 5f;

            GameObject ball13 = Instantiate(blaze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            WizardBall freezeBall13 = ball13.GetComponent<WizardBall>();
            freezeBall13.speedX = -11f;
            freezeBall13.speedY = 5f;

            GameObject ball14 = Instantiate(blaze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            WizardBall freezeBall14 = ball14.GetComponent<WizardBall>();
            freezeBall14.speedX = 5f;
            freezeBall14.speedY = 11f;

            GameObject ball15 = Instantiate(blaze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            WizardBall freezeBall15 = ball15.GetComponent<WizardBall>();
            freezeBall15.speedX = -5f;
            freezeBall15.speedY = -11f;

            GameObject ball16 = Instantiate(blaze_ball, ballShot.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            WizardBall freezeBall16 = ball16.GetComponent<WizardBall>();
            freezeBall16.speedX = -5f;
            freezeBall16.speedY = 11f;

            hit = true;
        }
        if (Time.time > nextDamage && hit)
        {
            gameObject.tag = "Blaze";
            myAnim.SetBool("dead", true);
        }
    }
}