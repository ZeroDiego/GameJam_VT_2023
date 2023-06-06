using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public float textSpeed = 0.1f;
    private int dialogueIndex = 0;
    private bool conversationStarted;

    public Text nameText;
    public Text dialogueText;
    public Image image;

    public Animator animator;

    public Queue<string> sentences;

    public GameObject[] characterList;
    private DialogueTrigger dialogueTrigger;

    // Start is called before the first frame update
    void Start()
    {
        dialogueIndex = 0;
        sentences = new Queue<string>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && conversationStarted)
        {
            FindAnyObjectByType<DialogueManager>().DisplayNextSentence();
            //dialogueManager.StartDialogue();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !conversationStarted)
        {
            conversationStarted = true;
            characterList[dialogueIndex].GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {

        animator.SetBool("IsOpen", true);
        //Debug.Log("Starting conversation with " + dialogue.name);
        //Debug.Log(dialogue.name);
        nameText.text = dialogue.name;
        image = dialogue.characterImage;
        Debug.Log(image);
        image.color = new Color32(255, 255, 255, 255);


        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //Debug.Log(sentence);
        //dialogueText.text = sentence;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void EndDialogue()
    {
        //animator.SetBool("IsOpen", false);

        try
        {
            Debug.Log(image);
            image.color = new Color32(80, 80, 80, 255);
            dialogueIndex++;
            characterList[dialogueIndex].GetComponent<DialogueTrigger>().TriggerDialogue();
        } catch(Exception e)
        {
            Console.WriteLine(e.Message);
            animator.SetBool("IsOpen", false);
        }

        //Debug.Log("End conversation");
    }


}
