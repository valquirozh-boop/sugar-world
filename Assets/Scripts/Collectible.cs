using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int points = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        ScoreManager.instance?.AddPoints(points);
        Destroy(gameObject);
    }
}
