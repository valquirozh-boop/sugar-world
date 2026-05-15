using UnityEngine;

public class SunEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    private Transform player;
    private bool stopped = false;

    private void Start()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) player = p.transform;
    }

    private void Update()
    {
        if (player == null || stopped) return;
        Vector2 dir = ((Vector2)player.position - (Vector2)transform.position).normalized;
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var pc = other.GetComponent<PlayerController>();
        if (pc == null) return;
        stopped = true;
        pc.Defeat();
    }
}
