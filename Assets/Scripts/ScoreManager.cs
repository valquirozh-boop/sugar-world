using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int donasRecogidas = 0;
    public int pastelRecogidos = 0;
    public int score = 0;

    private void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
    }

    void Start()
    {
        ActualizarUI();
    }

    public void RecogerDona()
    {
        donasRecogidas++;
        score += 10;
        Debug.Log("Dona recogida. Total donas: " + donasRecogidas + " Score: " + score);
        ActualizarUI();
    }

    public void RecogerPastel()
    {
        pastelRecogidos++;
        score += 20;
        Debug.Log("Pastel recogido. Total pasteles: " + pastelRecogidos + " Score: " + score);
        ActualizarUI();
    }

    void ActualizarUI()
    {
        if (UIManager.instance == null)
        {
            Debug.LogError("UIManager.instance es NULL!");
            return;
        }
        UIManager.instance.ActualizarHUD(donasRecogidas, pastelRecogidos, score);
    }

    public int GetScore() => score;
}