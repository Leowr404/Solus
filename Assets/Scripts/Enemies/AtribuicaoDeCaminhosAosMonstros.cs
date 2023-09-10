using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtribuicaoDeCaminhosAosMonstros : MonoBehaviour
{
    public string tagCaminhoPadrao = "Caminho1"; // Tag padr�o para os monstros.

    //Tag do Monstro e a Monster

    private void Start()
    {
        // Encontre todos os monstros na cena.
        GameObject[] monstros = GameObject.FindGameObjectsWithTag("Monstro");

        foreach (GameObject monstro in monstros)
        {
            // Obtenha a tag do monstro (pode ser definida no Inspector).
            string tagMonstro = monstro.tag;

            // Se a tag do monstro n�o for definida, use a tag padr�o.
            if (string.IsNullOrEmpty(tagMonstro))
            {
                tagMonstro = tagCaminhoPadrao;
            }

            // Encontre o caminho correspondente com base na tag.
            Transform caminho = GameObject.Find(tagMonstro).transform;

            // Defina o caminho como pai do monstro para atribu�-lo ao caminho.
            monstro.transform.parent = caminho;
        }
    }
}
