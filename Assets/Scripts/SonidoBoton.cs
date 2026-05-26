using UnityEngine;

public class SonidoBoton : MonoBehaviour
{
    public AudioClip clipBoton;
    private static AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ReproducirSonido()
    {
        if (clipBoton != null)
            audioSource.PlayOneShot(clipBoton);
    }
}