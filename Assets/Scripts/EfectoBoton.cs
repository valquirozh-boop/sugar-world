using UnityEngine;
using UnityEngine.EventSystems;

public class EfectoBoton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public float escalaHover = 1.15f;
    public float escalaPressed = 0.92f;
    public float velocidad = 15f;

    private Vector3 escalaOriginal;
    private Vector3 escalaObjetivo;

    void Start()
    {
        escalaOriginal = transform.localScale;
        escalaObjetivo = escalaOriginal;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            escalaObjetivo,
            Time.unscaledDeltaTime * velocidad
        );
    }

    public void OnPointerEnter(PointerEventData e)
    {
        escalaObjetivo = escalaOriginal * escalaHover;
    }

    public void OnPointerExit(PointerEventData e)
    {
        escalaObjetivo = escalaOriginal;
    }

    public void OnPointerDown(PointerEventData e)
    {
        escalaObjetivo = escalaOriginal * escalaPressed;
    }

    public void OnPointerUp(PointerEventData e)
    {
        escalaObjetivo = escalaOriginal * escalaHover;
    }
}