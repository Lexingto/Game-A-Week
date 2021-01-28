using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popuptextenemies : MonoBehaviour
{
    public GameObject Canvas;

    public string text;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit Text Trigger");
        GameObject Player = GameObject.Find("Player");
        if (other.gameObject.tag == "Player")
        {
            GameObject Canvas = GameObject.Find("Canvas");

            Canvas.transform.GetChild(0).gameObject.SetActive(true);
            Canvas.transform.GetChild(2).gameObject.SetActive(true);

        }
    }
}
