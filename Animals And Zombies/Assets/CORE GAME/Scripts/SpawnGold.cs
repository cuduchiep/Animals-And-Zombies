using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGold : MonoBehaviour {

    float locationX;

    float nextSpawn, spawnRate;

    public GameObject gold;

	// Use this for initialization
	void Start () {
        nextSpawn = Time.time + 3f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Time.time > nextSpawn)
        {
            locationX = Random.Range(-8f, 8f);
            Instantiate(gold, new Vector2(locationX, 6f), Quaternion.Euler(new Vector3(0, 0, 0)));
            spawnRate = Random.Range(15f, 20f);
            nextSpawn = Time.time + spawnRate;
        }
	}
}
