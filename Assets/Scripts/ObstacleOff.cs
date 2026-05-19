using System.Collections;
using UnityEngine;

public class AlgodonEsfumable : MonoBehaviour
{
    [Header("Configuración de Desaparición")]
    [SerializeField] private float tiempoEspera = 5f;
    [SerializeField] private float velocidadDesvanecer = 1.5f;

    [Header("Configuración de Reaparición")]
    [SerializeField] private bool debeReaparecer = true;
    [SerializeField] private float tiempoParaReaparecer = 3f;

    private SpriteRenderer spriteRenderer;
    private Collider2D colisionador;
    private bool yaSeActivo = false;
    private Color colorOriginal;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colisionador = GetComponent<Collider2D>();
        
        if (spriteRenderer != null)
        {
            colorOriginal = spriteRenderer.color;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !yaSeActivo)
        {
            StartCoroutine(CicloAlgodon());
        }
    }

    private IEnumerator CicloAlgodon()
    {
        yaSeActivo = true;

        yield return new WaitForSeconds(tiempoEspera);

        if (colisionador != null)
        {
            colisionador.enabled = false;
        }

        Color colorActual = spriteRenderer.color;
        while (colorActual.a > 0f)
        {
            colorActual.a -= velocidadDesvanecer * Time.deltaTime;
            spriteRenderer.color = colorActual;
            yield return null; 
        }

        colorActual.a = 0f;
        spriteRenderer.color = colorActual;

        if (debeReaparecer)
        {
            yield return new WaitForSeconds(tiempoParaReaparecer);

            spriteRenderer.color = colorOriginal;

            if (colisionador != null)
            {
                colisionador.enabled = true;
            }

            yaSeActivo = false;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
