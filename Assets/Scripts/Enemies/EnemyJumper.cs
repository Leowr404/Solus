using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyJumper : MonoBehaviour
{
    public float speed = 2f;
    public float changePathCd = 1.5f;

    private bool estaVivo = true;

    public void Morrer()
    {
        if (estaVivo)
        {

            gameObject.SetActive(false);


        }
    }

    void Start()
    {
        InvokeRepeating("ChangePaths", changePathCd, changePathCd);
    }

    void FixedUpdate()
    {
        float displacement = speed * Time.fixedDeltaTime;
        transform.Translate(Vector3.forward * displacement * -1);

    }

    void ChangePaths()
    {
        Debug.Log("CHAMADO MUDAR POSICAO ROXO");

        int randomNumber = UnityEngine.Random.Range(1,4);

        Vector3 newPosition = transform.position;


        switch (randomNumber)
        {
            case 1:
                newPosition.x = -3.5f;
                break;

            case 2:
                newPosition.x = 0;
                break;

            case 3:
                newPosition.x = 3.5f;
                break;
        }

        transform.position = newPosition;

    }
}
