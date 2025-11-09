using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class PausaManager : MonoBehaviour
{
    // 1. Variable pública para el objeto del menú de la UI. 
    public GameObject menuPausaUI;

    [Header("Configuración de Escena")]
    // ¡NUEVA LÍNEA! Nombre EXACTO de la escena de tu menú
    public string nombreEscenaMenu = "Menu";

    // 2. Variable para saber si el juego está en pausa.
    public static bool JuegoEnPausa = false;

    void Start()
    {
        // Asegurarse de que el menú está oculto al iniciar el nivel.
        if (menuPausaUI != null)
        {
            menuPausaUI.SetActive(false);
        }

        // Asegurarse de que el tiempo corra normalmente al inicio.
        Time.timeScale = 1f;
        JuegoEnPausa = false;
    }

    void Update()
    {
        // 3. Detectar la pulsación de la tecla ESCAPE
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JuegoEnPausa)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    // Método para reanudar el juego (conecta el botón REANUDAR aquí)
    public void Reanudar()
    {
        menuPausaUI.SetActive(false); // Oculta el menú
        Time.timeScale = 1f;          // Restablece el tiempo normal (1x)
        JuegoEnPausa = false;         // Marca el juego como NO pausado
    }

    // Método para pausar el juego
    void Pausar()
    {
        menuPausaUI.SetActive(true); // Muestra el menú
        Time.timeScale = 0f;         // Detiene el tiempo completamente
        JuegoEnPausa = true;         // Marca el juego como pausado
    }

    // --- ¡NUEVA FUNCIÓN! ---
    // Método para salir del juego y cargar el menú principal
    // (conecta el botón SALIR aquí)
    public void SalirAlMenuPrincipal()
    {
        // 1. Reanudar el tiempo ANTES de cambiar de escena
        Time.timeScale = 1f;

        // 2. Cargar la escena del menú
        SceneManager.LoadScene(nombreEscenaMenu);
        Debug.Log("Saliendo al menú: " + nombreEscenaMenu);
    }

    // El método CargarMenuPrincipal(string nombreEscena) ya no es necesario,
    // pero si lo quieres conservar, puedes usar SalirAlMenuPrincipal(nombreEscenaMenu);
}