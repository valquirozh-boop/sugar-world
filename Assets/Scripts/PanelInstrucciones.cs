using UnityEngine;

public class PanelInstrucciones : MonoBehaviour
{
    // Buscamos el panel automáticamente al arrancar
    private GameObject panelInstrucciones; 

    void Start()
    {
        // 1. Busca el panel por nombre (debe llamarse "PanelInstrucciones" en la jerarquía)
        panelInstrucciones = GameObject.Find("PanelInstrucciones");
        
        // 2. Pausa el juego
        Time.timeScale = 0f;
    }

    public void CerrarInstrucciones()
    {
        // 3. Desactiva el panel
        if (panelInstrucciones != null)
        {
            panelInstrucciones.SetActive(false);
        }
        
        // 4. Reanuda el juego
        Time.timeScale = 1f;
        
        Debug.Log("Juego iniciado");
    }
}