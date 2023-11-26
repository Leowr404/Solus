using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ItensPlayer : MonoBehaviour
{
    [Header("Slider Controller")]
    public Slider chargeSlider;
    public Color powerUpColor;
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

    [Header("Flashlight configs")]
    public int powerUpDuration;

    private CameraItem cameraItemScript;
    private FlashLightItem flashlightItemScript;
    private AudioSource Lanterna;
    private AudioSource camera;
    public bool powerUpActivated = false;
    public bool cheatBateria = false;

    public bool flashlightOn = false;

    void Start()
    {
        Lanterna = AudioController.instancia.GetComponent<AudioSource>();
        camera = AudioController.instancia.GetComponent<AudioSource>();

        //verifica qual item o jogador escolheu no menu
        //  whichItem = PlayerPrefs.GetInt("ChosenItem");

        if (whichItem == 1)
        {
            CameraGO.SetActive(true);
        }
        else
        {
            FlashlightGO.SetActive(true);

        }


        if (chargeSlider != null)
        {


            ColorBlock colorBlock = chargeSlider.colors;
            colorBlock.disabledColor = safeColor;


            chargeSlider.colors = colorBlock;
        }
        chargeSlider.value = 4;
        cameraItemScript = CameraGO.GetComponent<CameraItem>();
        flashlightItemScript = FlashlightGO.GetComponent<FlashLightItem>();

        flashLightIndex = 3;
        int cargas = battery.Count;

        if (whichItem == 1)
            itemButton.onClick.AddListener(ActivateItemCamera);

        else if (whichItem == 2)
            itemButton.onClick.AddListener(ActivateItemFlashlight);
    }

     void Update()
     {

       
            if (flashlightOn)
            {
                ActivateFlashLightByTap();
            }
        

        #region bateriaLanterna
        if (whichItem == 2) {


             if (buttonPressed || flashlightOn)
         {

                 flashlightItemScript.FlashlightOn();



                 if(powerUpActivated == false && cheatBateria == false) { 
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


                     itemButton.interactable = false;
                     buttonPressed = false;
                     flashlightItemScript.FlashlightOff();

                     chargeSlider.value -= 1;

                     if (flashLightIndex > 0)
                         flashLightIndex--;
                 }
             }
             }
         }
         #endregion
     }

    public void InfiniteBattery()
    {
        ColorBlock colorBlock = chargeSlider.colors;
        colorBlock.disabledColor = powerUpColor;
        colorBlock.normalColor = powerUpColor;
        colorBlock.highlightedColor = powerUpColor;
        colorBlock.pressedColor = powerUpColor;

        chargeSlider.colors = colorBlock;

        chargeSlider.value = 4;

        itemButton.interactable = true;

    }

    //modifica a cor da bateria a medida que a energia eh gasta ou restaurada
    public void OnSliderValueChanged()
    {


        if (powerUpActivated == false && cheatBateria == false)
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



        }

    }

    #region scriptCamera
    void ActivateItemCamera()
    {

        cameraItemScript.StartCoroutine(cameraItemScript.LigarCameraPorTempo(1f));

        if (powerUpActivated == false)
        {


            if (cheatBateria == false) itemButton.interactable = !itemButton.interactable;

            camera.PlayOneShot(AudioController.instancia.Audio_Camera, 1f);


            if (cheatBateria == false)
            {


                chargeSlider.value = 0;
                InvokeRepeating("ReloadCamera", batteryReloadTime, batteryReloadTime);


            }


        }


    }
    void ReloadCamera()
    {


        chargeSlider.value += 1;

        if (index == 3)
        {
            itemButton.interactable = !itemButton.interactable;
            index = -1;
            CancelInvoke("ReloadCamera");

        }

        index++;



    }




    #endregion

    //metodo chamado quando o jogador colide com uma bateria
    public void CompleteBatteryReload()
    {
        activatedTime = 0;

        CancelInvoke("ReloadCamera");

        chargeSlider.value = 4;

        itemButton.interactable = true;
        flashLightIndex = 3;

    }
    //metodo chamado quando o jogador colide com um power up
    public IEnumerator PowerUpInfiniteBattery()
    {
        powerUpActivated = true;
        //testar se causa algum bug mais tarde
        // flashlightOn = true;
        Debug.Log("powerUp ativo!");
        activatedTime = 0;
        chargeSlider.value = 4;
        flashLightIndex = 3;


        ColorBlock colorBlock = chargeSlider.colors;
        colorBlock.disabledColor = powerUpColor;
        colorBlock.normalColor = powerUpColor;
        colorBlock.highlightedColor = powerUpColor;
        colorBlock.pressedColor = powerUpColor;

        chargeSlider.colors = colorBlock;

        itemButton.interactable = true;

        yield return new WaitForSeconds(powerUpDuration);

        powerUpActivated = false;
        OnSliderValueChanged();
    }

    #region scriptLanterna
    void ActivateItemFlashlight()
    {

        if (flashLightIndex < 0)
            itemButton.interactable = !itemButton.interactable;
        Lanterna.PlayOneShot(AudioController.instancia.Audio_Lanterna, 1f);



        buttonPressed = !buttonPressed;


        if (buttonPressed)
        {
            Lanterna.PlayOneShot(AudioController.instancia.Audio_Lanterna, 1f);

        }
        else
        {
            flashlightItemScript.FlashlightOff();
        }
    }

    
    private void ActivateFlashLightByTap()
    {
        flashlightItemScript.FlashlightOn();


    }

    private void DisableFlashLightByTap()
    {
        flashlightItemScript.FlashlightOff();

    }


    public void ActivateItem()
    {
        if (whichItem == 1)
        {
            if (chargeSlider.value == 4)
            {
                ActivateItemCamera();
            }
        }

        if (whichItem == 2)
        {
            if (flashlightOn)
            {
                flashlightOn = false;
                DisableFlashLightByTap();
            }
            else if (flashLightIndex > -1)
            {
                flashlightOn = true;
                Lanterna.PlayOneShot(AudioController.instancia.Audio_Lanterna, 1f);
                // ActivateFlashLightByTap();
            }
        }
    }

    /*public void ActivateItem()
    {
        if(whichItem == 1)
        {
            if(chargeSlider.value == 4) { 
            ActivateItemCamera();
                
            }
        }

        if (whichItem == 2)
        {

            //            ActivateItemFlashlight();

            bool canTurnOn = true;

            if (flashlightOn == true)
            {
 
                flashlightOn = false;
                DisableFlashLightByTap();

                canTurnOn = false;
            }
            

            else if (flashlightOn == false && flashLightIndex > -1 && canTurnOn == true)
            {
              //  Debug.Log("lanterna ativada");
                flashlightOn = true;
                ActivateFlashLightByTap();

            }
            Debug.Log(canTurnOn);

            //terminar a parte da lanterna dps, ainda ta muito bugada

        }
    }*/


    #endregion
}