using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNext : MonoBehaviour
{
    public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = gameObject.GetComponent<DialogueManager>();
        //dialogueManager.StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dialogueManager.DisplayNextSentence();
            //dialogueManager.StartDialogue();
        }
    }
}
