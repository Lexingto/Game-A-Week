using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPlayerMovement : MonoBehaviour
{
    //CharacterController Controller;
    public Rigidbody rb;

    public float Speed;

    public Transform Cam;
    public bool OnGround = true;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
       //Controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        bool restartkey = Input.GetKeyDown(KeyCode.R);

        float Horizontal = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

        Vector3 Movement = Cam.transform.right * Horizontal + Cam.transform.forward * Vertical;
        Movement.y = 0f;

        transform.Translate(Horizontal, 0, Vertical);
        //Controller.Move(Movement);

        //walk animations and movement

        if (Movement.magnitude != 0f)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<NewCameraController>().sensivity * Time.deltaTime);
            animator.SetBool("Walk", true);

            Quaternion CamRotation = Cam.rotation;
            CamRotation.x = 0f;
            CamRotation.z = 0f;

            transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);
        }

        if (Movement.magnitude == 0f)
        {
            animator.SetBool("Walk", false);
        }

        //Jumping animations 

        if (Input.GetButtonDown("Jump") && OnGround)
        {
            Debug.log("jump");
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);

            OnGround = false;

            PlayJumpSound();
            animator.SetBool("Jumping", true);
        }

        //dev restart key
        if (restartkey == true)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Outside")
        {
            OnGround = true;
            animator.SetBool("Jumping", false);
        }

        if (collision.gameObject.tag == "Float")
        {
            OnGround = true;
            animator.SetBool("Jumping", false);
        }
    }

    private void PlayJumpSound()
    {
        audioSource.PlayOneShot(audioSource.clip, volume);
    }
}

