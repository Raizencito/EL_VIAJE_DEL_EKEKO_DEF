using UnityEngine;
using TMPro; // Para trabajar con TextMeshPro
using UnityEngine.UI; // Para trabajar con imágenes
using UnityEngine.SceneManagement; // Para cambiar escenas
using System.Collections; // Necesario para las Corrutinas

public class PrologueManager : MonoBehaviour
{
    // Lista pública para que puedas añadir textos desde el Inspector
    [Header("Texto del prólogo")]
    public string[] prologueTexts;

    // Lista pública para que puedas añadir imágenes desde el Inspector
    [Header("Imágenes del prólogo")]
    public Sprite[] prologueImages;

    // Referencia a los componentes del UI (TextMeshPro y Image)
    public TextMeshProUGUI prologueText; // Texto que se muestra
    public Image prologueImage;         // Imagen que se muestra

    // --- NUEVAS VARIABLES DE CONTROL ---
    [Header("Configuración de Velocidad")]
    public float velocidadEscritura = 0.05f; // Tiempo entre letras para el efecto
    public float tiempoEsperaEntrePasos = 3f; // Tiempo que espera DESPUÉS de escribir un texto

    [Header("Configuración de Escenas")]
    public string nombreEscenaMenu = "Menu"; // Nombre de la escena del menú

    // Para llevar el control del paso actual
    private int currentStep = 0;
    private bool isTyping = false;
    // ------------------------------------

    void Start()
    {
        // Verifica que haya al menos un texto y una imagen
        if (prologueTexts.Length == 0 || prologueImages.Length == 0)
        {
            Debug.LogError("Faltan textos o imágenes en el prólogo.");
            // Si hay un error crítico, cargamos directamente el menú o la escena principal
            SceneManager.LoadScene(nombreEscenaMenu);
            return;
        }

        // Inicia el proceso de mostrar el primer paso
        StartCoroutine(ExecutePrologueSteps());
    }

    void Update()
    {
        // Permite al jugador saltar al siguiente paso presionando una tecla (ej. Espacio)
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (isTyping)
            {
                // Si está escribiendo, salta el efecto (muestra el texto completo)
                SkipTyping();
            }
            else
            {
                // Si terminó de escribir, avanza al siguiente paso inmediatamente
                NextStep();
            }
        }
    }

    IEnumerator ExecutePrologueSteps()
    {
        while (currentStep < prologueTexts.Length)
        {
            // 1. Mostrar la imagen
            if (currentStep < prologueImages.Length)
            {
                prologueImage.sprite = prologueImages[currentStep];
            }

            // 2. Iniciar el efecto de escritura para el texto actual
            yield return StartCoroutine(TypewriterEffect(prologueTexts[currentStep]));

            // 3. Esperar el tiempo configurado después de terminar de escribir
            yield return new WaitForSeconds(tiempoEsperaEntrePasos);

            // 4. Avanzar al siguiente paso
            currentStep++;
        }

        // --- LÓGICA DE FIN DE PRÓLOGO ---
        Debug.Log("Prólogo finalizado. Cargando el menú principal.");
        CargarEscenaMenu();
    }

    IEnumerator TypewriterEffect(string fullText)
    {
        isTyping = true;
        prologueText.text = ""; // Limpia el texto anterior

        // Escribe letra por letra
        foreach (char letra in fullText.ToCharArray())
        {
            prologueText.text += letra;
            yield return new WaitForSeconds(velocidadEscritura);
        }

        isTyping = false;
    }

    // Método para saltar el efecto de escritura inmediatamente
    void SkipTyping()
    {
        // Detiene la corrutina de escritura
        StopCoroutine("TypewriterEffect");

        // Muestra el texto completo
        prologueText.text = prologueTexts[currentStep];
        isTyping = false;
    }

    // Método para pasar al siguiente paso
    void NextStep()
    {
        // Detiene la corrutina principal de ejecución
        StopCoroutine("ExecutePrologueSteps");

        // Avanza el contador y reinicia el proceso
        currentStep++;
        StartCoroutine(ExecutePrologueSteps());
    }

    // Carga la escena de menú principal
    void CargarEscenaMenu()
    {
        SceneManager.LoadScene(nombreEscenaMenu);
    }
}