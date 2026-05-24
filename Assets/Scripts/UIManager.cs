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

        // HUD en vivo
        if (txtDonasHUD == null)
            txtDonasHUD = GameObject.Find("ScoreTextDona")?.GetComponent<TextMeshProUGUI>();
        if (txtPastelHUD == null)
            txtPastelHUD = GameObject.Find("ScoreTextPastel")?.GetComponent<TextMeshProUGUI>();
        if (txtTotalHUD == null)
            txtTotalHUD = GameObject.Find("PuntuacionHUD")?.GetComponent<TextMeshProUGUI>();

        // Panel Victoria — busca dentro del panel aunque esté inactivo
        if (txtDonas == null)
            txtDonas = BuscarEnHijos(panelVictoria, "TxtDonas");
        if (txtPasteles == null)
            txtPasteles = BuscarEnHijos(panelVictoria, "TxtPasteles");
        if (txtPuntuacionFinal == null)
            txtPuntuacionFinal = BuscarEnHijos(panelVictoria, "PuntuaciónTotal");
    }

    TextMeshProUGUI BuscarEnHijos(GameObject padre, string nombre)
    {
        if (padre == null) return null;
        foreach (Transform hijo in padre.GetComponentsInChildren<Transform>(true))
        {
            if (hijo.name == nombre)
                return hijo.GetComponent<TextMeshProUGUI>();
        }
        return null;
    }

    public void ActualizarHUD(int donas, int pasteles, int total)
    {
        if (txtDonasHUD != null)  txtDonasHUD.text  = donas + "/30";
        if (txtPastelHUD != null) txtPastelHUD.text = pasteles + "/30";
        if (txtTotalHUD != null)  txtTotalHUD.text  = total + "/900";
    }

    public void ShowDerrota()
    {
        if (panelDerrota != null) panelDerrota.SetActive(true);
    }

    public void ShowVictoria()
    {
        if (panelVictoria == null)
        {
            Debug.LogError("panelVictoria es NULL!");
            return;
        }

        panelVictoria.SetActive(true);

        if (ScoreManager.instance == null)
        {
            Debug.LogError("ScoreManager es NULL en ShowVictoria!");
            return;
        }

        int donas    = ScoreManager.instance.donasRecogidas;
        int pasteles = ScoreManager.instance.pastelRecogidos;
        int puntos   = ScoreManager.instance.score;

        Debug.Log("Victoria! donas=" + donas + " pasteles=" + pasteles + " puntos=" + puntos);

        if (txtDonas != null)
            txtDonas.text = donas + "/30";
        else
            Debug.LogError("txtDonas es NULL!");

        if (txtPasteles != null)
            txtPasteles.text = pasteles + "/30";
        else
            Debug.LogError("txtPasteles es NULL!");

        if (txtPuntuacionFinal != null)
            txtPuntuacionFinal.text = puntos + "/900";
        else
            Debug.LogError("txtPuntuacionFinal es NULL!");
    }

    public void Reiniciar() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    public void IrAlMenu()  => SceneManager.LoadScene(0);
}