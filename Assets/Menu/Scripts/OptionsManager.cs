using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // Necesario para la carga de escenas

public class OptionsManager : MonoBehaviour
{
    [Header("Referencias UI")]
    public Slider volumeSlider;
    public TMP_Dropdown qualityDropdown;

    [Header("Configuración de Escena")]
    // IMPORTANTE: Este nombre debe coincidir con el nombre de la escena de destino (ej. "MenuPrincipal")
    public string escenaParaRegresar = "Menu";

    void Start()
    {
        // ... (Lógica para inicializar Sliders y Dropdowns, como en la respuesta anterior)
        CargarOpcionesDeCalidad();
        volumeSlider.value = AudioListener.volume;
    }

    // Llenar el Dropdown con los niveles de calidad de Unity
    void CargarOpcionesDeCalidad()
    {
        qualityDropdown.ClearOptions();
        string[] names = QualitySettings.names;
        System.Collections.Generic.List<string> options = new System.Collections.Generic.List<string>(names);
        qualityDropdown.AddOptions(options);
        qualityDropdown.value = QualitySettings.GetQualityLevel();
    }

    // MÉTODO 1: Control de Volumen (Llamado por el Slider)
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    // MÉTODO 2: Control de Calidad Gráfica (Llamado por el Dropdown)
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // MÉTODO 3: Regresar a la escena anterior (Llamado por el Botón)
    // Este método destruye la escena de opciones y carga la escena de destino.
    public void Regresar()
    {
        // Se puede guardar la configuración aquí (ej. usando PlayerPrefs)

        // Cargar la escena de destino. ¡Aquí es donde ocurre el cambio de escena!
        SceneManager.LoadScene(escenaParaRegresar);
    }
}