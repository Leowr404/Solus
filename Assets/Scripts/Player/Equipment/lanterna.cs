using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Importe o namespace do New Input.

public class Lanterna : MonoBehaviour
{
    public Light luz;
    public float alcanceLanterna = 10f;
    public LayerMask monstrosLayer;

    private void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame) // Verifique se a tecla 'F' foi pressionada.
        {
            ToggleLanterna();
        }
    }

    public void ToggleLanterna()
    {
        luz.enabled = !luz.enabled;

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
            baseEnemy monstro = monstroCollider.GetComponent<baseEnemy>();

            if (monstro != null)
            {
                monstro.Morrer();
            }
        }
    }
}
