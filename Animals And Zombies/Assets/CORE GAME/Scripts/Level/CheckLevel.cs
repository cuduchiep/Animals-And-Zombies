using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckLevel : MonoBehaviour
{

    public Button[] buttons, buttonCards;
    public GameObject[] black, blackCards;
    public Canvas levelCanvas, cardCanvas;
    public GameObject[] cardChooser;
    public Image[] cardImage;
    public Sprite[] sprite;
    public Text[] textChooser, textCard;

    public Button buttonPlay;
    public GameObject blackPlay;
    public GameObject backButton;

    int level;
    int card;
    int count = 0;

    // Use this for initialization
    void Start()
    {
        List<Database> list = SQLiteCore.GetDatabases();
        foreach (var c in list)
        {
            level = c.LEVEL;
            card = c.CARD;
        }

        //Check Level
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i >= level)
            {
                buttons[i].enabled = false;
                black[i].SetActive(true);
            }
            else
            {
                buttons[i].enabled = true;
                black[i].SetActive(false);
            }
        }

        //Check Card
        /*for (int i = 0; i < buttonCards.Length; i++)
        {
            if (i >= card)
            {
                buttonCards[i].enabled = false;
                blackCards[i].SetActive(true);
            }
            else
            {
                buttonCards[i].enabled = true;
                blackCards[i].SetActive(false);
            }
        }*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (card <= 6)
        {
            if (count < card)
            {
                buttonPlay.enabled = false;
                blackPlay.SetActive(true);
            }
            else
            {
                buttonPlay.enabled = true;
                blackPlay.SetActive(false);
            }
        }
        else
        {
            if (count < 6)
            {
                buttonPlay.enabled = false;
                blackPlay.SetActive(true);
            }
            else
            {
                buttonPlay.enabled = true;
                blackPlay.SetActive(false);
            }
        }
    }

    public void ChooseLevel(int chooseLevel)
    {
        levelCanvas.enabled = false;
        cardCanvas.enabled = true;
        backButton.SetActive(true);
        SQLiteCore.ChooseLevel(chooseLevel);
        Debug.Log("Level: " + chooseLevel);
    }

    public void ChooseCard(int chooseCard)
    {
        if (count < 6)
        {
            buttonCards[chooseCard - 1].enabled = false;
            blackCards[chooseCard - 1].SetActive(true);
            cardChooser[count].SetActive(true);
            cardImage[count].sprite = sprite[chooseCard - 1];
            textChooser[count].text = textCard[chooseCard - 1].text;
            count++;

            string name = buttonCards[chooseCard - 1].gameObject.name;
            int gold = int.Parse(textCard[chooseCard - 1].text);
            int number = chooseCard;
            SQLiteCore.ChooseCard(count, name, gold, number);
            Debug.Log(count + " " + name + " " + gold + " " + number);
        }
    }

    

    public void ButtonReback()
    {
        for (int i = 0; i < 6; i++)
        {
            cardChooser[i].SetActive(false);
        }
        for (int i = 0; i < buttonCards.Length; i++)
        {
            buttonCards[i].enabled = true;
            blackCards[i].SetActive(false);
        }
        count = 0;

        //Check Card
        for (int i = 0; i < buttonCards.Length; i++)
        {
            if (i >= card)
            {
                buttonCards[i].enabled = false;
                blackCards[i].SetActive(true);
            }
            else
            {
                buttonCards[i].enabled = true;
                blackCards[i].SetActive(false);
            }
        }
    }
    public void BackButton()
    {
        backButton.SetActive(false);
        ButtonReback();
        levelCanvas.enabled = true;
        cardCanvas.enabled = false;
    }
}
