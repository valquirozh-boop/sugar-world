using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GestorJuego : MonoBehaviour
{
    // Singleton para acceder desde cualquier objeto
    public static GestorJuego instance;

    // Textos del HUD
    public TextMeshProUGUI textDonas;
    public TextMeshProUGUI textPasteles;
    public TextMeshProUGUI scoreText;

    // Panel de Victoria (para mostrar el resumen)
    public TextMeshProUGUI textoResumenVictoria;

    // Variables de estado
    private int donasRecogidas = 0;
    private int pastelRecogidos = 0;
    private int score = 0;

    private void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
    }

    void Start()
    {
        // Inicialización limpia
        ActualizarUI();
    }

    // Método para sumar puntos
    public void AddPoints(int points)
    {
        score += points;
        ActualizarUI();
    }

    // Método llamado al recoger una dona
    public void RecogerDona()
    {
        donasRecogidas++;
        AddPoints(10); // Cada dona vale 10
        ActualizarUI();
    }

    // Método llamado al recoger un pastel
    public void RecogerPastel()
    {
        pastelRecogidos++;
        AddPoints(20); // Cada pastel vale 20
        ActualizarUI();
    }

    void ActualizarUI()
    {
        if (textDonas != null) textDonas.text = "Donas: " + donasRecogidas + "/30";
        if (textPasteles != null) textPasteles.text = "Pasteles: " + pastelRecogidos + "/30";
        if (scoreText != null) scoreText.text = "Puntos: " + score;
    }

    // Método para mostrar resumen al ganar
    public void MostrarVictoria()
    {
        if (textoResumenVictoria != null)
        {
            textoResumenVictoria.text = "¡Nivel completado!\nDonas: " + donasRecogidas + "/30\nPasteles: " + pastelRecogidos + "/30\nPuntaje Final: " + score;
        }
    }
}