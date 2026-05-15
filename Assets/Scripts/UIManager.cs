using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject panelDerrota;
    [SerializeField] private GameObject panelVictoria;

    private void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
    }

    public void ShowDerrota()
    {
        if (panelDerrota != null) panelDerrota.SetActive(true);
    }

    public void ShowVictoria()
    {
        if (panelVictoria != null) panelVictoria.SetActive(true);
    }

    public void Reiniciar() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    public void IrAlMenu() => SceneManager.LoadScene(0);
}
