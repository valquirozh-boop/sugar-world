using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 4f;
    [SerializeField] private Vector2 offset = new Vector2(1.5f, 1.5f);

    [Header("Limites (opcional, dejar en 0 para ignorar)")]
    [SerializeField] private float minX = 0f;
    [SerializeField] private float maxX = 0f;
    [SerializeField] private float minY = 0f;
    [SerializeField] private float maxY = 0f;

    private void LateUpdate()
    {
        if (target == null) return;

        float desiredX = target.position.x + offset.x;
        float desiredY = target.position.y + offset.y;

        if (maxX > minX) desiredX = Mathf.Clamp(desiredX, minX, maxX);
        if (maxY > minY) desiredY = Mathf.Clamp(desiredY, minY, maxY);

        Vector3 desired = new Vector3(desiredX, desiredY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, desired, smoothSpeed * Time.deltaTime);
    }
}
