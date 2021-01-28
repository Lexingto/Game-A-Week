using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public Text text;
    public void Update()
    {
        PlayerController Life = FindObjectOfType<PlayerController>();

        string count = Life.Lives.ToString();
        text.text = "Lives - " + count;
    }
}
