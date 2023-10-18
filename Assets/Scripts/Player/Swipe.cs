using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    public GameObject Player;
    public float swipeSensitivity = 50f;
    public float minX = -3.5f; // Ajuste conforme necessário
    public float maxX = 3.5f; // Ajuste conforme necessário

    private Player player;

    private void Start()
    {
        player = Player.GetComponent<Player>();
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
            player.cheatOn = true;
          
        }
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
