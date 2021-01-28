using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyScript : MonoBehaviour
{

    public Vector3 Origin = new Vector3(26, 21, -1);

    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject Fly = GameObject.Find("Fly");
        if (other.tag == "Wall")
        {
            Debug.Log("hit");
            Fly.transform.position = Origin;
        }
    }

}
