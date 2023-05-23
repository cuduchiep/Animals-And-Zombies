using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : MonoBehaviour {

    public GameObject hyp_monster, hyp_monster2, hyp_monster3, hyp_horse, hyp_fast, hyp_witch, hyp_monster4;
    public GameObject owl_dead;
    SpriteRenderer sprite;

    // Use this for initialization
    void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
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
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        Owl owl = GetComponent<Owl>();
        if(collision.gameObject.tag == "Enemy" && owl.enabled)
        {
            //Hyp
            GameObject mob = null;
            HypMonster hypMonster;
            HypHorse hypHorse;
            HypWitch hypWitch;
            Health health;

            //Monster
            Monster monster;
            Horse horse;
            Witch witch;
            MonsterHealth monsterHealth = collision.gameObject.GetComponent<MonsterHealth>();    

            Transform trans = collision.gameObject.transform;
            if (collision.gameObject.layer == LayerMask.NameToLayer("Monster"))
            {
                mob = Instantiate(hyp_monster, trans.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;

                monster = collision.gameObject.GetComponent<Monster>();

                hypMonster = mob.GetComponent<HypMonster>();
                health = mob.GetComponent<Health>();
                
                hypMonster.speed = monster.speed;
                hypMonster.move = monster.move;
                hypMonster.fast = monster.fast;
                health.slower = monsterHealth.slower;
                health.health = monsterHealth.health;
            }
            if (collision.gameObject.layer == LayerMask.NameToLayer("Monster2"))
            {
                mob = Instantiate(hyp_monster2, trans.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;

                monster = collision.gameObject.GetComponent<Monster>();

                hypMonster = mob.GetComponent<HypMonster>();
                health = mob.GetComponent<Health>();
                
                hypMonster.speed = monster.speed;
                hypMonster.move = monster.move;
                hypMonster.fast = monster.fast;
                health.slower = monsterHealth.slower;
                health.health = monsterHealth.health;
            }
            if (collision.gameObject.layer == LayerMask.NameToLayer("Monster3"))
            {
                mob = Instantiate(hyp_monster3, trans.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;

                monster = collision.gameObject.GetComponent<Monster>();

                hypMonster = mob.GetComponent<HypMonster>();
                health = mob.GetComponent<Health>();
                
                hypMonster.speed = monster.speed;
                hypMonster.move = monster.move;
                hypMonster.fast = monster.fast;
                health.slower = monsterHealth.slower;
                health.health = monsterHealth.health;
            }
            if (collision.gameObject.layer == LayerMask.NameToLayer("Monster4"))
            {
                mob = Instantiate(hyp_monster4, trans.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;

                monster = collision.gameObject.GetComponent<Monster>();

                hypMonster = mob.GetComponent<HypMonster>();
                health = mob.GetComponent<Health>();
                
                hypMonster.speed = monster.speed;
                hypMonster.move = monster.move;
                hypMonster.fast = monster.fast;
                health.slower = monsterHealth.slower;
                health.health = monsterHealth.health;
            }
            if (collision.gameObject.layer == LayerMask.NameToLayer("Fast"))
            {
                mob = Instantiate(hyp_fast, trans.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;

                monster = collision.gameObject.GetComponent<Monster>();

                hypMonster = mob.GetComponent<HypMonster>();
                health = mob.GetComponent<Health>();
                
                hypMonster.speed = monster.speed;
                hypMonster.move = monster.move;
                hypMonster.fast = monster.fast;
                health.slower = monsterHealth.slower;
                health.health = monsterHealth.health;
            }
            if (collision.gameObject.layer == LayerMask.NameToLayer("Horse"))
            {
                mob = Instantiate(hyp_horse, trans.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;

                horse = collision.gameObject.GetComponent<Horse>();

                hypHorse = mob.GetComponent<HypHorse>();
                health = mob.GetComponent<Health>();

                hypHorse.speed = horse.speed;
                hypHorse.move = horse.move;
                hypHorse.isJump = horse.isJump;
                health.slower = monsterHealth.slower;
                health.health = monsterHealth.health;
            }
            if (collision.gameObject.layer == LayerMask.NameToLayer("Witch"))
            {
                mob = Instantiate(hyp_witch, trans.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;

                witch = collision.gameObject.GetComponent<Witch>();

                hypWitch = mob.GetComponent<HypWitch>();
                health = mob.GetComponent<Health>();

                hypWitch.speed = witch.speed;
                hypWitch.move = witch.move;
                hypWitch.fast = witch.fast;
                health.slower = monsterHealth.slower;
                health.health = monsterHealth.health;
            }

            monsterHealth.health = -10;
            Instantiate(owl_dead, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
    }
}
