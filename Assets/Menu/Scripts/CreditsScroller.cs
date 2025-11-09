using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScroller : MonoBehaviour
{
    [Header("Configuración de Duración")]
    // Ahora esta variable es el tiempo que el texto permanece visible.
    public float tiempoTotal = 30f;

    [Header("Escena de Destino")]
    public string escenaMenu = "Menu"; // Nombre de la escena a la que regresar

    // Eliminamos la variable 'rectTransform' y 'tiempoInicio' ya que no hay desplazamiento.

    void Start()
    {
        // El texto debe estar posicionado correctamente en la escena para ser visible.

        // Iniciamos la cuenta regresiva para el cambio de escena.
        Invoke("EndCredits", tiempoTotal);
    }

    void Update()
    {
        // NO HAY CÓDIGO DE DESPLAZAMIENTO AQUÍ.

        // Permite saltar los créditos con una tecla (sigue funcionando)
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space))
        {
            EndCredits();
        }
    }

    // Método llamado al finalizar el tiempo o al presionar ESC/Espacio
    public void EndCredits()
    {
        // Cancelamos la llamada pendiente para evitar doble carga
        CancelInvoke("EndCredits");

        Debug.Log("Créditos finalizados. Cargando menú principal.");
        SceneManager.LoadScene(escenaMenu);
    }
}