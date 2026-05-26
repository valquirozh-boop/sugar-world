using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-100)]
public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject panelPausa;

    public void AbrirPausa()
    {
        if (panelPausa == null) return;
        panelPausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continuar()
    {
        if (panelPausa == null) return;

        panelPausa.SetActive(false);
        Time.timeScale = 1f;
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
