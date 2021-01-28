using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAnimationScript : MonoBehaviour
{
    public Animator anim;

    public bool Collided;

    public AudioSource audioSource;
    public AudioClip clip;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Collided = true;
            audioSource.PlayOneShot(clip, 0.5f);
        }
    }
}
