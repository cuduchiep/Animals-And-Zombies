using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuReplay : MonoBehaviour {

    float replay;
	void Start () 
    {
        replay = Time.time + 18f;
	}
	void FixedUpdate () {
		if(Time.time > replay)
        {
            SceneManager.LoadScene("Menu");
        }
	}
}
