using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour {

    int level, card, currentLevel;

    public void ButtonHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void ButtonLevel()
    {
        List<Database> list = SQLiteCore.GetDatabases();
        int[] abc = new int[1];
        foreach (var c in list)
        {
            abc[0] = c.LEVEL;
            Debug.Log(c.ID + " " + c.LEVEL + " " + c.CARD);
        }
        if (abc[0] != 0)
        {
            Debug.Log("Chơi tiếp");
        }
        else
        {
            Debug.Log("Chơi mới");
            SQLiteCore.CreatePlayer(1, 1, 1, 0);
        }

        SceneManager.LoadScene("Level");
    }

    public void ButtonGame()
    {
        Time.timeScale = 1;
        List<Database> list = SQLiteCore.GetDatabases();
        foreach (var c in list)
        {
            level = c.LEVEL;
            card = c.CARD;
            currentLevel = c.CURRENTLEVEL;
        }
        if (currentLevel >= 1 && currentLevel <= 15)
        {
            SceneManager.LoadScene("Game");
        }
        if(currentLevel >= 16)
        {
            SceneManager.LoadScene("Game2");
        }
    }
}
