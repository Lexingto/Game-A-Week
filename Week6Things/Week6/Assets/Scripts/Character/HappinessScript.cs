using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessScript : MonoBehaviour
{
    public Text text;
    public void Update()
    {
        PlayerController Happy = FindObjectOfType<PlayerController>();

        string count = Happy.Happy.ToString();
        text.text = "Happiness - " + count;
    }
}
