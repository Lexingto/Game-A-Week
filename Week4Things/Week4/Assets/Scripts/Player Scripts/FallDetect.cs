using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FallDetect : MonoBehaviour
{
    public bool p1fell = false;
    public bool p2fell = false;

    public AudioSource audioSource;
    public AudioClip clip;

    public float volume = 0.5f;

    public ParticleSystem ps;

    public GameObject Player2;
    public GameObject Player1;

    public Vector3 Win = new Vector3(-70, 2, 0);
    public Vector3 Lose = new Vector3(90, 3, 0);


    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D other)
    {

        //winner check
        if (other.tag == "Player1" && p2fell == false)
        {
            StartCoroutine(P1Lose());
        }
        if (other.tag == "Player2" && p1fell == false)
        {
            StartCoroutine(P2Lose());
        }

        //fall of podium checks

        if (other.tag == "Player2" && p1fell == true)
        {
            Debug.Log("P2 Fell of podium");
            Player2.transform.position = Win;
        }
        if (other.tag == "Player1" && p2fell == true)
        {
            Debug.Log("P1 Fell of podium");
            Player1.transform.position = Win;
        }

        if (other.tag == "Player1" && p1fell == true)
        {
            Debug.Log("P1 Fell of podium");
            Player1.transform.position = Lose;
        }
        if (other.tag == "Player2" && p2fell == true)
        {
            Debug.Log("P2 Fell of podium");
            Player2.transform.position = Lose;
        }
    }

    IEnumerator P1Lose()
    {
        Debug.Log("P1 Fell");
        ps.transform.position = Player1.transform.position;
        ps.Play();
        yield return new WaitForSeconds(1);

        p1fell = true;
        Debug.Log("P1 Fell Bool");

        audioSource.PlayOneShot(audioSource.clip, volume);

        ps.transform.position = Win;

        Player2.transform.position = Win;
        Player1.transform.position = Lose;
    }
    IEnumerator P2Lose()
    {
        Debug.Log("P2 Fell");
        ps.transform.position = Player2.transform.localPosition;
        ps.Play();
        yield return new WaitForSeconds(1);

        p2fell = true;
        Debug.Log("P2 Fell Bool");

        audioSource.PlayOneShot(audioSource.clip, volume);

        ps.transform.position = Win;
        ps.Play();

        Player2.transform.position = Lose;
        Player1.transform.position = Win;
    }
}
