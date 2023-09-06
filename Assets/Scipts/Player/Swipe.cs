using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{

    private Vector2 startTouchPosition;
        private Vector2 endTouchPosition;

    public GameObject Player;
    private int plataform = 2, plataformRef = 2;

    private void FixedUpdate()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;

        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if(endTouchPosition.x < startTouchPosition.x)
            {
                plataformRef++;
                move(ref plataform, plataformRef);
                

            }

            if(endTouchPosition.x > startTouchPosition.x)
            {
                plataformRef--; 
                move(ref plataform, plataformRef);

            }

          

        }
    }

    private void move(ref int plataform, int plataformRef)
    {

        Debug.Log("Moveu");

        Vector3 position = Player.transform.position;
        if(plataformRef > plataform)
        {
            position.x += 10;

        }
        else if (plataformRef < plataform)
        {
            position.x -= 10;

        }
        
        Player.transform.position = position;
        
        plataform = plataformRef;


    }


     


}
