using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseEnemy : MonoBehaviour
{
    float speed = 2f;

    private bool estaVivo = true;

    public GameObject DeathEffect;

    public void Morrer()
    {
        if (estaVivo)
        {
            
            gameObject.SetActive(false);
            
  
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float displacement = speed * Time.fixedDeltaTime;
        transform.Translate(Vector3.forward * displacement* -1);
            
    }

    private void OnDisable()
    {
        // Instancia o DeathEffect na posição do inimigo
        GameObject deathEffectInstance = Instantiate(DeathEffect, transform.position, Quaternion.identity);

        // Configura um tempo para destruir o DeathEffect
        StartCoroutine(DestroyDeathEffect(deathEffectInstance, 2f));
    }

    private IEnumerator DestroyDeathEffect(GameObject deathEffectInstance, float delay)
    {
        // Aguarda o tempo especificado
        yield return new WaitForSeconds(delay);

        // Destrói o DeathEffect
        Destroy(deathEffectInstance);
    }
}

