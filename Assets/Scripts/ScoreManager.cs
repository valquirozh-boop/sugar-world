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
        ActualizarUI();
    }

    public void RecogerPastel()
    {
        pastelRecogidos++;
        score += 20;
        ActualizarUI();
    }

    void ActualizarUI()
    {
        if (UIManager.instance != null)
            UIManager.instance.ActualizarHUD(donasRecogidas, pastelRecogidos, score);
    }

    public int GetScore() => score;
}