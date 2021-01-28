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
    public AudioClip clip2;

    public float speed=5.0f;
    public float jumpForce=8.0f;
    public float airControlForce=10.0f;
    public float airControlMax=1.5f;

    public GameObject Checkpoint;
    public GameObject CheckpointTrigger;

    public int Happy = 3;

    public int Lives = 3;

    public bool Move = true;

    void Start()
    { 
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxExtents = GetComponent<BoxCollider2D>().bounds.extents;
    }

    //Animation
    private void Update()
    {
        //Animation bools

        //AD keys
        if (Input.GetKeyDown("a"))
        {
            if(Move == true)
            {
                Vector3 theScale = transform.localScale;
                theScale.x = -5;
                transform.localScale = theScale;

                animator.SetBool("Walking", true);
            }
        }
        if (Input.GetKeyUp("a"))
        {
            if (Move == true)
            {
                animator.SetBool("Walking", false);
            }
        }
        if (Input.GetKeyDown("d"))
        {
            if (Move == true)
            {
                Vector3 theScale = transform.localScale;
                theScale.x = 5;
                transform.localScale = theScale;

                animator.SetBool("Walking", true);
            }
        }
        if (Input.GetKeyUp("d"))
        {
            if (Move == true)
            {
                animator.SetBool("Walking", false);
            }
        }


        //arrow keys 
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Move == true)
            {
                Vector3 theScale = transform.localScale;
                theScale.x = 5;
                transform.localScale = theScale;

                animator.SetBool("Walking", true);
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (Move == true)
            {
                animator.SetBool("Walking", false);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (Move == true)
            {
                Vector3 theScale = transform.localScale;
                theScale.x = -5;
                transform.localScale = theScale;

                animator.SetBool("Walking", true);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (Move == true)
            {
                animator.SetBool("Walking", false);
            }
        }

        //Keep Happy within changing limits

        if(Happy >= 5)
        {
            Happy = 5;
        }

        if(Happy <= 0)
        {
            Happy = 0;
        }

        //Player Stat Changes

        if (Happy == 5)
        {
            speed = 7;
            jumpForce = 9;
            airControlMax = 1.7f;
            GameObject Environment = GameObject.Find("Environment");
            Environment.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (Happy == 4)
        {
            speed = 6;
            jumpForce = 8.5f;
            airControlMax = 1.6f;
            GameObject Environment = GameObject.Find("Environment");
            Environment.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (Happy == 3)
        {
            speed = 5;
            jumpForce = 8;
            airControlMax = 1.5f;
            GameObject Environment = GameObject.Find("Environment");
            Environment.transform.GetChild(0).gameObject.SetActive(false);
        }

        if (Happy == 2)
        {
            speed = 4;
            jumpForce = 7;
            airControlMax = 1.4f;
            GameObject Environment = GameObject.Find("Environment");
            Environment.transform.GetChild(0).gameObject.SetActive(false);
        }

        if (Happy == 1)
        {
            speed = 3;
            jumpForce = 6;
            airControlMax = 1.3f;
            GameObject Environment = GameObject.Find("Environment");
            Environment.transform.GetChild(0).gameObject.SetActive(false);
        }

        if (Happy <= 0)
        {
            speed = 2;
            GameObject Environment = GameObject.Find("Environment");
            Environment.transform.GetChild(0).gameObject.SetActive(false);
        }

    }
    private void FixedUpdate()
    {
        if (Move == true)
        {
            float h = Input.GetAxis("Horizontal");
            // check if we are on the ground
            Vector2 bottom =
                new Vector2(transform.position.x, transform.position.y - boxExtents.y);
            Vector2 hitBoxSize = new Vector2(boxExtents.x * 2.0f, 0.05f);

            RaycastHit2D result = Physics2D.BoxCast(bottom, hitBoxSize, 0.0f,
                new Vector3(0.0f, -1.0f), 0.0f, 1 << LayerMask.NameToLayer("Ground"));

            bool grounded = result.collider != null && result.normal.y > 0.9f;
            if (grounded)
            {
                if (Input.GetAxis("Jump") > 0.0f)
                {
                    animator.SetBool("Jumping", true);
                    audioSource.PlayOneShot(clip2, 0.5f);
                    rigidBody.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
                }

                else
                {
                    animator.SetBool("Jumping", false);
                    rigidBody.velocity = new Vector2(speed * h, rigidBody.velocity.y);
                }
                GameObject Player = GameObject.Find("Player");
                Player.GetComponent<Rigidbody2D>().gravityScale = 1f;
            }

            else
            {
                float vx = rigidBody.velocity.x;
                if (h * vx < airControlMax)
                    rigidBody.AddForce(new Vector2(h * airControlForce, 0));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject Player = GameObject.Find("Player");
        if (other.tag == "Fall")
        {
            Lives -= 1;

            LifeCheck();

            if (Lives != 0)
            {
                this.rigidBody.Sleep();

                Player.transform.position = Checkpoint.transform.position;
                this.rigidBody.velocity = new Vector3(0, 0);

                this.rigidBody.WakeUp();
            }
        }

        if (other.tag == "Win")
        {
            SceneManager.LoadScene(0);
            Destroy(Player);
        }

        if (other.tag == "Enemy")
        {
            if(Move == true)
            {
                audioSource.PlayOneShot(clip, 0.5f);
                Lives -= 1;

                LifeCheck();

                if (Lives !=0)
                {
                    this.rigidBody.Sleep();

                    Player.transform.position = Checkpoint.transform.position;
                    this.rigidBody.velocity = new Vector2(0, 0);

                    this.rigidBody.WakeUp();
                }

            }
        }
    }
    public void NegativeChange()
    {
        if(Happy == 0)
        {
            Debug.Log("Very Sad");
        }
        Happy -= 1;
    }

    public void PositiveChange()
    {
        if (Happy == 5)
        {
            Debug.Log("Very Happy");
        }
        Happy += 1;
    }

    public void LifeCheck()
    {
        if(Lives == 0)
        {
            StartCoroutine(DeathAnimation());
        }
    }

    IEnumerator DeathAnimation()
    {
        GameObject Player = GameObject.Find("Player");

        while (true)
        {
            animator.SetBool("Death", true);
            Move = false;
            yield return new WaitForSeconds(4);
            SceneManager.LoadScene(3);
            yield return new WaitForSeconds(0);
        }
    }
}
