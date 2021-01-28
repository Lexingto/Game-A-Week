using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2Controller : MonoBehaviour
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

    public bool Dashed; //Dash

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        boxExtents = GetComponent<BoxCollider2D>().bounds.extents;
    }

    private void Update()
    {        

        //animation
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetBool("Walking", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("Walking", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetBool("Walking", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("Walking", false);
        }

        //dash

        if (Input.GetKeyDown(KeyCode.RightControl) && Dashed == false)
        {
            rigidBody.AddForce(new Vector2(5f, 0f), ForceMode2D.Impulse);
            Dashed = true;
        }
        if (Input.GetKeyDown(KeyCode.RightAlt) && Dashed == false)
        {
            rigidBody.AddForce(new Vector2(-5f, 0f), ForceMode2D.Impulse);
            Dashed = true;
        }


    }
    private void FixedUpdate()
    {
        GameObject Player1 = GameObject.Find("Player1");
        float h = Input.GetAxis("Horizontal2");

        // check if we are on the ground
        Vector2 bottom =
                new Vector2(transform.position.x, transform.position.y - boxExtents.y);
        Vector2 hitBoxSize = new Vector2(boxExtents.x * 2.0f, 0.05f);

            
        RaycastHit2D result = Physics2D.BoxCast(bottom, hitBoxSize, 0.0f,
               new Vector3(0.0f, -1.0f), 0.0f, 1 << LayerMask.NameToLayer("Ground"));
        bool grounded = result.collider != null && result.normal.y > 0.9f;
        if (grounded)
        {
            Dashed = false;
            animator.SetBool("Jumping", false);
            GameObject Player2 = GameObject.Find("Player2");
            Player2.GetComponent<Rigidbody2D>().gravityScale = 1f;
            if (Input.GetAxis("Jump2") > 0.0f)
            {
                rigidBody.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
            }
            else
            {
                rigidBody.velocity = new Vector2(speed * h, rigidBody.velocity.y);
            }
        }
        else
        {
            animator.SetBool("Jumping", true);
            float vx = rigidBody.velocity.x;
            if (h * vx < airControlMax)
            rigidBody.AddForce(new Vector2(h * airControlForce, 0));
        }
    }

    //Player Touches Other player
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player1")
        {
            GameObject Player1 = GameObject.Find("Player1");
            Player1.GetComponent<Rigidbody2D>().gravityScale = 0.5f;
            Player1.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 5f), ForceMode2D.Impulse);
        }
    }

    //Push
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.name == "Player1")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("Forward Push P2");
                GameObject Player1 = GameObject.Find("Player1");

                audioSource.PlayOneShot(audioSource.clip, volume);


                StartCoroutine((IEnumerator)Chill());
                Player1.GetComponent<Rigidbody2D>().gravityScale = 0.5f;

                Player1.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10f, 5f), ForceMode2D.Impulse);
                Player1.GetComponent<Rigidbody2D>().WakeUp();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Back Push P2");
                GameObject Player1 = GameObject.Find("Player1");

                audioSource.PlayOneShot(audioSource.clip, volume);
                StartCoroutine((IEnumerator)Chill());
                Player1.GetComponent<Rigidbody2D>().gravityScale = 0.5f;

                Player1.GetComponent<Rigidbody2D>().AddForce(new Vector2(10f, 5f), ForceMode2D.Impulse);
                Player1.GetComponent<Rigidbody2D>().WakeUp();
            }
        }
    }

    //Sleeps rigidbody so player can be flung properly without player nullifying the force by going forward
    IEnumerable Chill()
    {
        while(true)
        {
            GameObject Player1 = GameObject.Find("Player1");
            Player1.GetComponent<Rigidbody2D>().Sleep();
            yield return new WaitForSeconds(1);
        }
    }
}
