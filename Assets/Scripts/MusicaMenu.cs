using UnityEngine;

public class MusicaMenu : MonoBehaviour
{
    public AudioClip musicaMenu;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicaMenu;
        audioSource.loop = true;
        audioSource.Play();
    }
}