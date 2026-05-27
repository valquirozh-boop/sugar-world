using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int donasRecogidas = 0;
    public int pastelRecogidos = 0;
    public int score = 0;
    public int totalDonas = 0;
    public int totalPasteles = 0;
    public int puntuacionMaxima = 0;

    [Header("Audio")]
    [SerializeField] private AudioClip collectDonaClip;
    [SerializeField] private AudioClip collectPastelClip;
    [SerializeField] [Range(0f, 1f)] private float collectVolume = 0.7f;

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f;
    }

    void Start()
    {
        ContarColeccionablesEnEscena();
        ActualizarUI();
    }

    private void ContarColeccionablesEnEscena()
    {
        totalDonas = 0;
        totalPasteles = 0;

        foreach (var c in FindObjectsByType<Collectible>(FindObjectsSortMode.None))
        {
            if (c.tipo == Collectible.TipoColeccionable.Dona)
                totalDonas++;
            else if (c.tipo == Collectible.TipoColeccionable.Pastel)
                totalPasteles++;
        }

        puntuacionMaxima = totalDonas * 10 + totalPasteles * 20;
    }

    public void RecogerDona()
    {
        donasRecogidas++;
        score += 10;
        PlayCollectSound(collectDonaClip);
        ActualizarUI();
    }

    public void RecogerPastel()
    {
        pastelRecogidos++;
        score += 20;
        PlayCollectSound(collectPastelClip);
        ActualizarUI();
    }

    private void PlayCollectSound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
            audioSource.PlayOneShot(clip, collectVolume);
    }

    void ActualizarUI()
    {
        if (UIManager.instance == null)
        {
            Debug.LogError("UIManager.instance es NULL!");
            return;
        }
        UIManager.instance.ActualizarHUD(donasRecogidas, pastelRecogidos, score);
    }

    public int GetScore() => score;
}