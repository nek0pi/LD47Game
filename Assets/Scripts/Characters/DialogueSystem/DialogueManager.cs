using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class DialogueManager : MonoBehaviour
{
    private Queue<string> _sentencesToShow = new Queue<string>();
    private string lastMes;
    public static DialogueManager Instance;
    public DialogueDisplayer DialogueDisplayer;

    private void Start()
    {
        //Make sure it's only one (singleton)
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        if(DialogueDisplayer == null)
            DialogueDisplayer = GetComponent<DialogueDisplayer>();
    }

    public void StartDialogue(string[] dialogueText, string lastmessage)
    {
        _sentencesToShow.Clear();

        foreach (var text in dialogueText)
        {
            _sentencesToShow.Enqueue(text);
        }
        lastMes = lastmessage;

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(_sentencesToShow.Count == 0) 
        {  
            LoopingMessage();
            return;
        }

        //Todo Show some text on a dialogue bar
        DialogueDisplayer.DisplayMessage(_sentencesToShow.Dequeue());
    }

    public void LoopingMessage()
    {
        DialogueDisplayer.DisplayMessage(lastMes);
    }
}
