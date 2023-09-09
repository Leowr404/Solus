using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanterna : MonoBehaviour
{
    public Light luz;
    public float alcanceLanterna = 10f; // Defina o alcance desejado da lanterna.
    public LayerMask monstrosLayer; // Certifique-se de configurar a Layer nos monstros para detectá-los corretamente.

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Troque por qualquer tecla que você queira para ligar/desligar a lanterna.
        {
            ToggleLanterna();
        }
    }

    private void ToggleLanterna()
    {
        luz.enabled = !luz.enabled; // Liga/desliga a luz da lanterna.

        if (luz.enabled)
        {
            DetectarMonstrosNoAlcance();
        }
    }

    private void DetectarMonstrosNoAlcance()
    {
        Collider[] monstros = Physics.OverlapSphere(transform.position, alcanceLanterna, monstrosLayer);

        foreach (var monstroCollider in monstros)
        {
            // Certifique-se de que o monstro tem o componente "MonstroController" anexado.
            baseEnemy monstro = monstroCollider.GetComponent<baseEnemy>();

            if (monstro != null)
            {
                monstro.Morrer();
            }
        }
    }
}
