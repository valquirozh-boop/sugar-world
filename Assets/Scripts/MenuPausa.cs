using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject panelPausa;

    void Start()
    {
        panelPausa.SetActive(false);
    }

    public void AbrirPausa()
    {
        panelPausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continuar()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}