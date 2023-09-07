using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraItem : MonoBehaviour
{
    
    void Start()
    {
        
    }

   
    void FixedUpdate()
    {
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 

            
            if (touch.phase == TouchPhase.Began)
            {
                if (IsPointerOverUIObject(touch.position))
                {
                    Debug.Log("clicou no botao");
                }
            }
        }
    }

    // Método para verificar se o toque ocorreu em cima de um objeto de interface de usuário.
    bool IsPointerOverUIObject(Vector2 touchPosition)
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = touchPosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }
}
