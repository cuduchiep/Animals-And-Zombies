using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(transform.childCount == 0)
        {
            gameObject.tag = "Water";
        } else
        {
            gameObject.tag = "Tile";
        }
	}
}
