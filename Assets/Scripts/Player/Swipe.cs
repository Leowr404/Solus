using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    public Vector2 startPos; public Vector2 direction;
    public Text m_Text; string message;
    private int plataform = 2, plataformRef = 2;
    public GameObject Player;
    void Update()
    {
        m_Text.text = "Touch : " + message + "in direction" + direction;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    message = "Begun "; break;
                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    message = "Moving "; break;
                case TouchPhase.Ended:
                    Move(ref plataform, plataformRef);
                    message = "Ending "; break;
            }
        }

         void Move(ref int plataform, int plataformRef)
        {

            

            Debug.Log("Moveu");

            Vector3 position = Player.transform.position;

            if (direction.x > startPos.x)
            {
                Debug.Log("moveu pra direita");
                position.x -= 3.5f;
            }


            if (plataformRef > plataform)
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
