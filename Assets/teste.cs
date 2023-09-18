using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour
{
    public float quantidadeRecarga = 50f; // Quantidade de carga que a bateria fornece à lanterna

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Certifique-se de configurar a tag correta no jogador
        {
            FlashLightItem lanterna = other.GetComponent<FlashLightItem>();
            if (lanterna != null)
            {
                // Recarregar a lanterna e destruir a bateria
                lanterna.RecarregarLanterna(quantidadeRecarga);
                Destroy(gameObject);
            }
        }
    }
}
