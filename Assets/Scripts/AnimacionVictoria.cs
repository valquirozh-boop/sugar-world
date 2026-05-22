using UnityEngine;
using UnityEngine.UI;

public class AnimacionVictoria : MonoBehaviour
{
    public Sprite[] frames;
    public float velocidad = 0.15f;

    private Image imagen;
    private int frameActual = 0;
    private float timer;

    void Start()
    {
        imagen = GetComponent<Image>();
    }

    void Update()
    {
        timer += Time.unscaledDeltaTime;
        if (timer >= velocidad)
        {
            timer = 0f;
            frameActual = (frameActual + 1) % frames.Length;
            imagen.sprite = frames[frameActual];
        }
    }
}