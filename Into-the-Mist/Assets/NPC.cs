using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index = 0;
    

    public string gameSceneName;


    

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;


    private void Start()
    {
        dialogueText.text = "";
        contButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }

        }


        if (dialogueText.text.Equals(dialogue[index]))
        {
            contButton.SetActive(true);
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    public void NextLine()
    {
        index++;
        if (index < dialogue.Length)
        {
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
            SceneManager.LoadScene(gameSceneName);
        }
    }

    private void ShowFullText()
    {
        dialogueText.text = dialogue[index];
        contButton.SetActive(true);
    }

    private IEnumerator Typing()
    {
        string targetText = dialogue[index];
        int textLength = targetText.Length;
        int currentCharacter = 0;

        while (currentCharacter <= textLength)
        {
            dialogueText.text = targetText.Substring(0, currentCharacter);
            currentCharacter++;
            yield return new WaitForSeconds(wordSpeed);
        }

        ShowFullText();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }

}