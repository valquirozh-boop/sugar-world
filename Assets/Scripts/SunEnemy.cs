using UnityEngine;

public class SunEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    private Transform player;

    private void Start()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) player = p.transform;
    }

    private void Update()
    {
        if (player == null) return;
        // persigue al player solo en X, avanza de derecha a izquierda
        float dir = Mathf.Sign(player.position.x - transform.position.x);
        transform.Translate(Vector2.right * dir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var pc = other.GetComponent<PlayerController>();
        if (pc != null) pc.Defeat();
    }
}
