using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraItem : MonoBehaviour
{
    public Button itemButton; 

    void Start()
    {
        itemButton.onClick.AddListener(ActivateItem); 
    }

    void ActivateItem()
    {
        Debug.Log("Botao apertado");
    }
}
