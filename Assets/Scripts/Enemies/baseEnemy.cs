using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseEnemy : MonoBehaviour
{
    float speed = 2f;

    private bool estaVivo = true;

    public void Morrer()
    {
        if (estaVivo)
        {
            // Adicione aqui qualquer lógica para a "morte" do monstro.
            // Por exemplo, você pode desativar visualmente o monstro, tocar uma animação de morte, reproduzir um som, etc.

            // Aqui, vamos apenas desativar o GameObject do monstro.
            Destroy(gameObject);
            //gameObject.SetActive(false);

            estaVivo = false;
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
}

