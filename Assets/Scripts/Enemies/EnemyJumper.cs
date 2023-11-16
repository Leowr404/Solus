using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumper : MonoBehaviour
{
    private float speed = 10f;
    public float timeOnCurrentPath = 2f;
    private bool estaVivo = true;

    private Vector3 targetPosition;
    private float timeSinceLastPathChange;

    public void Morrer()
    {
        if (estaVivo)
        {
            gameObject.SetActive(false);
        }
    }

    void OnEnable()
    {
        // Chama ChooseNewPath quando o inimigo é ativado (reciclado)
        ChooseNewPath();
    }

    void Start()
    {
        timeSinceLastPathChange = 0f;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            timeSinceLastPathChange += Time.deltaTime;

            if (timeSinceLastPathChange >= timeOnCurrentPath)
            {
                ChooseNewPath();
            }
        }
    }

    void ChooseNewPath()
    {
        int randomNumber = UnityEngine.Random.Range(1, 4);

        switch (randomNumber)
        {
            case 1:
                targetPosition = new Vector3(-3.5f, transform.position.y, transform.position.z);
                break;

            case 2:
                targetPosition = new Vector3(0, transform.position.y, transform.position.z);
                break;

            case 3:
                targetPosition = new Vector3(3.5f, transform.position.y, transform.position.z);
                break;
        }

        timeSinceLastPathChange = 0f;
    }
}
