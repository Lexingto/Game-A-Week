using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    public GameObject Checkpoint;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject Player = GameObject.Find("Player");
            Player.transform.position = Checkpoint.transform.position;
        }
    }
}
