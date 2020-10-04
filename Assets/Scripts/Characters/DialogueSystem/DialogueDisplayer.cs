using TMPro;
using UnityEngine;

public class DialogueDisplayer : MonoBehaviour
{
    public TextMeshProUGUI TextBox;
    public GameObject MessageBoxObj;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (MessageBoxObj.activeSelf)
                HideMessage();
        }
    }
    public void DisplayMessage(string message)
    {
        MessageBoxObj.SetActive(true);
        TextBox.text = message;
    }

    public void HideMessage()
    {
        MessageBoxObj.SetActive(false);
    }
}
