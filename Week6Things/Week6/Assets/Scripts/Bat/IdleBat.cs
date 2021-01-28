using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBat : MonoBehaviour
{
    public float speed;
    public bool Spooked;

    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Spooked == true)
        {
            Vector2 run = new Vector2(1, 1);
            transform.Translate(run * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject bat = GameObject.Find("IdleBat");
        Vector3 flip = new Vector3(-3, 3, 3);

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("fefe");
            Spooked = true;
            bat.transform.localScale = flip;
            anim.SetBool("Spooked", true);
        }
    }
}
