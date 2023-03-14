using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamster : MonoBehaviour {

    SpriteRenderer sprite;

    public GameObject gold;

    float nextSpawn, spawnRate;

    // Use this for initialization
    void Start () {
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
        nextSpawn = Time.time + Random.Range(5f, 10f);
    }

    private void FixedUpdate()
    {
        if(Time.time > nextSpawn)
        {
            Instantiate(gold, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));

            spawnRate = Random.Range(20f, 28f);
            nextSpawn = Time.time + spawnRate;
        }
    }

}
