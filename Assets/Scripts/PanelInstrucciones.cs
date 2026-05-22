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
        Debug.Log("Cerrando instrucciones");
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}