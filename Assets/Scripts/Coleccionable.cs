using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    // Marca esta casilla en el Inspector de Unity si el objeto es un pastel
    public bool esPastel; 

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Asegúrate de que el objeto que toca sea el jugador
        if (collision.CompareTag("Player"))
        {
            // Llama al GestorJuego usando la instancia Singleton
            if (esPastel)
            {
                GestorJuego.instance.RecogerPastel();
            }
            else
            {
                GestorJuego.instance.RecogerDona();
            }
            
            // Destruye el objeto de la escena
            Destroy(gameObject);
        }
    }
}
