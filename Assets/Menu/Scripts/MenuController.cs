using UnityEngine;
using UnityEngine.SceneManagement; // Para manejar la carga de escenas
using UnityEngine.UI;  // Para trabajar con los UI buttons

public class MenuController : MonoBehaviour
{
    // --- IMPORTANTE: Cambia los nombres de las escenas si son diferentes ---
    [Header("Nombres de Escenas")]
    public string nivelPrincipal = "Nivel1";
    public string opcionesScene = "Opciones";
    public string creditosScene = "Creditos"; // Nueva escena de Créditos

    // Método para el botón "Jugar"
    public void OnPlayButtonClicked()
    {
        // Carga la escena principal
        SceneManager.LoadScene(nivelPrincipal);
    }

    // Método para el botón "Opciones"
    public void OnOptionsButtonClicked()
    {
        // Carga la escena de opciones
        SceneManager.LoadScene(opcionesScene);
        Debug.Log("Cargando escena de Opciones: " + opcionesScene);
    }

    // Método para el botón "Créditos" (CORREGIDO)
    public void OnCreditsButtonClicked()
    {
        // Carga la escena de créditos
        SceneManager.LoadScene(creditosScene);
        Debug.Log("Cargando escena de Créditos: " + creditosScene);
    }

    // Método para el botón "Salir"
    public void OnExitButtonClicked()
    {
        // Cierra la aplicación (solo funciona en compilaciones)
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }
}