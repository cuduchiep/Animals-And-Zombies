using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    public int number;

    // Use this for initialization
    void Start()
    {

    }

    public void OnSelect(int number)
    {
        this.number = number;
    }
}
