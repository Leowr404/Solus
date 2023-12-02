using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


    [System.Serializable]
    public class TutorialPanel
    {
        public GameObject panelObject;
        public Text dialogueText;
        public string dialogue;
    }

    public class TutorialGame : MonoBehaviour
    {
        public TutorialPanel[] tutorialPanels;
        private int currentPanelIndex = 0;
        public float typingSpeed = 0.05f;

        private bool tutorialCompleted = false;

        void Start()
        {
            
            tutorialCompleted = PlayerPrefs.HasKey("TutorialGameCompleted");

            if (!tutorialCompleted)
            {
                ShowCurrentPanel();
            }
            else
            {
                // Se já foi concluído, desativa todos os painéis
                foreach (var panel in tutorialPanels)
                {
                    panel.panelObject.SetActive(false);
                }
                 SceneManager.LoadSceneAsync(1);
            }
        }

        void ShowCurrentPanel()
        {
            if (currentPanelIndex < tutorialPanels.Length)
            {
                tutorialPanels[currentPanelIndex].panelObject.SetActive(true);

                // Se for o painel atual, exibe o diálogo
                StartCoroutine(TypeDialogue(tutorialPanels[currentPanelIndex].dialogueText, tutorialPanels[currentPanelIndex].dialogue));
            }
        }

        IEnumerator TypeDialogue(Text textObject, string dialogue)
        {
            textObject.text = "";

            foreach (char letter in dialogue.ToCharArray())
            {
                textObject.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        void Update()
        {
            if (!tutorialCompleted && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                NextPanel();
            }
        }

        public void NextPanel()
        {
            if (!tutorialCompleted)
            {
                tutorialPanels[currentPanelIndex].panelObject.SetActive(false);
                currentPanelIndex++;

                if (currentPanelIndex < tutorialPanels.Length)
                {
                    ShowCurrentPanel();
                }
                else
                {
                    EndTutorial();
                }
            }
        }

        void EndTutorial()
        {
            Debug.Log("Tutorial concluído!");

            PlayerPrefs.SetInt("TutorialGameCompleted", 1);
            PlayerPrefs.Save(); // Certifica-se de salvar imediatamente
            SceneManager.LoadSceneAsync(1);
    }

        
    }
    
