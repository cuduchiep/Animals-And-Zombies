using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardClick : MonoBehaviour, IPointerClickHandler {

    public Button button;
    public SelectPlayer selectPlayer;

    public int number;

    
    void Start () {
        button = GetComponent<Button>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(button.enabled)
        {
            selectPlayer.number = number;
        }
    }


}
