using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondButton : MonoBehaviour
{
    public Transform TimerCanvas;
    public Transform ObjCanvas;

    public Text Mission;
    public Text CountDownText;

    public bool secondpressed;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (secondpressed == false)
        {
            if (other.gameObject.tag == "Player")
            {
                secondpressed = true;
                Debug.Log("Button 2 was Hit!");

                Mission = (Text)GameObject.Find("Mission").GetComponent<Text>();
                Mission.text = ("You Win!");

                GameObject TimerCanvas = GameObject.Find("CountDownText");
                TimerCanvas.SetActive(false);

                GameObject Outside = GameObject.Find("FakeWallMaze");
                Outside.SetActive(false);

                PlayButtonSound();

                //SceneManager.LoadScene(1); Win Screen alternative
            }
        }
    }
    private void PlayButtonSound()
        {
            audioSource.PlayOneShot(audioSource.clip, volume);
        }
}
