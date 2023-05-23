using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HypBall : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 0.2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            MonsterHealth health = collision.gameObject.GetComponent<MonsterHealth>();
            health.health--;
            Destroy(gameObject);
        }
    }
}
