using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour {

    public GameObject z;
    public bool isSleep = true;
    float nextZ = 0, zRate = 1f;
    
    int level, card, currentLevel;

    SpriteRenderer sprite;

    // Khởi tạo
    void Start()
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

        List<Database> list = SQLiteCore.GetDatabases();
        foreach (var c in list)
        {
            level = c.LEVEL;
            card = c.CARD;
            currentLevel = c.CURRENTLEVEL;
        }
        if (currentLevel >= 1 && currentLevel <= 8)
        {
            isSleep = true;
        }
        else
        if (currentLevel >= 9 && currentLevel <= 15)
        {
            isSleep = false;
        }
        else if(currentLevel >= 16)
        {
            isSleep = true;
        }
    }
	void FixedUpdate ()
    {
        Animator animator = GetComponent<Animator>();
        if (isSleep)
        {
            if(Time.time > nextZ)
            {
                Instantiate(z, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                nextZ = Time.time + zRate;
            }
            animator.enabled = false;
        } else
        {
            if(gameObject.layer == LayerMask.NameToLayer("Frog") || gameObject.layer == LayerMask.NameToLayer("Mushroom"))
            {
                MonkeyHit monkeyHit = GetComponent<MonkeyHit>();
                monkeyHit.enabled = true;
            }
            if(gameObject.layer == LayerMask.NameToLayer("Mouse"))
            {
                Mouse mouse = GetComponent<Mouse>();
                mouse.enabled = true;
            }
            if(gameObject.layer == LayerMask.NameToLayer("Bunny"))
            {
                BunnyHit bunnyHit = GetComponent<BunnyHit>();
                bunnyHit.enabled = true;
            }
            if(gameObject.layer == LayerMask.NameToLayer("Owl"))
            {
                Owl owl = GetComponent<Owl>();
                owl.enabled = true;
            }
            if(gameObject.layer == LayerMask.NameToLayer("Blaze"))
            {
                Blaze blaze = GetComponent<Blaze>();
                blaze.enabled = true;
            }
            if(gameObject.layer == LayerMask.NameToLayer("Freeze"))
            {
                Freeze freeze = GetComponent<Freeze>();
                freeze.enabled = true;
            }
            Sleep sleep = GetComponent<Sleep>();
            sleep.enabled = false;
            animator.enabled = true;
        }
	}
}
