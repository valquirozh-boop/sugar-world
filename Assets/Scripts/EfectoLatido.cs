using UnityEngine;

public class EfectoLatido : MonoBehaviour
{
    public float velocidad = 2f;
    public float tamanioMinimo = 0.9f;
    public float tamanioMaximo = 1.1f;

    void Update()
    {
        float escala = Mathf.Lerp(tamanioMinimo, tamanioMaximo, 
                       (Mathf.Sin(Time.unscaledTime * velocidad) + 1f) / 2f);
        transform.localScale = new Vector3(escala, escala, 1f);
    }
}