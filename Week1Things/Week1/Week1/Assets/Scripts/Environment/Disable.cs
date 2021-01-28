using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    public int Min = 0;
    public int Max = 7;

    GameObject GameObject;

    public int temp;
    public void Selecter()
    {
        temp = Random.Range(Min, Max);
        Debug.Log(temp);

        switch(temp)
        {
            case 0:
                GameObject.Find("WinButton").gameObject.SetActive(true);
                break;
            case 1:
                GameObject.Find("WinButton (2)").gameObject.SetActive(true);
                break;
            case 2:
                GameObject.Find("WinButton (3)").gameObject.SetActive(true);
                break;
            case 3:
                GameObject.Find("WinButton (4)").gameObject.SetActive(true);
                break;
            case 4:
                GameObject.Find("WinButton (5)").gameObject.SetActive(true);
                break;
            case 5:
                GameObject.Find("WinButton (6)").gameObject.SetActive(true);
                break;
            case 6:
                GameObject.Find("WinButton (7)").gameObject.SetActive(true);
                break;
        }
    }
}
