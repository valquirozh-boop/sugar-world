using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [Header("Configuración del Menú")]
    public GameObject panelPausa;

    // Se ejecuta al pulsar el botón de PAUSA en el juego
    public void AbrirPausa()
    {
        if (panelPausa != null)
        {
            panelPausa.SetActive(true);
            Time.timeScale = 0f; // Pausa el tiempo del juego
        }
        else
        {
            Debug.LogError("Error: ¡No has asignado el Panel de Pausa en el Inspector!");
        }
    }

    // Se ejecuta al pulsar el botón de CONTINUAR en el panel
    public void Continuar()
    {
        if (panelPausa != null)
        {
            // 1. Apagar el panel
            panelPausa.SetActive(false);

            // 2. Reanudar el tiempo
            Time.timeScale = 1f; 

            // 3. LA SOLUCIÓN: Buscar al jugador y reactivar su Rigidbody
            // Esto asegura que las físicas vuelvan a calcularse inmediatamente
            PlayerController player = FindFirstObjectByType<PlayerController>();
            if (player != null)
            {
                Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.WakeUp(); 
                }
            }
        }
    }

    // Se ejecuta al pulsar el botón de VOLVER AL MENÚ
    public void IrAlMenu()
    {
        Time.timeScale = 1f; // Siempre reanudar el tiempo antes de cambiar de escena
        SceneManager.LoadScene("menu");
    }
}