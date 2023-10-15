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
        StartCoroutine(ChangePathsRoutine());
    }

    IEnumerator ChangePathsRoutine()
    {
        while (estaVivo)
        {
            ChangePaths();
            yield return new WaitForSeconds(changePathCd);
        }
    }

    void Update()
    {
        // Use o Update para movimento suave
        float displacement = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * displacement * -1);
    }

    void ChangePaths()
    {
        Debug.Log("CHAMADO MUDAR POSICAO ROXO");

        int randomNumber = UnityEngine.Random.Range(1, 4);

        Vector3 targetPosition = transform.position;

        switch (randomNumber)
        {
            case 1:
                targetPosition.x = -3.5f;
                break;

            case 2:
                targetPosition.x = 0;
                break;

            case 3:
                targetPosition.x = 3.5f;
                break;
        }

        StartCoroutine(MoveToTarget(targetPosition));
    }

    IEnumerator MoveToTarget(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}
