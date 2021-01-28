using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public GameObject Background;
    public GameObject BackgroundLIGHT;

    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine(Lights());
    }

    IEnumerator Lights()
    {
        GameObject Background = GameObject.Find("Main Camera");
        while (true)
        {
            if (Background.transform.GetChild(0).gameObject.active == true)
            {
                Background.transform.GetChild(0).gameObject.SetActive(false);
                Background.transform.GetChild(1).gameObject.SetActive(true);
            }

            else
            {
                Background.transform.GetChild(0).gameObject.SetActive(true);
                Background.transform.GetChild(1).gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(5);
        }
    }
}