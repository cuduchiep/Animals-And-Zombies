using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health;

    public GameObject monkey_dead, monster;

    SpriteRenderer spriteRenderer;

    public bool slower = false;

    // Use this for initialization
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health == -10)
        {
            Destroy(gameObject);
        }
        if (health <= 0 && health > -10)
        {
            Instantiate(monkey_dead, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
        if (health <= 10)
        {
            if (gameObject.layer == LayerMask.NameToLayer("Monster2") || gameObject.layer == LayerMask.NameToLayer("Monster3"))
            {
                GameObject mob = Instantiate(monster, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                HypMonster fast = mob.GetComponent<HypMonster>();
                Health heal = mob.GetComponent<Health>();
                heal.health = health;
                Destroy(gameObject);
            }
        }
        if (health <= 15)
        {
            if (gameObject.layer == LayerMask.NameToLayer("Fast"))
            {
                GameObject mob = Instantiate(monster, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                HypMonster fast = mob.GetComponent<HypMonster>();
                Health heal = mob.GetComponent<Health>();
                heal.health = health;
                fast.speed *= 2.5f;
                fast.fast = 0.5f;
                Destroy(gameObject);
            }
        }
        if (slower)
        {
            spriteRenderer.color = new Color(0.504717f, 0.6808742f, 1, 1);
        }
        else
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }

}
