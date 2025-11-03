using UnityEngine;
using SuperTiled2Unity; // para leer las propiedades desde Tiled

[RequireComponent(typeof(Collider2D))]
public class StoneTrigger : MonoBehaviour
{
    [Tooltip("ID de la piedra (si no se define, se obtiene de Tiled)")]
    public string stoneId;

    [Tooltip("Referencia visual cuando está activada")]
    public GameObject activeVisual;

    private PuzzleStonesManager manager;
    private bool isActive = false; // activada correctamente
    private bool playerInside = false; // si el jugador está en rango

    void Awake()
    {
        manager = FindObjectOfType<PuzzleStonesManager>();

        // Leer propiedades del mapa (si existen)
        var props = GetComponent<SuperCustomProperties>();
        if (props != null)
        {
            if (string.IsNullOrEmpty(stoneId) && props.TryGetCustomProperty("piedraId", out var v))
                stoneId = v.m_Value.ToString();

            if (props.TryGetCustomProperty("isActive", out var a))
                isActive = a.m_Value.ToString().ToLower() == "true";
        }

        if (manager != null && !string.IsNullOrEmpty(stoneId))
            manager.RegisterStone(stoneId, this);

        SetActiveVisual(isActive);
    }

    void Update()
    {
        // Si el jugador está cerca y presiona E
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            if (!isActive)
            {
                Activate();
            }
        }
    }

    public void Activate()
    {
        isActive = true;
        SetActiveVisual(true);
        if (manager != null)
            manager.StoneActivated(stoneId);

        UIMessage.Instance.ShowMessage("Piedra activada: " + stoneId);

    }

    public void SetActiveVisual(bool active)
    {
        if (activeVisual != null)
            activeVisual.SetActive(active);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            UIMessage.Instance.ShowMessage("Presiona E para activar la piedra");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

}
