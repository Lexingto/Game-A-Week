using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Vector2 boxExtents;

    Rigidbody2D rigidBody;
    Animator animator;

    public float speed=5.0f;
    public float jumpForce=8.0f;
    public float airControlForce=10.0f;
    public float airControlMax=1.5f;

    public GameObject Checkpoint;
    public GameObject CheckpointTrigger;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxExtents = GetComponent<BoxCollider2D>().bounds.extents;
    }

    //Animation
    private void Update()
    {
        //AD keys
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


        //arrow keys 
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

        //jump
        if (Input.GetKeyDown("space"))
        {
            animator.SetBool("Jumping", true);
        }
        if (Input.GetKeyUp("space"))
        {
            animator.SetBool("Jumping", false);
        }
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        // check if we are on the ground
        Vector2 bottom = 
            new Vector2(transform.position.x,transform.position.y-boxExtents.y);
        Vector2 hitBoxSize = new Vector2(boxExtents.x * 2.0f, 0.05f);

        RaycastHit2D result = Physics2D.BoxCast(bottom,hitBoxSize, 0.0f,
            new Vector3(0.0f, -1.0f), 0.0f, 1 << LayerMask.NameToLayer("Ground"));
        
        bool grounded = result.collider != null && result.normal.y > 0.9f;
        if(grounded)
        {
            if (Input.GetAxis("Jump") > 0.0f)
            {
                rigidBody.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
            }

            else
            {
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

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject Player = GameObject.Find("Player");
        if (other.tag == "Fall")
        {
            this.rigidBody.Sleep();

            Player.transform.position = Checkpoint.transform.position;
            this.rigidBody.velocity = new Vector2(0, 0);

            this.rigidBody.WakeUp();

            Debug.Log("Hit FallBox");
        }

        if (other.tag == "Win")
        {
            SceneManager.LoadScene(0);
            Destroy(Player);
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Jump")
        {
            GameObject Player = GameObject.Find("Player");
            Player.GetComponent<Rigidbody2D>().gravityScale = 2f;
            rigidBody.AddForce(new Vector2(0.0f, 10f), ForceMode2D.Impulse);
        }
    }
}
