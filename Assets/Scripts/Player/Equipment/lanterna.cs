using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Importe o namespace do New Input.

public class Lanterna : MonoBehaviour
{
    public Light luz;
    public float alcanceLanterna = 10f;
    public LayerMask monstrosLayer;
    private bool podeLigarLanterna = true;

    private void Update()
    {
        if (podeLigarLanterna && Keyboard.current.fKey.wasPressedThisFrame) // Verifique se a tecla 'F' foi pressionada e se a lanterna pode ser ligada.
        {
            StartCoroutine(LigarLanternaPorTempo(1f)); // Ligue a lanterna por 1 segundo.
        }
    }

    private IEnumerator LigarLanternaPorTempo(float duracao)
    {
        luz.enabled = true; // Liga a lanterna.

        yield return new WaitForSeconds(duracao); // Aguarde a duração especificada.

        luz.enabled = false; // Desliga a lanterna.

        // Inicie o cooldown de 2 segundos.
        podeLigarLanterna = false;
        yield return new WaitForSeconds(1.5f); // Aguarde o cooldown de 2 segundos.
        podeLigarLanterna = true; // A lanterna pode ser ligada novamente.
        DetectarMonstrosNoAlcance();
    }

    private void DetectarMonstrosNoAlcance()
    {
        Collider[] monstros = Physics.OverlapSphere(transform.position, alcanceLanterna, monstrosLayer);

        foreach (var monstroCollider in monstros)
        {
            baseEnemy monstro = monstroCollider.GetComponent<baseEnemy>();

            if (monstro != null)
            {
                monstro.Morrer();
            }
        }
    }
}