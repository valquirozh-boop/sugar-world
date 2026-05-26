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
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }

        instance = this;
        ResolverReferencias();
    }

    private void Start()
    {
        if (panelDerrota != null) panelDerrota.SetActive(false);
        if (panelVictoria != null) panelVictoria.SetActive(false);
    }

    private void ResolverReferencias()
    {
        if (panelDerrota == null)
            panelDerrota = BuscarEnEscena("PanelDerrota");
        if (panelVictoria == null)
            panelVictoria = BuscarEnEscena("PanelVictoria");

        if (txtDonasHUD == null)
            txtDonasHUD = BuscarTMP("ScoreTextDona");
        if (txtPastelHUD == null)
            txtPastelHUD = BuscarTMP("ScoreTextPastel");
        if (txtTotalHUD == null)
            txtTotalHUD = BuscarTMP("PuntuacionHUD");

        if (txtDonas == null)
            txtDonas = BuscarTMPEnHijos(panelVictoria, "TxtDonas");
        if (txtPasteles == null)
            txtPasteles = BuscarTMPEnHijos(panelVictoria, "TxtPasteles");
        if (txtPuntuacionFinal == null)
            txtPuntuacionFinal = BuscarTMPEnHijos(panelVictoria, "PuntuaciónTotal");
    }

    static GameObject BuscarEnEscena(string nombre)
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

    static TextMeshProUGUI BuscarTMP(string nombre)
    {
        var go = BuscarEnEscena(nombre);
        return go != null ? go.GetComponent<TextMeshProUGUI>() : null;
    }

    static TextMeshProUGUI BuscarTMPEnHijos(GameObject padre, string nombre)
    {
        if (padre == null) return null;
        foreach (var t in padre.GetComponentsInChildren<Transform>(true))
        {
            if (t.name == nombre)
                return t.GetComponent<TextMeshProUGUI>();
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
        ResolverReferencias();
        Time.timeScale = 0f;
        if (panelVictoria != null) panelVictoria.SetActive(false);
        if (panelDerrota != null) panelDerrota.SetActive(true);
    }

    public void ShowVictoria()
    {
        ResolverReferencias();
        Time.timeScale = 0f;
        if (panelDerrota != null) panelDerrota.SetActive(false);
        if (panelVictoria == null) return;

        panelVictoria.SetActive(true);

        if (ScoreManager.instance == null) return;

        int donas    = ScoreManager.instance.donasRecogidas;
        int pasteles = ScoreManager.instance.pastelRecogidos;
        int puntos   = ScoreManager.instance.score;

        if (txtDonas != null)
            txtDonas.text = donas + "/30";
        if (txtPasteles != null)
            txtPasteles.text = pasteles + "/30";
        if (txtPuntuacionFinal != null)
            txtPuntuacionFinal.text = puntos + "/900";
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
