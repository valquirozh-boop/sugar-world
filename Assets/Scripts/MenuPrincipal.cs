using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Aquí conectaremos tus paneles de galleta en el Inspector
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
        SceneManager.LoadScene("Nivel1");
    }

    public void AbrirCreditos()
    {
        panelCreditos.SetActive(true);
    }

    public void CerrarCreditos()
    {
        panelCreditos.SetActive(false);
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
        Debug.Log("El jugador ha salido");
        Application.Quit();
    }
}