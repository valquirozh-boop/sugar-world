using UnityEngine;

public class PanelInstrucciones : MonoBehaviour
{
    public GameObject panelInstrucciones;

    void Start()
    {
        Time.timeScale = 0f;
        panelInstrucciones.SetActive(true);
    }

    public void CerrarInstrucciones()
    {
        panelInstrucciones.SetActive(false);
        Time.timeScale = 1f;
    }
}