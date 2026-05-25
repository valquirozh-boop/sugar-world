using UnityEngine;
using UnityEngine.UI;

public class AnimacionHelado : MonoBehaviour
{
    public Sprite helado1;
    public Sprite helado2;
    [Range(0.1f, 5f)]
    public float segundosEntrecambio = 1.5f;

    private Image imagen;
    private float tiempoActual;
    private bool mostrandoPrimero = true;

    void Start()
    {
        imagen = GetComponent<Image>();
        imagen.sprite = helado1;
        tiempoActual = 0f;
    }

    void Update()
    {
        tiempoActual += Time.unscaledDeltaTime;

        if (tiempoActual >= segundosEntrecambio)
        {
            tiempoActual = 0f;
            mostrandoPrimero = !mostrandoPrimero;

            if (mostrandoPrimero)
                imagen.sprite = helado1;
            else
                imagen.sprite = helado2;
        }
    }
}