using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Cambiamos a int porque cada corazón es una unidad
    public int maxHealth = 5;
    public int currentHealth;

    // Referencias a otros Managers
    public UIManager uiManager; // Para el Game Over
    public HeartManager heartManager; // ¡NUEVO! Gestor de Corazones

    void Start()
    {
        currentHealth = maxHealth;

        // Inicializa los corazones en la UI
        if (heartManager != null)
        {
            heartManager.SetupHearts(maxHealth);
            heartManager.UpdateHearts(currentHealth);
        }
    }

    // Método para recibir daño (llamado por el enemigo)
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0) currentHealth = 0;

        // 1. Notificar al gestor de corazones sobre el cambio
        if (heartManager != null)
        {
            heartManager.UpdateHearts(currentHealth);
        }

        // 2. Lógica de Muerte
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Lógica para Game Over (asumiendo que ya está en UIManager)
        if (uiManager != null)
        {
            uiManager.ShowGameOverScreen();
        }

        // Desactiva el movimiento, etc.
        Debug.Log("El personaje ha muerto.");
    }
}