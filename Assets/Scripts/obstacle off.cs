using System.Collections;
using UnityEngine;

public class ObstaculoDesaparece : MonoBehaviour
{
    [Header("Configuración")]
    [Tooltip("Tiempo en segundos antes de desaparecer")]
    [SerializeField] private float tiempoEspera = 5f; // Cambiado a 5 segundos

    [SerializeField] private string tagJugador = "Player";

    private SpriteRenderer spriteRenderer;
    private bool yaSeActivo = false;

    private void Start()
    {
        // Obtenemos el componente visual para poder hacerlo parpadear
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si es el jugador y si aún no se ha activado
        if (collision.gameObject.CompareTag(tagJugador) && !yaSeActivo)
        {
            StartCoroutine(FaseDesaparecer());
        }
    }

    private IEnumerator FaseDesaparecer()
    {
        yaSeActivo = true;

        // Espera 3 segundos normales
        yield return new WaitForSeconds(tiempoEspera - 2f);

        // Los últimos 2 segundos parpadea para avisar al jugador
        float tiempoParpadeo = 0f;
        while (tiempoParpadeo < 2f)
        {
            // Invierte la visibilidad del sprite
            spriteRenderer.enabled = !spriteRenderer.enabled;
            
            // Espera un instante antes de volver a cambiar (parpadeo rápido)
            yield return new WaitForSeconds(0.15f);
            tiempoParpadeo += 0.15f;
        }

        // Finalmente, desaparece por completo
        gameObject.SetActive(false);
    }
}