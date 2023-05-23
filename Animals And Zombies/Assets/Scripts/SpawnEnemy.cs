using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject monster, monster2, horse, monster3, fast, witch, aqua, aqua2, aqua3, tank;
    public GameObject[] check;
    float[] locationY = { 2.5f, 1.15f, -0.2f, -1.55f, -2.9f };

    public GameObject win, ending;
    bool isEnd = false;

    float nextSpawn, spawnRate;

    public int count = 0, maxCount = -1;

    bool isWin = false;
    
    public AudioSource audioSource;
    public AudioClip clipWin;

    int level, card, currentLevel;

    // Use this for initialization
    void Start()
    {
        nextSpawn = Time.time + 25f;
        List<Database> list = SQLiteCore.GetDatabases();
        foreach (var c in list)
        {
            level = c.LEVEL;
            card = c.CARD;
            currentLevel = c.CURRENTLEVEL;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        check = GameObject.FindGameObjectsWithTag("Enemy");
        if (count == maxCount)
        {
            if (!isEnd)
            {
                ending.SetActive(true);
                isEnd = true;
            }
            if (check.Length == 0)
            {
                win.SetActive(true);
                Debug.Log("Win");
                if (!isWin)
                {
                    isWin = true;
                    audioSource.PlayOneShot(clipWin);

                    if (level < 24)
                    {
                        if (currentLevel == level)
                        {
                            level++;
                            card++;
                            SQLiteCore.UpLevel(level, card);
                        }
                    }
                }

            }
        }
        else
        {
            if (Time.time > nextSpawn)
            {
                if (currentLevel == 1)
                {
                    maxCount = 1;
                    level1(monster);
                }
                else
                {

                    if (currentLevel == 2)
                    {
                        levelEasy(monster, monster, monster, monster, monster);
                    }
                    else if (currentLevel == 3)
                    {
                        levelEasy(monster, monster2, monster, monster, monster);
                    }
                    else if (currentLevel == 4)
                    {
                        levelNormal(monster, monster2, monster, monster, monster);
                    }
                    else if (currentLevel == 5)
                    {
                        levelNormal(monster, monster2, monster, horse, monster);
                    }
                    else if (currentLevel == 6)
                    {
                        levelHard(monster, monster2, monster, horse, monster);
                    }
                    else if (currentLevel == 7)
                    {
                        levelHard(monster, monster2, monster3, horse, monster);
                    }
                    else if (currentLevel == 8)
                    {
                        levelBoss(monster, monster2, monster3, horse, monster2);
                    }
                    else if (currentLevel == 9)
                    {
                        levelEasy(monster, monster, monster, monster, monster);
                    }
                    else if (currentLevel == 10)
                    {
                        levelNormal(monster, monster2, monster, monster, monster);
                    }
                    else if (currentLevel == 11)
                    {
                        levelNormal(monster, monster2, fast, fast, fast);
                    }
                    else if (currentLevel == 12)
                    {
                        levelHard(monster, monster2, fast, horse, fast);
                    }
                    else if (currentLevel == 13)
                    {
                        levelHard(monster, fast, monster3, horse, fast);
                    }
                    else if (currentLevel == 14)
                    {
                        levelHard(monster, fast, monster3, horse, witch);
                    }
                    else if (currentLevel == 15)
                    {
                        levelBoss(monster, fast, monster3, horse, witch);
                    }
                    else if (currentLevel == 16)
                    {
                        levelEasy2(monster, monster2, aqua, aqua, monster);
                    }
                    else if (currentLevel == 17)
                    {
                        levelEasy2(monster, monster2, aqua, aqua2, monster);
                    }
                    else if(currentLevel == 18)
                    {
                        levelNormal2(monster, monster2, aqua, aqua2, monster);
                    }
                    else if(currentLevel == 19)
                    {
                        levelNormal2(monster, monster2, aqua, aqua2, horse);
                    }
                    else if(currentLevel == 20)
                    {
                        levelNormal2(monster, fast, aqua, aqua2, horse);
                    }
                    else if(currentLevel == 21)
                    {
                        levelHard2(monster, monster2, fast, horse, aqua, aqua2, aqua);
                    }
                    else if(currentLevel == 22)
                    {
                        levelHard2(monster, monster2, monster3, horse, aqua, aqua2, aqua3);
                    }
                    else if(currentLevel == 23)
                    {
                        levelHard2(monster, monster2, monster3, tank, aqua, aqua2, aqua3);
                    }
                    else if(currentLevel == 24)
                    {
                        levelBoss2(monster, monster2, monster3, horse, tank, witch, aqua, aqua2, aqua3);
                    }
                    else
                    {
                        levelEasy(monster, monster, monster, monster, monster);
                    }
                }


                spawnRate = Random.Range(18f, 25f);
                nextSpawn = Time.time + spawnRate;
                Debug.Log(count);
                count++;
            }
        }
    }

    public void level1(GameObject mob1)
    {
        int check = Random.Range(0, 5);
        Instantiate(mob1, new Vector2(10.2f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
    }

    public void levelEasy(GameObject mob1, GameObject mob2, GameObject mob3, GameObject mob4, GameObject mob5)
    {
        maxCount = 10;
        int check = Random.Range(0, 5);
        Instantiate(mob1, new Vector2(10.2f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        if (count > 2)
        {
            check = Random.Range(0, 5);
            Instantiate(mob1, new Vector2(10.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 5)
        {
            check = Random.Range(0, 5);
            Instantiate(mob2, new Vector2(10.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count >= 9)
        {
            check = Random.Range(0, 5);
            Instantiate(mob1, new Vector2(11.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob2, new Vector2(11.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob1, new Vector2(11.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob2, new Vector2(12.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    public void levelEasy2(GameObject mob1, GameObject mob2, GameObject mob3, GameObject mob4, GameObject mob5)
    {
        maxCount = 10;
        int check = Random.Range(0, 3);
        Instantiate(mob1, new Vector2(10.2f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        if (count > 2)
        {
            check = Random.Range(3, 5);
            Instantiate(mob3, new Vector2(10.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 5)
        {
            check = Random.Range(0, 3);
            Instantiate(mob2, new Vector2(10.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(3, 5);
            Instantiate(mob4, new Vector2(10.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count >= 9)
        {
            check = Random.Range(0, 3);
            Instantiate(mob2, new Vector2(11.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(3, 5);
            Instantiate(mob3, new Vector2(11.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 3);
            Instantiate(mob2, new Vector2(11.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(3, 5);
            Instantiate(mob4, new Vector2(12.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    public void levelNormal(GameObject mob1, GameObject mob2, GameObject mob3, GameObject mob4, GameObject mob5)
    {
        maxCount = 14;
        int check = Random.Range(0, 5);
        Instantiate(mob1, new Vector2(10.2f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        if (count > 2)
        {
            check = Random.Range(0, 5);
            Instantiate(mob1, new Vector2(10.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 5)
        {
            check = Random.Range(0, 5);
            Instantiate(mob2, new Vector2(10.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 9)
        {
            check = Random.Range(0, 5);
            Instantiate(mob3, new Vector2(10.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob4, new Vector2(11.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count >= 13)
        {
            check = Random.Range(0, 5);
            Instantiate(mob5, new Vector2(11.3f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob4, new Vector2(11.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob2, new Vector2(11.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob2, new Vector2(12.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob3, new Vector2(12.3f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    public void levelNormal2(GameObject mob1, GameObject mob2, GameObject mob3, GameObject mob4, GameObject mob5)
    {
        maxCount = 14;
        int check = Random.Range(0, 3);
        Instantiate(mob1, new Vector2(10.2f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        if (count > 2)
        {
            check = Random.Range(3, 5);
            Instantiate(mob3, new Vector2(10.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 5)
        {
            check = Random.Range(0, 3);
            Instantiate(mob2, new Vector2(10.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 9)
        {
            check = Random.Range(0, 3);
            Instantiate(mob2, new Vector2(10.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(3, 5);
            Instantiate(mob4, new Vector2(11.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 3);
            Instantiate(mob5, new Vector2(11.3f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count >= 13)
        {
            check = Random.Range(0, 3);
            Instantiate(mob5, new Vector2(11.3f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(3, 5);
            Instantiate(mob4, new Vector2(11.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 3);
            Instantiate(mob2, new Vector2(11.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 3);
            Instantiate(mob2, new Vector2(12.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(3, 5);
            Instantiate(mob3, new Vector2(12.3f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    public void levelHard(GameObject mob1, GameObject mob2, GameObject mob3, GameObject mob4, GameObject mob5)
    {
        maxCount = 18;
        int check = Random.Range(0, 5);
        Instantiate(mob1, new Vector2(10.2f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        if (count > 2)
        {
            check = Random.Range(0, 5);
            Instantiate(mob1, new Vector2(10.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 5)
        {
            check = Random.Range(0, 5);
            Instantiate(mob2, new Vector2(10.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 8)
        {
            check = Random.Range(0, 5);
            Instantiate(mob4, new Vector2(11.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob5, new Vector2(11.2f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 14)
        {
            check = Random.Range(0, 5);
            Instantiate(mob3, new Vector2(11.3f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob5, new Vector2(11.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count >= 17)
        {
            check = Random.Range(0, 5);
            Instantiate(mob1, new Vector2(11.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob2, new Vector2(12.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob3, new Vector2(12.3f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob4, new Vector2(12.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob5, new Vector2(12.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob5, new Vector2(13.4f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    public void levelHard2(GameObject mob1, GameObject mob2, GameObject mob3, GameObject mob4, GameObject mob5, GameObject mob6, GameObject mob7)
    {
        maxCount = 18;
        int check = Random.Range(0, 3);
        Instantiate(mob1, new Vector2(10.2f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        if (count > 2)
        {
            check = Random.Range(3, 5);
            Instantiate(mob5, new Vector2(10.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 5)
        {
            check = Random.Range(0, 3);
            Instantiate(mob2, new Vector2(10.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 8)
        {
            check = Random.Range(0, 3);
            Instantiate(mob4, new Vector2(11.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(3, 5);
            Instantiate(mob6, new Vector2(11.2f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 14)
        {
            check = Random.Range(0, 3);
            Instantiate(mob3, new Vector2(11.3f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(3, 5);
            Instantiate(mob7, new Vector2(11.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count >= 17)
        {
            check = Random.Range(0, 3);
            Instantiate(mob1, new Vector2(11.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 3);
            Instantiate(mob2, new Vector2(12.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 3);
            Instantiate(mob3, new Vector2(12.3f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 3);
            Instantiate(mob4, new Vector2(12.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(3, 5);
            Instantiate(mob5, new Vector2(12.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(3, 5);
            Instantiate(mob7, new Vector2(13.4f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    public void levelBoss(GameObject mob1, GameObject mob2, GameObject mob3, GameObject mob4, GameObject mob5)
    {
        maxCount = 25;
        int check = Random.Range(0, 5);
        Instantiate(mob1, new Vector2(10.2f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        if (count > 2)
        {
            check = Random.Range(0, 5);
            Instantiate(mob1, new Vector2(10.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 4)
        {
            check = Random.Range(0, 5);
            Instantiate(mob2, new Vector2(10.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 9)
        {
            check = Random.Range(0, 5);
            Instantiate(mob4, new Vector2(11.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 14)
        {
            check = Random.Range(0, 5);
            Instantiate(mob3, new Vector2(11.3f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob2, new Vector2(11.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 17)
        {
            check = Random.Range(0, 5);
            Instantiate(mob3, new Vector2(11.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob2, new Vector2(12.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 20)
        {
            check = Random.Range(0, 5);
            Instantiate(mob4, new Vector2(11.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob5, new Vector2(12.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob2, new Vector2(12.3f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count >= 24)
        {
            check = Random.Range(0, 5);
            Instantiate(mob4, new Vector2(12.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob5, new Vector2(12.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob5, new Vector2(13.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob3, new Vector2(13.3f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob2, new Vector2(13.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob3, new Vector2(13.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob3, new Vector2(14.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob2, new Vector2(14.3f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 5);
            Instantiate(mob3, new Vector2(14.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    public void levelBoss2(GameObject mob1, GameObject mob2, GameObject mob3, GameObject mob4, GameObject mob5, GameObject mob6, GameObject mob7, GameObject mob8, GameObject mob9)
    {
        maxCount = 25;
        int check = Random.Range(0, 3);
        Instantiate(mob1, new Vector2(10.2f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        if (count > 2)
        {
            check = Random.Range(3, 5);
            Instantiate(mob7, new Vector2(10.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 4)
        {
            check = Random.Range(0, 3);
            Instantiate(mob2, new Vector2(10.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 9)
        {
            check = Random.Range(3, 5);
            Instantiate(mob8, new Vector2(11.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 14)
        {
            check = Random.Range(0, 3);
            Instantiate(mob1, new Vector2(11.3f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 3);
            Instantiate(mob4, new Vector2(11.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 17)
        {
            check = Random.Range(0, 3);
            Instantiate(mob5, new Vector2(11.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(3, 5);
            Instantiate(mob7, new Vector2(12.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count > 20)
        {
            check = Random.Range(0, 3);
            Instantiate(mob6, new Vector2(11.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 3);
            Instantiate(mob3, new Vector2(12.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(3, 5);
            Instantiate(mob9, new Vector2(12.3f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if (count >= 24)
        {
            check = Random.Range(0, 3);
            Instantiate(mob1, new Vector2(12.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 3);
            Instantiate(mob2, new Vector2(12.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 3);
            Instantiate(mob3, new Vector2(13.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 3);
            Instantiate(mob4, new Vector2(13.3f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 3);
            Instantiate(mob5, new Vector2(13.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(0, 3);
            Instantiate(mob6, new Vector2(13.8f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(3, 5);
            Instantiate(mob7, new Vector2(14.0f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(3, 5);
            Instantiate(mob8, new Vector2(14.3f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
            check = Random.Range(3, 5);
            Instantiate(mob9, new Vector2(14.5f, locationY[check]), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

}