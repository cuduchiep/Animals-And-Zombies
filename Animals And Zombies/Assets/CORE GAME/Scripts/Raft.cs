using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raft : MonoBehaviour {

    SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
        sprite = GetComponentInParent<SpriteRenderer>();
        if (transform.position.y >= -2.05f)
        {
            sprite.sortingOrder = 25;
        }
        else if (transform.position.y >= -3.4f)
        {
            sprite.sortingOrder = 27;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if(transform.childCount == 0)
        {
            gameObject.tag = "Player";
        } else
        {
            gameObject.tag = "Tile";
        }
	}
}
