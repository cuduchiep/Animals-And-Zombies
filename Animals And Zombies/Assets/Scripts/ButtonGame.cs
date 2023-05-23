using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonGame : MonoBehaviour {
    
    public GameObject menu, lost;
    public GameObject speedBlack;

    bool isPause = false;
    bool isLost = false;
    bool isSpeed = false;

    public AudioSource audioSource;
    public AudioClip clipLost;

    private void FixedUpdate()
    {
        //Debug.Log(Time.time);
        if(isLost)
        {
            lost.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ButtonPause()
    {
        if (isPause)
        {
            Time.timeScale = 1;
            menu.SetActive(false);
        } else
        {
            Time.timeScale = 0;
            menu.SetActive(true);
        }
        isPause = !isPause;
        isSpeed = false;
        speedBlack.SetActive(false);
    }

    public void ButtonSpeed()
    {
        if(isSpeed)
        {
            Time.timeScale = 1;
            speedBlack.SetActive(false);
        } else
        {
            Time.timeScale = 2;
            speedBlack.SetActive(true);
        }
        isSpeed = !isSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            isLost = true;
            audioSource.PlayOneShot(clipLost);
        }
    }
}
