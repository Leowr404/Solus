using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TesteSwipe : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    public GameObject Player;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if (endTouchPosition.x > startTouchPosition.x)
            {
                RightSwipe();
            }

            if (endTouchPosition.x < startTouchPosition.x)
            {
                LeftSwipe();
            }


        }

    }

    private void RightSwipe()
    {
       // Vector3 position = Player.transform.position;
        //position.x -= 3.5f;
        Player.transform.position = new Vector3(Player.transform.position.x+3.5f,Player.transform.position.y, Player.transform.position.z);
        Debug.Log("funcionou");
        
    }
    private void LeftSwipe()
    {
        //Vector3 position = Player.transform.position;
        //position.x += 3.5f;
        Player.transform.position = new Vector3(Player.transform.position.x-3.5f, Player.transform.position.y, Player.transform.position.z);
        Debug.Log("funcionou");
    }

}
