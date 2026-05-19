using System.Collections;
using UnityEngine;

public class AlgodonEsfumable : MonoBehaviour
{
    [Header("Configuración")]
    [Tooltip("Tiempo que el jugador puede estar encima antes de empezar a esfumarse")]
    [SerializeField] private float tiempoEspera = 5f;

    [Tooltip("Qué tan rápido se desvanece (valores más altos lo hacen más rápido)")]
    [SerializeField] private float velocidadDesvanecer = 1.5f;

    private SpriteRenderer spriteRenderer;
    private Collider2D colisionador;
    private bool yaSeActivo = false;

    private void Start()
    {
        // Obtenemos los componentes del algodón automáticamente
        spriteRenderer = GetComponent<SpriteRenderer>();
        colisionador = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si lo que toca el algodón tiene el Tag "Player" y no se ha activado antes
        if (collision.gameObject.CompareTag("Player") && !yaSeActivo)
        {
            StartCoroutine(EfectoEsfumarse());
        }
    }

    private IEnumerator EfectoEsfumarse()
    {
        yaSeActivo = true;

        // 1. Espera los 5 segundos en los que el jugador está encima
        yield return new WaitForSeconds(tiempoEspera);

        // 2. Quitamos la colisión para que el jugador empiece a caer a través de él
        if (colisionador != null)
        {
            colisionador.enabled = false;
        }

        // 3. Efecto visual: Reducir la opacidad (Alpha) poco a poco hasta que sea 0
        Color colorActual = spriteRenderer.color;

        while (colorActual.a > 0f)
        {
            // Restamos transparencia con el paso del tiempo
            colorActual.a -= velocidadDesvanecer * Time.deltaTime;
            spriteRenderer.color = colorActual;
            
            // Espera al siguiente frame antes de continuar el bucle
            yield return null; 
        }

        // 4. Cuando ya es totalmente invisible, desactivamos el objeto por completo
        gameObject.SetActive(false);
    }
}