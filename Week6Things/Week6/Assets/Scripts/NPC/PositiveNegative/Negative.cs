using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Negative : MonoBehaviour
{
    public Dialogue dialogue;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController Player = FindObjectOfType<PlayerController>();
            Player.NegativeChange();
            TriggerDialogue();
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
