using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject Checkpoint;
    public Dialogue dialogue;

    public Vector3 Checkpoint1 = new Vector3(36,-2,-4);

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit Checkpoint");
        GameObject Player = GameObject.Find("Player");
        if (other.gameObject.tag == "Player")
        {
            Checkpoint.transform.position = Checkpoint1;
            TriggerDialogue();
        }        
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
