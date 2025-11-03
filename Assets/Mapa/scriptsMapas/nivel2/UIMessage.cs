using UnityEngine;
using TMPro;

public class UIMessage : MonoBehaviour
{
    public static UIMessage Instance;

    [SerializeField] private GameObject messagePanel;
    [SerializeField] private TextMeshProUGUI messageText;
    private float timer;
    private bool showing;

    void Awake()
    {
        Instance = this;
        messagePanel.SetActive(false);
    }

    public void ShowMessage(string text, float duration = 2f)
    {
        messageText.text = text;
        messagePanel.SetActive(true);
        showing = true;
        timer = duration;
    }

    void Update()
    {
        if (showing)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                messagePanel.SetActive(false);
                showing = false;
            }
        }
    }
}
