using UnityEngine;

public class PanelInstrucciones : MonoBehaviour
{
    // Esta es la variable que verás en el Inspector para arrastrar el panel
    public GameObject panelInstrucciones; 

    void Start()
    {
        // Al iniciar el juego, forzamos la pausa y mostramos el panel
        Time.timeScale = 0f;
        panelInstrucciones.SetActive(true);
    }

    public void CerrarInstrucciones()
    {
        // Al pulsar el botón, ocultamos el panel y reanudamos el tiempo
        panelInstrucciones.SetActive(false);
        Time.timeScale = 1f;
    }
}