using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 0.2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.health--;
            Destroy(gameObject);
        }
    }
}
