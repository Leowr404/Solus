using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public Text cheatAtivado;
    public Text cheatDesativado;
    public Text bateriaInfinitaCheat;

    private Player player;
    private ItensPlayer itensPlayer;
    private AudioSource Audio_Cheat;

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

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    endTouchPosition = touch.position;
                    HandleSwipe();
                    break;
            }
        }
        //IMPLEMENTE O CHEAT AQUI
        if(Input.touchCount == 5 )
        {
            if (player.cheatOn == false) { 
            cheatAtivado.gameObject.SetActive(true);
            Audio_Cheat.PlayOneShot(AudioController.instancia.CoinCollect, 1f);

                player.cheatOn = true;

               StartCoroutine(DesativarTextoCheat(cheatAtivado));
            }

         /*   else
            {
                cheatDesativado.gameObject.SetActive(true);

                player.cheatOn = false;

                StartCoroutine(DesativarTextoCheat(cheatDesativado));

            }*/


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
        Debug.Log("Swipe para a direita");
    }

    private void LeftSwipe()
    {
        float newX = Player.transform.position.x - 3.5f;
        newX = Mathf.Clamp(newX, minX, maxX);
        Player.transform.position = new Vector3(newX, Player.transform.position.y, Player.transform.position.z);
        Debug.Log("Swipe para a esquerda");
    }
    

}
