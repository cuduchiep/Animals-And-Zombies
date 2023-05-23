using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCheck : MonoBehaviour
{

    public GameObject black;
    public SpawnGold spawnGold;

    int level, card, currentLevel;

    void Start()
    {
        List<Database> list = SQLiteCore.GetDatabases();
        foreach (var c in list)
        {
            level = c.LEVEL;
            card = c.CARD;
            currentLevel = c.CURRENTLEVEL;
        }
    }
    void FixedUpdate()
    {
        if (currentLevel >= 1 && currentLevel <= 8)
        {
            black.SetActive(false);
            spawnGold.enabled = true;
        }
        else
        if (currentLevel >= 9 && currentLevel <= 15)
        {
            black.SetActive(true);
            spawnGold.enabled = false;
        }
        else if (currentLevel >= 16)
        {
            black.SetActive(false);
            spawnGold.enabled = true;
        }
    }
}
