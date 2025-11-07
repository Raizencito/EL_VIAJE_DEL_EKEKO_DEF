using UnityEngine;
using UnityEngine.EventSystems; // Necesario para la detección de clics fuera de la UI

public class PanelManagerIndividual : MonoBehaviour
{
    // Variables públicas para arrastrar los Paneles (GameObjects) desde el Inspector.
    public GameObject inventarioPanel;
    public GameObject misionesPanel;

    // Almacena una referencia al panel que está actualmente visible para poder cerrarlo.
    private GameObject panelActivoActual;

    void Start()
    {
        // 1. Aseguramos que ambos paneles estén ocultos al iniciar el juego.
        if (inventarioPanel != null) inventarioPanel.SetActive(false);
        if (misionesPanel != null) misionesPanel.SetActive(false);
        panelActivoActual = null;
    }

    void Update()
    {
        // 2. Detección de ESCAPE para cerrar el panel activo.
        if (panelActivoActual != null && Input.GetKeyDown(KeyCode.Escape))
        {
            CerrarPanelActivo();
            return;
        }

        // 3. Detección de clic fuera del panel para cerrarlo.
        // Solo verificamos si hay un panel activo Y el usuario hace clic izquierdo.
        if (panelActivoActual != null && Input.GetMouseButtonDown(0))
        {
            // EventSystem.current.IsPointerOverGameObject() verifica si el puntero está sobre un elemento de la UI.
            // Si NO está sobre un elemento de la UI (es decir, el clic fue "en el mundo" o fuera del panel):
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                CerrarPanelActivo();
            }
        }
    }

    // Método privado para abrir un panel específico (usado internamente por los Toggle)
    private void AbrirPanel(GameObject panel)
    {
        // Cierra el panel que ya esté abierto (si existe) antes de abrir el nuevo.
        if (panelActivoActual != null)
        {
            CerrarPanelActivo();
        }

        // Abre el nuevo panel y lo registra como el activo.
        panel.SetActive(true);
        panelActivoActual = panel;
    }

    // Método público para ser llamado por el Botón de Inventario.
    // El "Toggle" permite que el mismo botón abra y cierre el panel.
    public void ToggleInventario()
    {
        if (panelActivoActual == inventarioPanel)
        {
            CerrarPanelActivo(); // Si ya está abierto, lo cierra.
        }
        else
        {
            AbrirPanel(inventarioPanel); // Si está cerrado o hay otro abierto, abre Inventario.
        }
    }

    // Método público para ser llamado por el Botón de Misiones.
    public void ToggleMisiones()
    {
        if (panelActivoActual == misionesPanel)
        {
            CerrarPanelActivo(); // Si ya está abierto, lo cierra.
        }
        else
        {
            AbrirPanel(misionesPanel); // Si está cerrado o hay otro abierto, abre Misiones.
        }
    }

    // Método para cerrar el panel que esté abierto.
    public void CerrarPanelActivo()
    {
        if (panelActivoActual != null)
        {
            panelActivoActual.SetActive(false); // Oculta el GameObject (Panel).
            panelActivoActual = null;           // Borra la referencia.
        }
    }
}