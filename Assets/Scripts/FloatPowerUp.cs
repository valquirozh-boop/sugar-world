using UnityEngine;

public class FloatPowerUp : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Awake()
    {
        if (target == null)
        {
            var fridge = GameObject.Find("Nevera");
            if (fridge != null) target = fridge.transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        var pc = other.GetComponent<PlayerController>();
        if (pc == null || target == null) return;
        pc.StartFloat(target);
        Destroy(gameObject);
    }
}
