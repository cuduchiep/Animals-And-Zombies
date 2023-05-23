using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPointer : MonoBehaviour {

    GoldChecker goldChecker;

	// Use this for initialization
	void Start () {
        goldChecker = GetComponent<GoldChecker>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                GameObject gold = hit.collider.gameObject;
                if (gold.gameObject.tag == "Gold")
                {
                    goldChecker.gold += 25;
                    Destroy(gold.gameObject);
                }
                if (gold.gameObject.tag == "MiniGold")
                {
                    goldChecker.gold += 15;
                    Destroy(gold.gameObject);
                }
            }
        }
    }
}
