using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum TipoColeccionable { Dona, Pastel }
    public TipoColeccionable tipo;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (ScoreManager.instance == null)
        {
            Debug.LogError("COLLECTIBLE: ScoreManager es NULL!");
            Destroy(gameObject);
            return;
        }

        if (tipo == TipoColeccionable.Dona)
            ScoreManager.instance.RecogerDona();
        else if (tipo == TipoColeccionable.Pastel)
            ScoreManager.instance.RecogerPastel();

        Destroy(gameObject);
    }
}