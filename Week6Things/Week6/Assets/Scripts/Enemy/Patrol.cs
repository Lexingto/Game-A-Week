using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool movingRight = true;

    public Transform groundDetection;

    public Animator anim;

    public bool Hit;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        HitAnimationScript Hit = FindObjectOfType<HitAnimationScript>();


        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                anim.SetBool("WalkingRight", true);
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        if(Hit.Collided == true)
        {
            Debug.Log(Hit.Collided);
            StartCoroutine(HitAnim());
        }
    }
    IEnumerator HitAnim()
    {
        HitAnimationScript Hit = FindObjectOfType<HitAnimationScript>();

        while (true)
        {
            Debug.Log(Hit.Collided + "Hitanim");
            anim.SetBool("Hit", true);
            yield return new WaitForSeconds(0.3f);

            anim.SetBool("Hit", false);
            Hit.Collided = false;

            yield break;
        }
    }
}
