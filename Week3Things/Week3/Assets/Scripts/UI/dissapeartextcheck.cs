using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissapeartextcheck : MonoBehaviour
{
    public GameObject Canvas;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit Text Trigger");
        GameObject Player = GameObject.Find("Player");
        if (other.gameObject.tag == "Player")
        {
            GameObject Canvas = GameObject.Find("Canvas");

            Canvas.transform.GetChild(0).gameObject.SetActive(false);
            Canvas.transform.GetChild(3).gameObject.SetActive(false);
        }
    }
}
