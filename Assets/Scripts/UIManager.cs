using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[DefaultExecutionOrder(-100)]
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject panelDerrota;
    [SerializeField] private GameObject panelVictoria;

    [Header("Textos Panel Victoria")]
    [SerializeField] private TextMeshProUGUI txtDonas;
    [SerializeField] private TextMeshProUGUI txtPasteles;
    [SerializeField] private TextMeshProUGUI txtPuntuacionFinal;

    [Header("Textos HUD en vivo")]
    [SerializeField] private TextMeshProUGUI txtDonasHUD;
    [SerializeField] private TextMeshProUGUI txtPastelHUD;
    [SerializeField] private TextMeshProUGUI txtTotalHUD;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    private void Start()
    {
        if (panelDerrota != null) panelDerrota.SetActive(false);
        if (panelVictoria != null) panelVictoria.SetActive(false);
    }

    private void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }

    public void ActualizarHUD(int donas, int pasteles, int total)
    {
        if (txtDonasHUD != null)  txtDonasHUD.text  = donas + "/30";
        if (txtPastelHUD != null) txtPastelHUD.text = pasteles + "/30";
        if (txtTotalHUD != null)  txtTotalHUD.text  = total + "/900";
    }

    public void ShowDerrota()
    {
        Time.timeScale = 0f;
        if (panelVictoria != null) panelVictoria.SetActive(false);
        if (panelDerrota != null) panelDerrota.SetActive(true);
    }

    public void ShowVictoria()
    {
        Time.timeScale = 0f;
        if (panelDerrota != null) panelDerrota.SetActive(false);
        if (panelVictoria == null) return;

        panelVictoria.SetActive(true);

        if (ScoreManager.instance == null) return;

        if (txtDonas != null)
            txtDonas.text = ScoreManager.instance.donasRecogidas + "/30";
        if (txtPasteles != null)
            txtPasteles.text = ScoreManager.instance.pastelRecogidos + "/30";
        if (txtPuntuacionFinal != null)
            txtPuntuacionFinal.text = ScoreManager.instance.score + "/900";
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
