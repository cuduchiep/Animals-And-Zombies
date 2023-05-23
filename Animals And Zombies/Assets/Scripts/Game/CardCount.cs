using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardCount : MonoBehaviour {

    public GameObject[] cards;
    public Image[] cardImages;
    public Sprite[] sprite;
    public CardClick[] cardClicks;
    public Text[] text;
    public CardButton[] cardButton;

    int level, card;
    int gold, number;
    int i = 0;


	void Start ()
    {
        List<Database> list = SQLiteCore.GetDatabases();
        foreach (var c in list)
        {
            level = c.LEVEL;
            card = c.CARD;
        }

        List<Database2> list2 = SQLiteCore.GetDatabases2();
        foreach (var c in list2)
        {
            gold = c.GOLD;
            number = c.NUMBER;
            text[i].text = gold + "";
            cardImages[i].sprite = sprite[number - 1];
            cardClicks[i].number = number;
            cardButton[i].number = number;

            if (number == 1 || number == 2 || number == 6 || number == 8 || number == 9 || number == 10 || number == 11 || number == 16 || number == 18 || number == 22)
            {
                cardButton[i].delayTime = 3;
            }
            else if(number == 13)
            {
                cardButton[i].delayTime = 2;
            }
            else
            {
                cardButton[i].delayTime = 1;
            }
            i++;
        }
    }
	
	
	void FixedUpdate () {
		if(card < cards.Length)
        {
            for(int i = 0;i< card;i++)
            {
                cards[i].SetActive(true);
            }
        } else
        {
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].SetActive(true);
            }
        }
	}
}
