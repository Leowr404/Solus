using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CoinTxt : MonoBehaviour
{
    public Text textoMoedas;

    public void AtualizarMoedas(int moedas)
    {
        string formattedMoedas = moedas.ToString("D4");
        textoMoedas.text = formattedMoedas;
    }
}
