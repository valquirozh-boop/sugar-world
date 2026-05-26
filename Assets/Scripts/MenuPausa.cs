using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject panelPausa;

    private void Awake()
    {
        if (panelPausa == null)
            panelPausa = BuscarEnEscena("PanelPausa");
    }

    private void Start()
    {
        if (panelPausa != null)
            panelPausa.SetActive(false);
    }

    private static GameObject BuscarEnEscena(string nombre)
    {
        foreach (var root in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            foreach (var t in root.GetComponentsInChildren<Transform>(true))
            {
                if (t.name == nombre)
                    return t.gameObject;
            }
        }
        return null;
    }

    public void AbrirPausa()
    {
        if (panelPausa == null)
            panelPausa = BuscarEnEscena("PanelPausa");
        if (panelPausa == null) return;

        panelPausa.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continuar()
    {
        if (panelPausa == null) return;

        panelPausa.SetActive(false);
        Time.timeScale = 1f;

        var player = FindFirstObjectByType<PlayerController>();
        if (player != null)
        {
            var rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.WakeUp();
        }
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
