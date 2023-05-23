using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour {

    public int health;

    public GameObject monster_dead;
    public GameObject monster;

    SpriteRenderer spriteRenderer;

    public bool slower = false;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (health == -10)
        {
            Destroy(gameObject);
        }
        if (health <= 0 && health > -10)
        {
            Instantiate(monster_dead, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
        if(health <= 10)
        {
            if(gameObject.layer == LayerMask.NameToLayer("Monster2") || gameObject.layer == LayerMask.NameToLayer("Monster3") || gameObject.layer == LayerMask.NameToLayer("Tank"))
            {
                GameObject mob = Instantiate(monster, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                MonsterHealth heal = mob.GetComponent<MonsterHealth>();
                heal.health = health;
                Destroy(gameObject);
            }
            if(gameObject.layer == LayerMask.NameToLayer("Aqua2") || gameObject.layer == LayerMask.NameToLayer("Aqua3"))
            {
                GameObject mob = Instantiate(monster, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                MonsterHealth heal = mob.GetComponent<MonsterHealth>();
                heal.health = health;
                Destroy(gameObject);
            }
        }
        if(health <= 15)
        {
            if (gameObject.layer == LayerMask.NameToLayer("Fast"))
            {
                GameObject mob = Instantiate(monster, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                Monster fast = mob.GetComponent<Monster>();
                MonsterHealth heal = mob.GetComponent<MonsterHealth>();
                heal.health = health;
                fast.speed *= 2.5f;
                fast.fast = 0.5f;
                Destroy(gameObject);
            }
        }
        if(slower)
        {
            spriteRenderer.color = new Color(0.504717f, 0.6808742f, 1, 1);
        } else
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }
}
