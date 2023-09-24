using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    public Vector2 startPos; public Vector2 direction;
    
    private int plataform = 2, plataformRef = 2;
    public GameObject Player;
    public int currentPlataform = 2;
    void Update()
    {
       
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
              //      message = "Begun ";
                    break;
                case TouchPhase.Moved:
                 //   message = "Moving ";
                    break;
                case TouchPhase.Ended:
                    direction = touch.position - startPos;
                    Move(ref plataform, plataformRef);
                 //   message = "Ending ";
                    break;
            }
        }

        void Move(ref int plataform, int plataformRef)
        {



            Debug.Log("Moveu");

            Vector3 position = Player.transform.position;

            if (direction.x > startPos.x && direction.x - startPos.x > 100 && currentPlataform != 1)
            {
                Debug.Log("moveu pra esquerda");
                position.x -= 3.5f;
                currentPlataform--;
            }
            else if (direction.x < startPos.x && startPos.x - direction.x > 100 && currentPlataform != 3)
            {
                Debug.Log("moveu pra direita");
                position.x += 3.5f;
                currentPlataform++;
            }



            Player.transform.position = position;




        }
    }





















    /*

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    public GameObject Player;
    private int plataform = 2, plataformRef = 2;

    private void Start()
    {
        
    }

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
                Move(ref plataform, plataformRef);
                

            }

            if(endTouchPosition.x > startTouchPosition.x)
            {
                plataformRef--; 
                Move(ref plataform, plataformRef);

            }

          

        }
    }

    private void Move(ref int plataform, int plataformRef)
    {

        Debug.Log("Moveu");

        Vector3 position = Player.transform.position;
        if(plataformRef > plataform)
        {
            position.x += 3.5f;

        }
        else if (plataformRef < plataform)
        {
            position.x -= 3.5f;

        }
        
        Player.transform.position = position;
        
        plataform = plataformRef;


    }


     */


}
