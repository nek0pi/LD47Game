using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    bool isFirstTime = true;
    Queue<string> _sentencesToShow = new Queue<string>();
    string lastMesg;
    public void StartDialogue(int id)
    {
        Dialogue.TextDialogue sentences = SentensesLoader.AllDialogues[id];
        if (isFirstTime)
        {
            //Loads sentences in a queue
            foreach (var sentence in sentences.Sentences)
                _sentencesToShow.Enqueue(sentence);
            lastMesg = sentences.LastSentence;

            DisplayNextSentence();
            isFirstTime = false;
        }
        else
        {
            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        if (_sentencesToShow.Count == 0)
        {
            LoopingMessage();
            return;
        }

        DialogueDisplayer.Instance.DisplayMessage(_sentencesToShow.Dequeue());
    }

    public void LoopingMessage()
    {
        DialogueDisplayer.Instance.DisplayMessage(lastMesg);
    }
}
