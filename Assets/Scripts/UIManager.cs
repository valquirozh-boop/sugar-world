using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject panelDerrota;
    [SerializeField] private GameObject panelVictoria;

    [Header("Textos Panel Victoria")]
    public TextMeshProUGUI txtDonas;
    public TextMeshProUGUI txtPasteles;
    public TextMeshProUGUI txtPuntuacionFinal;

    [Header("Textos HUD en vivo")]
    public TextMeshProUGUI txtDonasHUD;
    public TextMeshProUGUI txtPastelHUD;
    public TextMeshProUGUI txtTotalHUD;

    private void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
    }

    public void ActualizarHUD(int donas, int pasteles, int total)
    {
        if (txtDonasHUD != null)  txtDonasHUD.text  = donas    + "/30";
        if (txtPastelHUD != null) txtPastelHUD.text = pasteles + "/30";
        if (txtTotalHUD != null)  txtTotalHUD.text  = total.ToString();
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
                int donas    = ScoreManager.instance.donasRecogidas;
                int pasteles = ScoreManager.instance.pastelRecogidos;
                int puntos   = ScoreManager.instance.score;

                if (txtDonas != null)         txtDonas.text         = donas    + "/30";
                if (txtPasteles != null)      txtPasteles.text      = pasteles + "/30";
                if (txtPuntuacionFinal != null) txtPuntuacionFinal.text = puntos + "/900";
            }
        }
    }

    public void Reiniciar() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    public void IrAlMenu()  => SceneManager.LoadScene(0);
}