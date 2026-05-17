using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Aquí conectaremos tus paneles de galleta más tarde en el Inspector
    public GameObject panelCreditos;
    public GameObject panelConfig;

    void Start()
    {
        // Esto hace que los paneles empiecen apagados al darle Play
        if(panelCreditos != null) panelCreditos.SetActive(false);
        if(panelConfig != null) panelConfig.SetActive(false);
    }

    public void BotonJugar()
    {
        // IMPORTANTE: Cambia "Nivel1" por el nombre de la escena de tu compañera
        SceneManager.LoadScene("Nivel1"); 
    }

    public void AbrirCreditos()
    {
        panelCreditos.SetActive(true); // Prende el panel
    }

    public void CerrarCreditos()
    {
        panelCreditos.SetActive(false); // Apaga el panel
    }

    public void AbrirConfig()
    {
        panelConfig.SetActive(true);
    }

    public void CerrarConfig()
    {
        panelConfig.SetActive(false);
    }

    public void BotonSalir()
    {
        Debug.Log("Saliendo del juego..."); // Esto sale en la consola de Unity
        Application.Quit();
    }
}