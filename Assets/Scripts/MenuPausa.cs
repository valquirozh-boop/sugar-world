using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject panelPausa;

    public void AbrirPausa()
    {
        if (panelPausa != null)
        {
            panelPausa.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Continuar()
    {
        if (panelPausa != null)
            panelPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }
}