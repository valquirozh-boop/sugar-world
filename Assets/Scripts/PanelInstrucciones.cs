using UnityEngine;
using UnityEngine.SceneManagement;

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

    // Asigna este método al botón "Comenzar"
    public void BotonComenzar()
    {
        Debug.Log("Cargando Nivel_main...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Nivel_main");
    }
}