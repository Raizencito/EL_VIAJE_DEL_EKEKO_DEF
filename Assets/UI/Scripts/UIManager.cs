using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para reiniciar o volver al menú
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // 1. Referencia al Panel de Game Over
    public GameObject gameOverPanel; // Panel que contiene el texto y botones de Game Over

    // Bandera para evitar llamadas repetidas
    public bool IsGameOver { get; private set; } = false;

    void Start()
    {
        // Asegúrate de que el panel esté oculto al inicio
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    // Método principal llamado desde PlayerStats.cs
    public void ShowGameOverScreen()
    {
        // 1. Marcar el juego como terminado
        IsGameOver = true;

        // 2. Muestra el panel de Game Over
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        // 3. Detiene todo movimiento y lógica del juego (pausa total)
        Time.timeScale = 0f;

        // Opcional: Bloquea las barras de vida y otros elementos de la UI
    }

    // Método para el botón "Reiniciar"
    public void RestartGame()
    {
        // 1. Asegúrate de reanudar el tiempo antes de cargar la escena
        Time.timeScale = 1f;

        // 2. Carga la escena actual (o el nivel 1)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Método para el botón "Menú Principal"
    public void LoadMainMenu(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName); // Por ejemplo: "MainMenu"
    }
}