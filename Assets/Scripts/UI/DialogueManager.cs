using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

//i'm not sure there's time for me to fully flesh out the diaglogue and story, but here is the script i planned on using

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] sentences;
    private int index;

    void Start()
    {
        dialoguePanel.SetActive(false);  //hide the dialogue panel initially
    }

    public void StartDialogue()
    {
        index = 0;

        dialoguePanel.SetActive(true);
        StartCoroutine(TypeSentence(sentences[index]));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;

            yield return new WaitForSeconds(0.05f);
        }
    }

    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;

            StartCoroutine(TypeSentence(sentences[index]));
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }

    void Update()
    {
        if (dialoguePanel.activeSelf &&  Input.GetKeyDown(KeyCode.Space))
        {
            NextSentence();
        }
    }
}
