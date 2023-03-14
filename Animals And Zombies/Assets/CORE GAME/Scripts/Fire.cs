using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public GameObject fire_ball;

    SpriteRenderer sprite;

    private void Start()
    {

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
        if(collision.gameObject.tag == "Ball" && collision.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            Instantiate(fire_ball, collision.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(collision.gameObject);
        }
    }
}
