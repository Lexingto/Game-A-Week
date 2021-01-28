using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using JetBrains.Annotations;

public class FirstButton : MonoBehaviour //Used to be The Timer Change Script
{
    public Transform TimerCanvas;
    public Text Mission;
    public bool firstpressed;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

    public int temp;

    public int Max = 7;
    public int Min = 0;
    public GameObject Buttons;

    public Animator anim;
    public double x = -0.018;
    public double y = 0.016;
    public double z = -0.49;

    //float maxTime = 100f;
    // Update is called once per frame
    void Update()
    {
        if (firstpressed == true)
        {
            /*if (TimerScript.Duration != 0) //Used to be a Bar Timer
            {
                TimerScript.Duration -= 0.1f;
                Debug.Log("Test1"); 
            }
            if (TimerScript.Duration == 0)
            {
                Debug.Log("Test");
                GameObject HumanObject = GameObject.Find("Human");
                HumanObject.SetActive(false);
            }
            */
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (firstpressed == false)
        {
            if (other.gameObject.tag == "Player")
            {
                firstpressed = true;

                //GameObject Cube = GameObject.Find("Cube");
                //Cube.transform.position = new Vector3((float)x, (float)y, (float)z); //(trying to get the cube in the button to move back a little to look like it has been pressed)

                //anim.SetBool("Pressed", true); (trying to get the cube in the button to move back a little to look like it has been pressed)

                Debug.Log("Button 1 was Hit!");

                GameObject Box = GameObject.Find("Box");
                Box.transform.GetChild(0).gameObject.SetActive(false);

                Mission = (Text)GameObject.Find("Mission").GetComponent<Text>();
                Mission.text = ("Find the escape button!");

                PlayButtonSound();

                DisableMethod();

                //GameObject ObjCanvas = GameObject.Find("Mission");
                //ObjCanvas.SetActive(false);
            }
        }
    }
    public void DisableMethod()
    {
        GameObject Buttons = GameObject.Find("Buttons");
        temp = Random.Range(Min, Max);
        Debug.Log(temp);

        switch (temp)
        {
            case 0:
                Debug.Log(Buttons.ToString() + " ");
                Buttons.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 1:
                Debug.Log(Buttons.ToString() + " ");
                Buttons.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 2:
                Debug.Log(Buttons.ToString() + " ");
                Buttons.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 3:
                Debug.Log(Buttons.ToString() + " ");
                Buttons.transform.GetChild(3).gameObject.SetActive(true);
                break;
            case 4:
                Debug.Log(Buttons.ToString() + " ");
                Buttons.transform.GetChild(4).gameObject.SetActive(true);
                break;
            case 5:
                Debug.Log(Buttons.ToString() + " ");
                Buttons.transform.GetChild(5).gameObject.SetActive(true);
                break;
            case 6:
                Debug.Log(Buttons.ToString() + " ");
                Buttons.transform.GetChild(6).gameObject.SetActive(true);
                break;
        }
    }
    
    private void PlayButtonSound()
    {
        audioSource.PlayOneShot(audioSource.clip, volume);
    }
}
