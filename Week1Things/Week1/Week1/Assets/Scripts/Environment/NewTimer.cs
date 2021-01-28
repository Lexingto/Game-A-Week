using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Security.Cryptography;

public class NewTimer : MonoBehaviour
{

    public float timeLeft = 3.0f;
    public Text CountDownText;

    void Start() 
    {

    }
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            CountDownText.text = (timeLeft).ToString("0");
        }
        if (timeLeft < 0)
        {
            GameObject GameObject = GameObject.Find("Larry");
            GameObject.SetActive(false);

            SceneManager.LoadScene(1);
        }
    }
}