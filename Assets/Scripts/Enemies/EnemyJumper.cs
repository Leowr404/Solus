using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyJumper : MonoBehaviour
{
    private float speed = 10f;
    public float timeOnCurrentPath = 2f; // Tempo que o inimigo fica em um caminho antes de mudar
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

    void Start()
    {
        
        timeSinceLastPathChange = 0f;
        ChooseNewPath();
        
    }

    void Update()
    {
        // Move o inimigo em direção à posição alvo de forma suave
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Se o inimigo atingir a posição alvo, contar o tempo no caminho atual
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            timeSinceLastPathChange += Time.deltaTime;

            // Se o tempo no caminho atual exceder o limite, escolha um novo caminho
            if (timeSinceLastPathChange >= timeOnCurrentPath)
            {
                ChooseNewPath();
            }
        }
    }

    void ChooseNewPath()
    {
        Debug.Log("CHAMADO MUDAR POSICAO ROXO");

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

        // Reinicia o contador de tempo no caminho atual
        timeSinceLastPathChange = 0f;
    }
}
