using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialNPC2 : MonoBehaviour
{
    public Dialogue dialogue;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TriggerDialogue();
        }
    }


    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
