using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private Text scoreText;

    public TextMeshProUGUI textDonas;
    public TextMeshProUGUI textPasteles;

    private int score;
    public int donasRecogidas = 0;
    public int pastelRecogidos = 0;
    private int totalDonas = 30;
    private int totalPasteles = 30;

    private void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
    }

    void Start()
    {
        if (textDonas != null)
            textDonas.text = "Donas: 0/30";
        if (textPasteles != null)
            textPasteles.text = "Pasteles: 0/30";
        if (scoreText != null)
            scoreText.text = "Puntos: 0";
    }

    public void AddPoints(int points)
    {
        score += points;
        if (scoreText != null)
            scoreText.text = "Puntos: " + score;
    }

    public void RecogerDona()
    {
        donasRecogidas++;
        if (textDonas != null)
            textDonas.text = "Donas: " + donasRecogidas + "/30";
    }

    public void RecogerPastel()
    {
        pastelRecogidos++;
        if (textPasteles != null)
            textPasteles.text = "Pasteles: " + pastelRecogidos + "/30";
    }

    public int GetScore() => score;
}