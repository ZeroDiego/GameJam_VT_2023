using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool conversationStarted;
    //public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        conversationStarted = false;
        //dialogueManager = gameObject.GetComponent<DialogueManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && conversationStarted)
        {
            FindAnyObjectByType<DialogueManager>().DisplayNextSentence();
            //dialogueManager.StartDialogue();
        } else if(Input.GetKeyDown(KeyCode.Space) && !conversationStarted)
        {
            conversationStarted = true;
            TriggerDialogue();
            
        }
    }

    public void TriggerDialogue()
    {
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);
    }


}
