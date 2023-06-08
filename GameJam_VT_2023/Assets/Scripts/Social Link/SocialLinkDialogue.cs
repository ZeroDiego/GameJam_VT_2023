using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SocialLinkDialogue : MonoBehaviour
{

    [SerializeField] private string[] sentences1;
    [SerializeField] private string[] sentences2;
    public GameObject[] answers;

    public Text dialogueText;

    private int index;
    private bool canContinue;
    private int option;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < answers.Length; i++)
        {
            answers[i].SetActive(true);
        }
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(canContinue);
        //Debug.Log(Input.GetMouseButtonDown(0));
        if(canContinue && Input.GetMouseButtonDown(0))
        {
            index += 1;
            if(option == 1 && sentences1.Length > index)
            {
                dialogueText.text = sentences1[index];
            } else if(option == 2 && sentences2.Length > index)
            {
                dialogueText.text = sentences2[index];
            } else
            {
                dialogueText.gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    public void DialogueOption1()
    {
        option = 1;
        for(int i = 0; i < answers.Length; i++)
        {
            answers[i].SetActive(false);
        }
        canContinue = true;
        dialogueText.gameObject.SetActive(true);
        dialogueText.text = (sentences1[index]);
    }

    public void DialogueOption2()
    {
        option = 2;
        canContinue = true;
        dialogueText.gameObject.SetActive(true);
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].SetActive(false);          
        }
        dialogueText.text = (sentences2[index]);
    }
}
