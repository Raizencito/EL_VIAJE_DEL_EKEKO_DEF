using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HeartManager : MonoBehaviour
{
    [Header("Sprites de Corazones")]
    public Sprite fullHeartSprite;     // Corazón lleno (rojo)
    public Sprite emptyHeartSprite;    // Corazón vacío (sin vida)

    [Header("Configuración")]
    public GameObject heartPrefab;     // Prefab del objeto que contendrá la imagen del corazón

    // Lista para almacenar todas las imágenes de corazones creadas
    private List<Image> hearts = new List<Image>();

    // Inicializa la UI de corazones
    public void SetupHearts(int maxHealth)
    {
        // Limpiamos corazones anteriores por si acaso
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        hearts.Clear();

        // Creamos la cantidad de corazones definida por maxHealth
        for (int i = 0; i < maxHealth; i++)
        {
            // Creamos una instancia del prefab del corazón
            GameObject newHeart = Instantiate(heartPrefab, transform);

            // Obtenemos el componente Image y lo añadimos a nuestra lista
            Image heartImage = newHeart.GetComponent<Image>();
            if (heartImage != null)
            {
                hearts.Add(heartImage);
            }
            else
            {
                Debug.LogError("El prefab del corazón debe tener un componente Image.");
            }
        }
    }

    // Actualiza la visualización de los corazones
    public void UpdateHearts(int currentHealth)
    {
        // Recorremos todos los corazones creados
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < currentHealth)
            {
                // Si el índice es menor que la vida actual, es un corazón lleno
                hearts[i].sprite = fullHeartSprite;
            }
            else
            {
                // Si el índice es mayor o igual, es un corazón vacío
                hearts[i].sprite = emptyHeartSprite;
            }
        }
    }
}