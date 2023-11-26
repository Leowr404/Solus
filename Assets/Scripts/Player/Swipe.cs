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

    private void Start()
    {
        player = Player.GetComponent<Player>();
        itensPlayer = ItensPlayer.GetComponent<ItensPlayer>();
        Audio_Cheat = AudioController.instancia.GetComponent<AudioSource>();
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
                    FUNCIONOU = true;
                    itensPlayer.ActivateItem();
                    
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

        if (Input.touchCount == 5)
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
        }
    }

    private void RightSwipe()
    {
        float newX = Player.transform.position.x + 3.5f;
        newX = Mathf.Clamp(newX, minX, maxX);
        Player.transform.position = new Vector3(newX, Player.transform.position.y, Player.transform.position.z);
    
    }

    private void LeftSwipe()
    {
        float newX = Player.transform.position.x - 3.5f;
        newX = Mathf.Clamp(newX, minX, maxX);
        Player.transform.position = new Vector3(newX, Player.transform.position.y, Player.transform.position.z);
     
    }
}
