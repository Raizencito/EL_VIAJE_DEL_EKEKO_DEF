using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    [Header("Configuración del Enemigo")]
    public float velocidadMovimiento = 3f;
    public float rangoDePersecucion = 10f; // Distancia a la que el enemigo comienza a perseguir
    public float rangoDeAtaque = 1.5f;     // Distancia a la que el enemigo se detiene para "atacar"

    // Referencia al jugador (¡Fundamental!)
    private Transform target;

    void Start()
    {
        // Intentamos encontrar el GameObject del jugador por su etiqueta
        // Asegúrate de que tu personaje principal tenga la etiqueta "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            target = playerObject.transform;
        }
        else
        {
            Debug.LogError("¡ERROR! Objeto con etiqueta 'Player' no encontrado. La persecución no funcionará.");
        }
    }

    void Update()
    {   
        // Verificamos que el objetivo (jugador) exista
        if (target == null) return;

        // 1. Calcular la distancia hacia el jugador
        float distanciaAlTarget = Vector3.Distance(transform.position, target.position);

        // 2. Lógica de Persecución
        if (distanciaAlTarget <= rangoDePersecucion)
        {
            // Perseguir: Solo si está fuera del rango de ataque
            if (distanciaAlTarget > rangoDeAtaque)
            {
                Perseguir();
            }
            // Atacar: Si ya está en rango, se detiene
            else
            {
                // Aquí va la lógica de ataque (por ahora, solo detenemos el movimiento)
                Debug.Log(gameObject.name + " está en rango de ataque.");
            }
        }
    }

    void Perseguir()
    {
        // La dirección hacia el jugador
        Vector3 direccion = (target.position - transform.position).normalized;

        // Mover el enemigo hacia el jugador
        // Usamos Time.deltaTime para que el movimiento sea independiente de los frames
        transform.position += direccion * velocidadMovimiento * Time.deltaTime;

        // Opcional: Hacer que el enemigo mire al jugador (solo en el plano Z, si es un juego 2D)
        // Nota: Esto puede variar dependiendo de la orientación de tus sprites.
        // transform.up = direccion;
    }
}