using System.Collections;
using UnityEngine;

public class EnemyJumper : MonoBehaviour
{
    private float speed = 10f;
    public float timeOnCurrentPath = 2f;
    private bool estaVivo = true;

    private Vector3 targetPosition;
    private float timeSinceLastPathChange;
    private Animator animator;

    private int currentPlataform = 5;

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
        animator = GetComponent<Animator>();
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


        if (currentPlataform > randomNumber)
        {
            //animacao espelhada
            StartCoroutine(ActivateMirrorJumpAndCooldown());
        }

        else if (currentPlataform < randomNumber)
        {
            //animacao normal
            StartCoroutine(ActivateJumpAndCooldown());

        }

        currentPlataform = randomNumber;
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

    IEnumerator ActivateJumpAndCooldown()
    {
        // Ativa o estado de salto
        animator.SetBool("Jump", true);

        // Aguarda 0.3 segundos
        yield return new WaitForSeconds(0.3f);

        // Desativa o estado de salto
        animator.SetBool("Jump", false);
    }

    IEnumerator ActivateMirrorJumpAndCooldown()
    {

        // Ativa o estado de salto
        animator.SetBool("JumpMirror", true);

        // Aguarda 0.3 segundos
        yield return new WaitForSeconds(0.3f);

        // Desativa o estado de salto
        animator.SetBool("JumpMirror", false);

    }

    IEnumerator ActivateDiveAttack()
    {

        Debug.Log("Ataque chamado");
        // Ativa o estado de salto
        animator.SetBool("Attack", true);

        // Aguarda 0.3 segundos
        yield return new WaitForSeconds(0.5f);

        // Desativa o estado de salto
        //animator.SetBool("Attack", false);

    }

    void OnTriggerStay(Collider other)
    {


        if (other.gameObject.layer == LayerMask.NameToLayer("AttackTrigger"))
        {

            StartCoroutine(ActivateDiveAttack());

        }

    }
}