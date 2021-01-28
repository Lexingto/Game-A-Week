using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Vector2 boxExtents;

    Rigidbody2D rigidBody;
    Animator animator;

    public AudioSource audioSource;
    public AudioClip clip;

    public float volume = 0.5f;

    public float speed=5.0f;
    public float jumpForce=8.0f;
    public float airControlForce=10.0f;
    public float airControlMax=1.5f;

    public bool Dashed;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxExtents = GetComponent<BoxCollider2D>().bounds.extents;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        
        //animator
        if (Input.GetKeyDown("a"))
        {
            animator.SetBool("Walking", true);
        }
        if (Input.GetKeyUp("a"))
        {
            animator.SetBool("Walking", false);
        }
        if (Input.GetKeyDown("d"))
        {
            animator.SetBool("Walking", true);
        }
        if (Input.GetKeyUp("d"))
        {
            animator.SetBool("Walking", false);
        }

        //dash

        if (Input.GetKeyDown(KeyCode.LeftAlt) && Dashed == false)
        {
            rigidBody.AddForce(new Vector2(5f, 0f), ForceMode2D.Impulse);
            Dashed = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && Dashed == false)
        {
            rigidBody.AddForce(new Vector2(-5f, 0f), ForceMode2D.Impulse);
            Dashed = true;
        }

    }
    private void FixedUpdate()
    {
            float i = Input.GetAxis("Horizontal");
            // check if we are on the ground
            Vector2 bottom2 =
                new Vector2(transform.position.x, transform.position.y - boxExtents.y);
            Vector2 hitBoxSize2 = new Vector2(boxExtents.x * 2.0f, 0.05f);

            RaycastHit2D result2 = Physics2D.BoxCast(bottom2, hitBoxSize2, 0.0f,
                new Vector3(0.0f, -1.0f), 0.0f, 1 << LayerMask.NameToLayer("Ground"));

            bool grounded = result2.collider != null && result2.normal.y > 0.9f;
            if (grounded)
            {
                Dashed = false;
                animator.SetBool("Jumping", false);
                GameObject Player1 = GameObject.Find("Player1");
                Player1.GetComponent<Rigidbody2D>().gravityScale = 1f;
                if (Input.GetAxis("Jump") > 0.0f)
                {
                    rigidBody.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
                }

                else
                {
                    rigidBody.velocity = new Vector2(speed * i, rigidBody.velocity.y);
                }
            }

            else
            {
                 animator.SetBool("Jumping", true);
                float vx = rigidBody.velocity.x;
                if (i * vx < airControlMax)
                    rigidBody.AddForce(new Vector2(i * airControlForce, 0));
            }
    }

    //Player Touches Other player

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player2")
        {
            GameObject Player2 = GameObject.Find("Player2");
            Player2.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            Player2.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 5f), ForceMode2D.Impulse);
        }
    }

    //Push
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.name == "Player2")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Back Push P1");
                GameObject Player2 = GameObject.Find("Player2");

                audioSource.PlayOneShot(audioSource.clip, volume);
                StartCoroutine((IEnumerator)Chill());
                Player2.GetComponent<Rigidbody2D>().gravityScale = 0.5f;

                Player2.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10f, 5f), ForceMode2D.Impulse);

                Player2.GetComponent<Rigidbody2D>().WakeUp();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Forward Push P1");
                GameObject Player2 = GameObject.Find("Player2");

                audioSource.PlayOneShot(audioSource.clip, volume);
                StartCoroutine((IEnumerator)Chill());
                Player2.GetComponent<Rigidbody2D>().gravityScale = 0.5f;

                Player2.GetComponent<Rigidbody2D>().AddForce(new Vector2(10f, 5f), ForceMode2D.Impulse);

                Player2.GetComponent<Rigidbody2D>().WakeUp();
            }
        }
    }

    //Sleeps rigidbody so player can be flung properly without player nullifying the force by going forward

    IEnumerable Chill()
    {
        while (true)
        {
            GameObject Player1 = GameObject.Find("Player1");
            Player1.GetComponent<Rigidbody2D>().Sleep();
            yield return new WaitForSeconds(1);
        }
    }
}
