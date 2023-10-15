using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraItem : MonoBehaviour
{
    public Light luz;
    public float alcanceCamera;
    public LayerMask monstrosLayer;
    private bool podeLigarCamera = true;

    private void Start()
    {
        luz.enabled = false;
    }

    public IEnumerator LigarCameraPorTempo(float duracao)
    {

        luz.enabled = true; // Liga a lanterna.
        DetectarMonstrosNoAlcance();

        yield return new WaitForSeconds(0.1f); // Aguarde a duração especificada.

        luz.enabled = false; // Desliga a lanterna.

        // Inicie o cooldown de 2 segundos.
        podeLigarCamera = false;
        yield return new WaitForSeconds(0.5f); // Aguarde o cooldown de 1.5 segundos.
        podeLigarCamera = true; // A lanterna pode ser ligada novamente.
    }

    public void DetectarMonstrosNoAlcance()
    {
        Collider[] monstros = Physics.OverlapSphere(transform.position, alcanceCamera, monstrosLayer);

        foreach (var monstroCollider in monstros)
        {
            baseEnemy monstro = monstroCollider.GetComponent<baseEnemy>();

            if (monstro != null)
            {
                monstro.Morrer();
            }

            EnemyJumper jumperMonster = monstroCollider.GetComponent<EnemyJumper>();

            if(jumperMonster != null)
            {
                jumperMonster.Morrer();
            }

            
        }
    }
}