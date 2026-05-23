using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public GameObject panelPausa; 

    public void AbrirPausa()
    {
        Debug.Log("Intentando pausar..."); 
        
        if (panelPausa != null)
        {
            panelPausa.SetActive(true);
            Time.timeScale = 0f; 
        }
    }
}