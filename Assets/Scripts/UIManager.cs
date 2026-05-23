using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject panelDerrota;
    [SerializeField] private GameObject panelVictoria;

    public TextMeshProUGUI txtDonas;
    public TextMeshProUGUI txtPasteles;
    public TextMeshProUGUI txtPuntuacionFinal;

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
        if (panelVictoria != null)
        {
            panelVictoria.SetActive(true);

            if (ScoreManager.instance != null)
            {
                int donas = ScoreManager.instance.donasRecogidas;
                int pasteles = ScoreManager.instance.pastelRecogidos;
                int puntos = ScoreManager.instance.GetScore();

                if (txtDonas != null)
                    txtDonas.text = donas + "/30";
                if (txtPasteles != null)
                    txtPasteles.text = pasteles + "/30";
                if (txtPuntuacionFinal != null)
                    txtPuntuacionFinal.text = "Puntos: " + puntos;
            }
        }
    }

    public void Reiniciar() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    public void IrAlMenu() => SceneManager.LoadScene(0);
}