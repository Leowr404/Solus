using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlashLightItem : MonoBehaviour
{
    public Light luz;
    public float flashlightRange;
    public LayerMask monsterLayer;

    private void Start()
    {
        luz.enabled = false;
    }

    void Update()
    {
        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            FlashlightOn();
        }

        if (Keyboard.current.gKey.wasReleasedThisFrame)
        {
            FlashlightOff();
        }
    }

    public void FlashlightOn()
    {
        luz.enabled = true;
        DetectMonstersInRange();
    }

    public void FlashlightOff()
    {
        luz.enabled = false;
    }

    public void DetectMonstersInRange()
    {
        Collider[] monstros = Physics.OverlapSphere(transform.position, flashlightRange, monsterLayer);

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
