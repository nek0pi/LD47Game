using TMPro;
using UnityEngine;

public class DialogueDisplayer : MonoBehaviour
{
    public TextMeshProUGUI TextBox;
    public GameObject MessageBoxObj;
    public static DialogueDisplayer Instance;
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
    }

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
