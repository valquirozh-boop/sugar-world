using UnityEngine;

public class PanelInstrucciones : MonoBehaviour
{
    public GameObject panelInstrucciones;

    void Awake()
    {
        if (panelInstrucciones == null) return;
        panelInstrucciones.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CerrarInstrucciones()
    {
        Debug.Log("Cerrando instrucciones");
        Time.timeScale = 1f;
        if (panelInstrucciones != null)
            panelInstrucciones.SetActive(false);
        gameObject.SetActive(false);
    }
}