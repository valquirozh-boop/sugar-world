using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum TipoColeccionable { Dona, Pastel }
    public TipoColeccionable tipo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (tipo == TipoColeccionable.Dona)
        {
            ScoreManager.instance?.AddPoints(10);
            ScoreManager.instance?.RecogerDona();
        }
        else if (tipo == TipoColeccionable.Pastel)
        {
            ScoreManager.instance?.AddPoints(20);
            ScoreManager.instance?.RecogerPastel();
        }

        Destroy(gameObject);
    }
}