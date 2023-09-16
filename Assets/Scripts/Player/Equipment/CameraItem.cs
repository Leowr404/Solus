using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CameraItem : MonoBehaviour
{
    [Header("Buttons and battery")]
    public Button itemButton;
    public List<GameObject> battery = new List<GameObject>();

    [Header("Camera (1) or Lantern (2)")]
    public int whichItem = 1;

    [Header("Camera configs")]
    public float batteryReloadTime;
    private int index = 0;

    [Header("Flashlight configs")]
    public Light luz;
    public float alcanceLanterna = 10f;
    public LayerMask monstrosLayer;
    public float timeForEachBaterry = 3.0f;
    private int flashLightIndex;
    private float activatedTime = 0f;
    private bool buttonPressed = false;

   /* private int recharge { get {return recharge; } 
        set {recharge = value; } 
    }*/

    void Start()
    {
        
        flashLightIndex = battery.Count-1;
        int cargas = battery.Count;

        if(whichItem == 1)
        itemButton.onClick.AddListener(ActivateItemCamera);

        else if(whichItem == 2)
            itemButton.onClick.AddListener(ActivateItemFlashlight);
    }

    void Update()
    {

        #region bateriaLanterna
        if (whichItem == 2) { 

            if (buttonPressed)
        {
            activatedTime += Time.deltaTime;


                if(activatedTime > timeForEachBaterry && flashLightIndex == battery.Count-1) {
                    Image image = battery[flashLightIndex].GetComponent<Image>();

                    if (image != null)
                        image.color = Color.red;

                    if(flashLightIndex > 0)
                    flashLightIndex--;
                }


                else if (activatedTime > 2*timeForEachBaterry && flashLightIndex == battery.Count - 2)
                {
                    Image image = battery[flashLightIndex].GetComponent<Image>();

                    if (image != null)
                        image.color = Color.red;

                    if (flashLightIndex > 0)
                        flashLightIndex--;
                }


                else if (activatedTime > 3 * timeForEachBaterry && flashLightIndex == battery.Count - 3)
                {
                    Image image = battery[flashLightIndex].GetComponent<Image>();

                    if (image != null)
                        image.color = Color.red;

                    if (flashLightIndex > 0)
                        flashLightIndex--;
                }


                else if (activatedTime > 4 * timeForEachBaterry && flashLightIndex == battery.Count - 4)
                {
                    Image image = battery[flashLightIndex].GetComponent<Image>();

                    if (image != null)
                        image.color = Color.red;

                    if (flashLightIndex > 0)
                        flashLightIndex--;
                }
            }

    }
        #endregion
    }

    #region scriptCamera
    void ActivateItemCamera()
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


    public void CompleteReload()
    {
        CancelInvoke("ReloadCamera");
        for(int i = 0; i< battery.Count-1; i++) { 
        Image image = battery[i].GetComponent<Image>();
        }

        index = battery.Count - 1;
    }


        #endregion

        #region scriptLanterna
        void ActivateItemFlashlight()
    {

        if(flashLightIndex <= 0 )
            itemButton.interactable = !itemButton.interactable;



        buttonPressed = !buttonPressed; 

       
        if (buttonPressed)
        {
            luz.enabled = true;
            DetectarMonstrosNoAlcance();
        }
        else 
        {
            luz.enabled = false;
        }
    }
    



    private void DetectarMonstrosNoAlcance()
    {
        Collider[] monstros = Physics.OverlapSphere(transform.position, alcanceLanterna, monstrosLayer);

        foreach (var monstroCollider in monstros)
        {
            baseEnemy monstro = monstroCollider.GetComponent<baseEnemy>();

            if (monstro != null)
            {
                monstro.Morrer();
            }
        }
    }
    #endregion
}
