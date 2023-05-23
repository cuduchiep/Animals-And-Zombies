using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trumpet : MonoBehaviour
{

    public bool click = false;
    public GameObject black;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null && hit.collider.isTrigger)
            {
                GameObject parent = hit.collider.gameObject;
                if (parent.gameObject.tag == "Player" && click)
                {
                    Debug.Log(hit.collider.gameObject.name);
                    Destroy(parent.gameObject);
                }
                if (parent.gameObject.tag == "Tile" && parent.gameObject.transform.childCount != 0 && click)
                {
                    if(parent.gameObject.transform.GetChild(0).gameObject.tag == "Blaze")
                    {
                        Debug.Log("Can't delete!");
                        return;
                    }
                    Health health = parent.gameObject.GetComponentInChildren<Health>();
                    Debug.Log(health.gameObject.name + " " + health.gameObject.transform.childCount);
                    if(health.gameObject.transform.childCount != 0)
                    {
                        if(health.gameObject.layer == LayerMask.NameToLayer("Water"))
                        {
                            return;
                        } else
                        {
                            Destroy(health.gameObject);
                        }
                    } else
                    {
                        Destroy(health.gameObject);
                    }
                }
            }
            click = false;
            black.SetActive(false);
        }
    }


    public void OnClick()
    {
        if (click)
        {
            click = false;
            black.SetActive(false);
        }
        else
        {
            click = true;
            black.SetActive(true);
        }
    }

}
