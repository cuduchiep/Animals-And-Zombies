using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlayer : MonoBehaviour
{

    public GameObject monkey, hamster, wizard, stone, shrew, ice, snake, doubles;
    public GameObject frog, mouse, mushroom, owl, bunny, freeze, blaze;
    public GameObject raft, bear, snake3, otter, duck, flame, trap, fire, stone2;
    public GameObject[] tile;

    public SelectPlayer selectPlayer;
    public GoldChecker goldChecker;

    // Use this for initialization
    void Start()
    {
        tile = GameObject.FindGameObjectsWithTag("Tile");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                GameObject parent = hit.collider.gameObject;
                int number = selectPlayer.number;

                if (parent.gameObject.tag == "Water" && parent.gameObject.transform.childCount == 0)
                {
                    if (number == 16)
                    {
                        if (goldChecker.gold >= 25)
                        {
                            GameObject child = Instantiate(raft, new Vector2(parent.transform.position.x, parent.transform.position.y), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 25;
                            selectPlayer.number = 0;
                        }
                    } else if (number == 19)
                    {
                        if (goldChecker.gold >= 25)
                        {
                            GameObject child = Instantiate(otter, new Vector2(parent.transform.position.x, parent.transform.position.y + 0.5f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 25;
                            selectPlayer.number = 0;
                        }
                    } else if (number == 20)
                    {
                        if (goldChecker.gold >= 0)
                        {
                            GameObject child = Instantiate(duck, new Vector2(parent.transform.position.x, parent.transform.position.y + 0.2f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 0;
                            selectPlayer.number = 0;
                        }
                    }
                }
                else if ((parent.gameObject.tag == "Tile" && parent.gameObject.transform.childCount == 0) ||
                        (parent.gameObject.tag == "Player" && parent.gameObject.transform.childCount == 0 && parent.gameObject.layer == LayerMask.NameToLayer("Water"))
                        )
                {
                    //Debug.Log(hit.collider.gameObject.name);

                    if (number == 1)
                    {
                        if (goldChecker.gold >= 100)
                        {
                            GameObject child = Instantiate(monkey, new Vector2(parent.transform.position.x, parent.transform.position.y + 0.2f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 100;
                            selectPlayer.number = 0;
                        }
                    }
                    else if (number == 2)
                    {
                        if (goldChecker.gold >= 50)
                        {
                            GameObject child = Instantiate(hamster, new Vector2(parent.transform.position.x, parent.transform.position.y + 0.2f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 50;
                            selectPlayer.number = 0;
                        }
                    }
                    else if (number == 3)
                    {
                        if (goldChecker.gold >= 150)
                        {
                            GameObject child = Instantiate(wizard, new Vector2(parent.transform.position.x + 0.2f, parent.transform.position.y + 0.5f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 150;
                            selectPlayer.number = 0;
                        }
                    }
                    else if (number == 4)
                    {
                        if (goldChecker.gold >= 50)
                        {
                            GameObject child = Instantiate(stone, new Vector2(parent.transform.position.x, parent.transform.position.y + 0.2f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 50;
                            selectPlayer.number = 0;
                        }
                    }
                    else if (number == 5)
                    {
                        if (parent.gameObject.tag == "Player" && parent.gameObject.transform.childCount == 0 && parent.gameObject.layer == LayerMask.NameToLayer("Water"))
                        {
                            return;
                        }
                        else
                        {
                            if (goldChecker.gold >= 25)
                            {
                                GameObject child = Instantiate(shrew, new Vector2(parent.transform.position.x, parent.transform.position.y + 0.2f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                                child.transform.SetParent(parent.gameObject.transform);
                                goldChecker.gold -= 25;
                                selectPlayer.number = 0;
                            }
                        }
                    }
                    else if (number == 6)
                    {
                        if (goldChecker.gold >= 175)
                        {
                            GameObject child = Instantiate(ice, new Vector2(parent.transform.position.x, parent.transform.position.y + 0.2f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 175;
                            selectPlayer.number = 0;
                        }
                    }
                    else if (number == 7)
                    {
                        if (goldChecker.gold >= 150)
                        {
                            GameObject child = Instantiate(snake, new Vector2(parent.transform.position.x + 1.6f, parent.transform.position.y + 0.6f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 150;
                            selectPlayer.number = 0;
                        }
                    }
                    else if (number == 8)
                    {
                        if (goldChecker.gold >= 200)
                        {
                            GameObject child = Instantiate(doubles, new Vector2(parent.transform.position.x, parent.transform.position.y + 0.5f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 200;
                            selectPlayer.number = 0;
                        }
                    }
                    else if (number == 9)
                    {
                        if (goldChecker.gold >= 0)
                        {
                            GameObject child = Instantiate(frog, new Vector2(parent.transform.position.x, parent.transform.position.y), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 0;
                            selectPlayer.number = 0;
                        }
                    }
                    else if (number == 10)
                    {
                        if (goldChecker.gold >= 25)
                        {
                            GameObject child = Instantiate(mouse, new Vector2(parent.transform.position.x, parent.transform.position.y + 0.2f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 25;
                            selectPlayer.number = 0;
                        }
                    }
                    else if (number == 11)
                    {
                        if (goldChecker.gold >= 75)
                        {
                            GameObject child = Instantiate(mushroom, new Vector2(parent.transform.position.x, parent.transform.position.y + 0.2f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 75;
                            selectPlayer.number = 0;
                        }
                    }
                    else if (number == 12)
                    {
                        if (goldChecker.gold >= 75)
                        {
                            GameObject child = Instantiate(owl, new Vector2(parent.transform.position.x, parent.transform.position.y + 0.5f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 75;
                            selectPlayer.number = 0;
                        }
                    }
                    else if (number == 13)
                    {
                        if (goldChecker.gold >= 25)
                        {
                            GameObject child = Instantiate(bunny, new Vector2(parent.transform.position.x, parent.transform.position.y + 0.5f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 25;
                            selectPlayer.number = 0;
                        }
                    }
                    else if (number == 14)
                    {
                        if (goldChecker.gold >= 75)
                        {
                            GameObject child = Instantiate(freeze, new Vector2(parent.transform.position.x + 0.2f, parent.transform.position.y + 0.5f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 75;
                            selectPlayer.number = 0;
                        }
                    }
                    else if (number == 15)
                    {
                        if (goldChecker.gold >= 125)
                        {
                            GameObject child = Instantiate(blaze, new Vector2(parent.transform.position.x + 0, parent.transform.position.y + 0.5f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 125;
                            selectPlayer.number = 0;
                        }
                    }
                    else if (number == 17)
                    {
                        if (goldChecker.gold >= 50)
                        {
                            GameObject child = Instantiate(bear, new Vector2(parent.transform.position.x + 0, parent.transform.position.y + 0.5f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 50;
                            selectPlayer.number = 0;
                        }
                    }
                    else if (number == 18)
                    {
                        if (goldChecker.gold >= 325)
                        {
                            GameObject child = Instantiate(snake3, new Vector2(parent.transform.position.x + 0.15f, parent.transform.position.y + 0.7f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 325;
                            selectPlayer.number = 0;
                        }
                    }
                    else if (number == 21)
                    {
                        if (goldChecker.gold >= 125)
                        {
                            GameObject child = Instantiate(flame, new Vector2(parent.transform.position.x, parent.transform.position.y + 0.5f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 125;
                            selectPlayer.number = 0;
                        }
                    }
                    else if (number == 22)
                    {
                        if (parent.gameObject.tag == "Player" && parent.gameObject.transform.childCount == 0 && parent.gameObject.layer == LayerMask.NameToLayer("Water"))
                        {
                            return;
                        }
                        else
                        {
                            if (goldChecker.gold >= 100)
                            {
                                GameObject child = Instantiate(trap, new Vector2(parent.transform.position.x, parent.transform.position.y), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                                child.transform.SetParent(parent.gameObject.transform);
                                goldChecker.gold -= 100;
                                selectPlayer.number = 0;
                            }
                        }
                    }
                    else if (number == 23)
                    {
                        if (goldChecker.gold >= 175)
                        {
                            GameObject child = Instantiate(fire, new Vector2(parent.transform.position.x, parent.transform.position.y + 0.5f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 175;
                            selectPlayer.number = 0;
                        }
                    }
                    else if (number == 24)
                    {
                        if (goldChecker.gold >= 125)
                        {
                            GameObject child = Instantiate(stone2, new Vector2(parent.transform.position.x, parent.transform.position.y + 0.5f), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                            child.transform.SetParent(parent.gameObject.transform);
                            goldChecker.gold -= 125;
                            selectPlayer.number = 0;
                        }
                    }
                }

            }
        }
    }
}