﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 0.2f);
	}
}
