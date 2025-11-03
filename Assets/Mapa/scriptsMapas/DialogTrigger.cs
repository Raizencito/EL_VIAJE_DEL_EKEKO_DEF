using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [TextArea(3, 5)]
    public string[] dialogLines;

    private bool playerInRange = false;
    private DialogManager dialogManager;

    void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialogManager.StartDialog(dialogLines);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
