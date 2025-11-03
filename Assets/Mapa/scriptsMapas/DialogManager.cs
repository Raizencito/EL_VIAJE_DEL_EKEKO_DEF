using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogPanel;
    public TMP_Text dialogText;

    [TextArea(3, 5)]
    public string[] dialogLines;

    private int currentLine = 0;
    private bool isActive = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.E))
        {
            ShowNextLine();
        }
    }

    public void StartDialog(string[] newLines)
    {
        if (newLines == null || newLines.Length == 0) return;

        dialogLines = newLines;
        dialogPanel.SetActive(true);
        currentLine = 0;
        dialogText.text = dialogLines[currentLine];
        isActive = true;
    }


    void ShowNextLine()
    {
        currentLine++;
        if (currentLine < dialogLines.Length)
        {
            dialogText.text = dialogLines[currentLine];
        }
        else
        {
            dialogPanel.SetActive(false);
            isActive = false;
        }
    }
}
