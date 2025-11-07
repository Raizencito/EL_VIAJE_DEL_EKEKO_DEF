using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar escenas (si el menú lo hace)

public class PausaManager : MonoBehaviour
{
    // 1. Variable pública para el objeto del menú de la UI. 
    // ¡Arrastra el Panel del menú de pausa aquí desde el Inspector!
    public GameObject menuPausaUI;

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

    // Método para reanudar el juego
    public void Reanudar()
    {
        menuPausaUI.SetActive(false); // Oculta el menú
        Time.timeScale = 1f;           // Restablece el tiempo normal (1x)
        JuegoEnPausa = false;          // Marca el juego como NO pausado
    }

    // Método para pausar el juego
    void Pausar()
    {
        menuPausaUI.SetActive(true);  // Muestra el menú
        Time.timeScale = 0f;          // Detiene el tiempo completamente
        JuegoEnPausa = true;           // Marca el juego como pausado
    }

    // Ejemplo de método para un botón de Salir o Volver al Menú Principal
    public void CargarMenuPrincipal(string nombreEscena)
    {
        // Opcional: Reanuda el tiempo antes de cambiar de escena
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreEscena);
    }
}