using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraItem : MonoBehaviour
{
    public Button itemButton;
    public List<GameObject> battery = new List<GameObject>();

    public float batteryReloadTime;
    private int index = 0;



    void Start()
    {
        
        int cargas = battery.Count;

        itemButton.onClick.AddListener(ActivateItem);
    }

    void ActivateItem()
    {
      




   itemButton.interactable = !itemButton.interactable;


        

            #region colocarCorVermelha
            foreach (GameObject obj in battery)
            {

                Image image = obj.GetComponent<Image>();
                if (image != null)
                {
                 
                    image.color = Color.red;
                }
                #endregion

                

               
        }
           
            InvokeRepeating("ReloadCamera", batteryReloadTime, batteryReloadTime);
     



    
    }

    void ReloadCamera()
    {
       

        Image image = battery[index].GetComponent<Image>();

        if (image != null)
            image.color = Color.green;

        if (index == battery.Count - 1) {
            itemButton.interactable = !itemButton.interactable;
            index = -1;
            CancelInvoke("ReloadCamera");
 
        }
        
        index++;



    }
}
