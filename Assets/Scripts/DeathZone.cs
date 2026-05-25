using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var pc = other.GetComponent<PlayerController>();
        if (pc != null) pc.Defeat();
    }
}
