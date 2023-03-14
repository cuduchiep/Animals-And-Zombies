using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cheating : MonoBehaviour, IPointerClickHandler {

    int count = 0;
    public GoldChecker goldChecker;
    public Trumpet trumpet;

	
	void Start () {
		
	}
	
	
	void FixedUpdate () {
		if(count == 20)
        {
            Debug.Log("Cheating!");
            goldChecker.gold += 500;
            count = 0;
        }
        if(!trumpet.click && count > 0)
        {
            Debug.Log("Cheating Failed!");
            count = 0;
        }
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        if(trumpet.click)
        {
            count++;
            Debug.Log(count);
        }
    }
}
