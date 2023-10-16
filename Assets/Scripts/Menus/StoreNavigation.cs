using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreNavigation : MonoBehaviour
{

    public List<Text> textos = new List<Text>();
    [SerializeField] int currentItem = 0;
   
    public void NextStoreItem()
    {
        textos[currentItem].gameObject.SetActive(false);
        currentItem++;
        textos[currentItem].gameObject.SetActive(true);
            
    }

    public void PreviousStoreItem()
    {
        textos[currentItem].gameObject.SetActive(false);
        currentItem--;
        textos[currentItem].gameObject.SetActive(true);

    }

}
