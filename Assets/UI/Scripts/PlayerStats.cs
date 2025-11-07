using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    // Nueva Referencia: Necesitamos el UIManager para que muestre el Game Over
    public UIManager uiManager; // ¡Asignar en el Inspector!

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Método para recibir daño (ya existente o similar)
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        // La vida no puede ser negativa
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        // Lógica de Muerte
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // 1. Evita que la función Die() se llame múltiples veces
        if (uiManager.IsGameOver) return;

        // 2. Notifica al UIManager que el juego ha terminado
        uiManager.ShowGameOverScreen();

        // 3. Desactiva o congela el movimiento del personaje
        // Puedes desactivar este script o tu script de movimiento.
        // Ejemplo: GetComponent<PlayerMovement>().enabled = false;

        // 4. (Opcional) Congela la animación del personaje o cambia a un sprite de "muerto"
        Debug.Log("El personaje ha muerto. GAME OVER.");
    }
}