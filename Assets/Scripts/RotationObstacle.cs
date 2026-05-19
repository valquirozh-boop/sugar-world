using UnityEngine;

public class RotacionOscilante : MonoBehaviour
{
    public float anguloMaximo = 45f;
    public float velocidad = 3f;

    private Quaternion rotacionInicial;

    void Start()
    {
        rotacionInicial = transform.rotation;
    }

    void Update()
    {
        // En 2D, los objetos giran en el eje Z (el que apunta hacia ti)
        float angulo = Mathf.Sin(Time.time * velocidad) * anguloMaximo;
        transform.rotation = rotacionInicial * Quaternion.Euler(0, 0, angulo);
    }
}
