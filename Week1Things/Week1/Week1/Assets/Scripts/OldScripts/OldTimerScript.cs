using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OldTimerScript : MonoBehaviour
{
    Image Timer;
    public float maxTime = 100f; //the max amount of health
    public static float Duration;

    // Start is called before the first frame update
    void Start()
    {
        Timer = GetComponent<Image>(); //displays the healthbar image
        Duration = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        Timer.fillAmount = Duration / maxTime;
    }
}
