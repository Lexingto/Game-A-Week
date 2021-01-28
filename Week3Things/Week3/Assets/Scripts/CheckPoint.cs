using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject Checkpoint;

    public GameObject Background;
    public GameObject BackgroundLIGHT;

    public Vector3 Checkpoint1 = new Vector3(64,18,-1);

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit Checkpoint");
        GameObject Player = GameObject.Find("Player");
        if (other.gameObject.tag == "Player")
        {
            GameObject Background = GameObject.Find("Main Camera");

            Background.transform.GetChild(0).gameObject.SetActive(false);
            Background.transform.GetChild(1).gameObject.SetActive(true);
            Checkpoint.transform.position = Checkpoint1;
        }
    }
}
