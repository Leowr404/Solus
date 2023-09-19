using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ItensPlayer : MonoBehaviour
{
    [Header("Slider Controller")]
    public Slider chargeSlider;
    public Color safeColor;
    public Color riskyColor;
    public Color dangerColor;

    [Header("Game Objects")]
    public GameObject CameraGO;
    public GameObject FlashlightGO;

    [Header("Buttons and battery")]
    public Button itemButton;
    public List<GameObject> battery = new List<GameObject>();

    [Header("Camera (1) or Lantern (2)")]
    public int whichItem = 1;

    [Header("Camera configs")]
    public float batteryReloadTime;
    public int index = 0;

    [Header("Flashlight configs")]

    public float timeForEachBaterry = 3.0f;
    private int flashLightIndex;
    public float activatedTime = 0f;
    private bool buttonPressed = false;

    private CameraItem cameraItemScript;
    private FlashLightItem flashlightItemScript;

   
    void Start()
    {
        //ta dando algum erro que deixa a bateria transparente essa parte, serve pra mudar a cor do suquinho da bateria
        if (chargeSlider != null)
        {

            // Crie uma estrutura de cores personalizada com a nova cor.
            ColorBlock colorBlock = chargeSlider.colors;
            colorBlock.disabledColor = safeColor; // Define a nova cor para o estado desativado (disabled).

            // Atribui a estrutura de cores de volta ao Slider.
            chargeSlider.colors = colorBlock;
        }
            chargeSlider.value = 4;
        cameraItemScript = CameraGO.GetComponent<CameraItem>();
        flashlightItemScript = FlashlightGO.GetComponent<FlashLightItem>();

        flashLightIndex = 3;
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
                flashlightItemScript.FlashlightOn();
                activatedTime += Time.deltaTime;


                if(activatedTime > timeForEachBaterry && flashLightIndex == 3) {
                    
                    chargeSlider.value -= 1;

                    if(flashLightIndex > 0)
                    flashLightIndex--;
                }


                else if (activatedTime > 2*timeForEachBaterry && flashLightIndex == 2)
                {
                   
                    chargeSlider.value -= 1;

                    if (flashLightIndex > 0)
                        flashLightIndex--;
                }


                else if (activatedTime > 3 * timeForEachBaterry && flashLightIndex == 1)
                {
                    
                    chargeSlider.value -= 1;

                    if (flashLightIndex > 0)
                        flashLightIndex--;
                }


                else if (activatedTime > 4 * timeForEachBaterry && flashLightIndex == 0)
                {
                   
                    //luz.enabled = false;
                    itemButton.interactable = false;
                    buttonPressed = false;
                    flashlightItemScript.FlashlightOff();

                    chargeSlider.value -= 1;

                    if (flashLightIndex > 0)
                        flashLightIndex--;
                }
            }

    }
        #endregion
    }

    //ainda mexendo nesse metodo aqui, a mudanca ficou meio esquisita
    public void OnSliderValueChanged()
    {
        

        ColorBlock colorBlock = chargeSlider.colors;
        switch (chargeSlider.value)
        {
            case 1:
                colorBlock.disabledColor = dangerColor;
                colorBlock.normalColor = dangerColor; 
                colorBlock.highlightedColor = dangerColor; 
                colorBlock.pressedColor = dangerColor; 
                
                break;
            case 2:
                colorBlock.disabledColor = riskyColor;
                colorBlock.normalColor = riskyColor;
                colorBlock.highlightedColor = riskyColor;
                colorBlock.pressedColor = riskyColor;
                
                break;
            default:
                colorBlock.disabledColor = safeColor;
                colorBlock.normalColor = safeColor;
                colorBlock.highlightedColor = safeColor;
                colorBlock.pressedColor = safeColor;
             
                break;
        }

        chargeSlider.colors = colorBlock;

        /* switch (chargeSlider.value)
    {
        case 1:
            chargeSlider.colors = new ColorBlock { disabledColor = dangerColor };
            break;
        case 2:
            chargeSlider.colors = new ColorBlock { disabledColor = riskyColor };
            break;
        default:
            chargeSlider.colors = new ColorBlock { disabledColor = safeColor };
            break;
    }*/


    }

    #region scriptCamera
    void ActivateItemCamera()
    {
        cameraItemScript.StartCoroutine(cameraItemScript.LigarCameraPorTempo(1f));




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
        chargeSlider.value = 0;
            InvokeRepeating("ReloadCamera", batteryReloadTime, batteryReloadTime);
     



    
    }

    void ReloadCamera()
    {


        chargeSlider.value += 1;

        if (index == 3) {
            itemButton.interactable = !itemButton.interactable;
            index = -1;
            CancelInvoke("ReloadCamera");
 
        }
        
        index++;



    }




    #endregion

    public void CompleteBatteryReload()
    {
        activatedTime = 0;

        CancelInvoke("ReloadCamera");

        chargeSlider.value = 4;

        itemButton.interactable = true;
        flashLightIndex = 3;

    }

    #region scriptLanterna
    void ActivateItemFlashlight()
    {

        if(flashLightIndex <= 0 )
            itemButton.interactable = !itemButton.interactable;



        buttonPressed = !buttonPressed; 

       
        if (buttonPressed)
        {
            //luz.enabled = true;
            //flashlightItemScript.FlashlightOn();
        }
        else 
        {
            flashlightItemScript.FlashlightOff();
        }
    }
    



   /* private void DetectarMonstrosNoAlcance()
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
    }*/
#endregion
    }
