using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positive : MonoBehaviour
{
    public Dialogue dialogue;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController Player = FindObjectOfType<PlayerController>();
            Player.PositiveChange();
            TriggerDialogue();
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
