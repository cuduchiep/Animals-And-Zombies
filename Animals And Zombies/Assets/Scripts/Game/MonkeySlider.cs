using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonkeySlider : MonoBehaviour {

    Slider slider;

    public SpawnEnemy spawnEnemy;

	void Start () {
        slider = GetComponent<Slider>();
	}

	void FixedUpdate ()
    {
        slider.maxValue = spawnEnemy.maxCount;
        if (spawnEnemy.count > slider.value)
        {
            slider.value += 0.01f;
        }
	}
}
