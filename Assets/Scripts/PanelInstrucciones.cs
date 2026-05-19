using UnityEngine;

public class PanelInstrucciones : MonoBehaviour
{
    // Esta variable es para que puedas arrastrar el panel en el Inspector si quieres.
    public GameObject panelInstrucciones; 

    void Start()
    {
        // 1. Si no arrastraste el panel en el Inspector, lo buscamos por nombre automáticamente.
        if (panelInstrucciones == null)
        {
            panelInstrucciones = GameObject.Find("PanelInstrucciones");
        }

        // 2. Pausamos el juego al iniciar la escena.
        Time.timeScale = 0f;
    }

    public void CerrarInstrucciones()
    {
        // 3. Imprimimos en consola para verificar que el clic llega al script.
        Debug.Log("Botón presionado: iniciando juego.");

        // 4. Desactivamos el panel visual.
        if (panelInstrucciones != null)
        {
            panelInstrucciones.SetActive(false);
        }
        else
        {
            Debug.LogError("Error: No se encontró el objeto 'PanelInstrucciones'. Asegúrate de que el objeto en la jerarquía se llame exactamente así.");
        }

        // 5. Reanudamos el tiempo para que el juego comience.
        Time.timeScale = 1f;
    }
}