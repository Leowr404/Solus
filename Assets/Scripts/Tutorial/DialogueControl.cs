using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Componentes")]
    public GameObject Dialogue;
    public Image profile;
    public Text speechtext;
    public Text actorNameText;

    [Header("Settings")]
    public float typingspeed;
}
