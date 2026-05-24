using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public bool esPastel;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (esPastel)
                ScoreManager.instance.RecogerPastel();
            else
                ScoreManager.instance.RecogerDona();

            Destroy(gameObject);
        }
    }
}