using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip clipMorning, clipBoss, clipNight;
    int level, card, currentLevel;

    void Start () {
        audioSource = GetComponent<AudioSource>();
        List<Database> list = SQLiteCore.GetDatabases();
        foreach (var c in list)
        {
            level = c.LEVEL;
            card = c.CARD;
            currentLevel = c.CURRENTLEVEL;
        }
    }

    // cập nhật nhạc cho từng level
    void FixedUpdate()
    {
        if (!audioSource.isPlaying)
        {
            if (currentLevel == 8 || currentLevel == 15 || currentLevel == 24)
            {
                audioSource.PlayOneShot(clipBoss);
            }
            if (currentLevel >= 1 && currentLevel <= 7)
            {
                audioSource.PlayOneShot(clipMorning);
            }
            if (currentLevel >= 9 && currentLevel <= 14)
            {
                audioSource.PlayOneShot(clipNight);
            }
            if (currentLevel >= 16 && currentLevel <= 23)
            {
                audioSource.PlayOneShot(clipMorning);
            }
        }

    }
}
