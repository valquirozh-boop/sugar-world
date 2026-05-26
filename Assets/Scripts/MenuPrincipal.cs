using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject panelCreditos;
    public GameObject panelConfig;
    public GameObject panelInstrucciones;
    public GameObject contenedorMenu;

    void Start()
    {
        Time.timeScale = 1f;
        if (panelCreditos != null) panelCreditos.SetActive(false);
        if (panelConfig != null) panelConfig.SetActive(false);
        if (panelInstrucciones != null) panelInstrucciones.SetActive(false);
    }

    public void AbrirInstrucciones()
    {
        if (contenedorMenu != null) contenedorMenu.SetActive(false);
        if (panelInstrucciones != null) panelInstrucciones.SetActive(true);
    }

    public void BotonJugar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Nivel_main");
    }

    public void AbrirCreditos() { panelCreditos.SetActive(true); }
    public void CerrarCreditos() { panelCreditos.SetActive(false); }
    public void AbrirConfig() { panelConfig.SetActive(true); }
    public void CerrarConfig() { panelConfig.SetActive(false); }

    public void BotonSalir()
    {
        Debug.Log("El jugador ha salido del juego");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}