using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private Text scoreText;
    private int score;

    private void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
    }

    public void AddPoints(int points)
    {
        score += points;
        if (scoreText != null)
            scoreText.text = "Puntos: " + score;
    }

    public int GetScore() => score;
}
