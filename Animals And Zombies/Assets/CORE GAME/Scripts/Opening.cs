using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Opening : MonoBehaviour {

    Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.enabled = true;
        Destroy(gameObject, 3f);

        List<Database> list = SQLiteCore.GetDatabases();
        foreach (var c in list)
        {
            text.text = "Màn " + c.CURRENTLEVEL;
        }
    }
}
