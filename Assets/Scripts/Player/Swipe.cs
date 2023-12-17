using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    public GameObject Player;
    public GameObject ItensPlayer;
    public float swipeSensitivity = 50f;
    public float minX = -3.5f; // Ajuste conforme necessário
    public float maxX = 3.5f; // Ajuste conforme necessário
    private float tapSensitivity = 10f;
    public Text cheatAtivado;
    public Text cheatDesativado;
    public Text bateriaInfinitaCheat;

    private Player player;
    private ItensPlayer itensPlayer;
    private AudioSource Audio_Cheat;

    public bool doubleTap = false;
    public bool FUNCIONOU = false;
    private float tapCD = 0.2f;

    private int quantidade = 0;
    private bool canActivateItem = true;
    public Animator animator;
    private AudioSource Dash;

    private void Start()
    {
        
        
        player = Player.GetComponent<Player>();
        itensPlayer = ItensPlayer.GetComponent<ItensPlayer>();
        Audio_Cheat = AudioController.instancia.GetComponent<AudioSource>();
        Dash = AudioController.instancia.GetComponent<AudioSource>();
    }

    private void Update()
{
    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0);


            if (Input.touchCount == 1 && doubleTap == true)
            {
                float tapDeltaX = touch.position.x - startTouchPosition.x;
                if (Mathf.Abs(tapDeltaX) < tapSensitivity)
                {
                    quantidade++;
                    FUNCIONOU = true;

                    if (canActivateItem)
                    {
                        StartCoroutine(ActivateItemCooldown());
                        itensPlayer.ActivateItem();
                    }
                }
            }


            switch (touch.phase)
        {
            case TouchPhase.Began:
                startTouchPosition = touch.position;
                break;

            case TouchPhase.Ended:
                endTouchPosition = touch.position;
                HandleSwipe();

                // Verifica se é um toque simples dentro da área especificada
                float swipeDeltaX = endTouchPosition.x - startTouchPosition.x;
                if (touch.tapCount == 1 && Mathf.Abs(swipeDeltaX) < swipeSensitivity)
                {
                    StartCoroutine(DoubleTapCooldown());
                }
                
                break;
        }
    }

        if (Input.touchCount == 4)
        {
            if (player.cheatOn == false)
            {
                cheatAtivado.gameObject.SetActive(true);
                Audio_Cheat.PlayOneShot(AudioController.instancia.CoinCollect, 1f);

                player.cheatOn = true;

                StartCoroutine(DesativarTextoCheat(cheatAtivado));
            }
        }

        if (Input.touchCount == 3 && itensPlayer.cheatBateria == false)
        {
            itensPlayer.cheatBateria = true;
            itensPlayer.InfiniteBattery();

            bateriaInfinitaCheat.gameObject.SetActive(true);

            StartCoroutine(DesativarTextoCheat(bateriaInfinitaCheat));
        }

     
    }
    
    private IEnumerator DesativarTextoCheat(Text cheatText)
    {
        yield return new WaitForSeconds(3);

        cheatText.gameObject.SetActive(false);
    }

    private IEnumerator DoubleTapCooldown()
    {
        doubleTap = true;
        yield return new WaitForSeconds(tapCD);
        doubleTap = false;
    }

    private void HandleSwipe()
    {
        float swipeDeltaX = endTouchPosition.x - startTouchPosition.x;

        if (Mathf.Abs(swipeDeltaX) > swipeSensitivity)
        {
            if (swipeDeltaX > 0)
            {
                RightSwipe();
                

            }
            else
            {
                LeftSwipe();
                
            }
            animator.SetBool("Running", true);
        }
        
    }
    IEnumerator ActivateEsquedaCooldown()
    {
        // Ativa o trigger de salto para a esquerda
        animator.SetTrigger("EsquerdaT");

        // Aguarda o tempo da animação de pulo
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);

        // Reseta o trigger para evitar travamentos
        animator.ResetTrigger("EsquerdaT");

        
    }

    IEnumerator ActivateDireitaCooldown()
    {
        // Ativa o trigger de salto para a direita
        animator.SetTrigger("DireitaT");

        // Aguarda o tempo da animação de pulo
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);

        // Reseta o trigger para evitar travamentos
        animator.ResetTrigger("DireitaT");

        
    }

    private void RightSwipe()
    {
        if (player.transform.position.x != 3.5)
        {
            StartCoroutine(ActivateDireitaCooldown());
        }
        float targetX = Mathf.Clamp(Player.transform.position.x + 3.5f, minX, maxX);
        Dash.PlayOneShot(AudioController.instancia.dash, 0.2f);
        StartCoroutine(MovePlayerSmoothly(targetX, "Direita"));




    }

    private void LeftSwipe()
    {
        if(player.transform.position.x != -3.5) { 
        StartCoroutine(ActivateEsquedaCooldown());
        }
        float targetX = Mathf.Clamp(Player.transform.position.x - 3.5f, minX, maxX);
        Dash.PlayOneShot(AudioController.instancia.dash, 0.2f);
        StartCoroutine(MovePlayerSmoothly(targetX, "Esquerda"));


    }

    private IEnumerator ActivateItemCooldown()
    {
        canActivateItem = false;
        yield return new WaitForSeconds(0.3f); // Intervalo desejado (meio segundo)
        canActivateItem = true;
    }

    private IEnumerator MovePlayerSmoothly(float targetX, string animationTrigger)
    {
        float smoothSpeed = 15f; // Ajuste conforme necessário
        while (Mathf.Abs(Player.transform.position.x - targetX) > 0.1f)
        {
            float newX = Mathf.MoveTowards(Player.transform.position.x, targetX, smoothSpeed * Time.deltaTime);
            Player.transform.position = new Vector3(newX, Player.transform.position.y, Player.transform.position.z);
            yield return null;
        }
    }

    
}
