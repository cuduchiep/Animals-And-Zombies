using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{

    public SelectPlayer selectPlayer;
    public GoldChecker goldChecker;
    public int number, temp;

    public GameObject black;
    public Image image;
    public Text text;
    public Button button;

    public bool isBlock = false;

    bool isFull = false;
    public int delayTime;
    public int gold;

    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gold = int.Parse(text.text);
        if (goldChecker.gold >= gold)
        {
            if (image.fillAmount == 0)
            {
                button.enabled = true;
                black.SetActive(false);
            }
            else
            {
                button.enabled = false;
                black.SetActive(true);
            }
        }
        if (number == selectPlayer.number)
        {
            temp = selectPlayer.number;
            black.SetActive(true);
        }
        else
        {
            if (selectPlayer.number == 0 && !isFull)
            {
                if (number == temp)
                {
                    image.fillAmount = 1f;
                    button.enabled = false;
                }
                isBlock = true;
                isFull = true;
            }
            temp = -1;
        }
        if (isBlock)
        {
            image.fillAmount -= (delayTime / 1000f);
            //isBlock = false;
            if (image.fillAmount == 0)
            {
                button.enabled = true;
                black.SetActive(false);
                isFull = false;
                isBlock = false;
            }
        }

        if (goldChecker.gold < gold)
        {
            button.enabled = false;
            black.SetActive(true);
        }
    }
}
