using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject panelPausa;

    public void AbrirPausa()
    {
        // Diagnóstico: si ves esto en la consola, el botón funciona
        Debug.Log("<color=red>¡BOTÓN PULSADO!</color>");

        if (panelPausa != null)
        {
            panelPausa.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogError("El panelPausa no está asignado en el Inspector.");
        }
    }

    public void Continuar()
    {
        if (panelPausa != null)
        {
            panelPausa.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }
}