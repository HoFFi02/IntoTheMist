using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAreaText : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index = 0;

    public float wordSpeed;
    public float displayTime = 5f; // Czas wyœwietlania dialogu w sekundach
    private float currentTime = 0f;
    private bool playerIsClose;
    private bool dialogueDisplayed = false; // Flaga informuj¹ca, czy dialog zosta³ ju¿ wyœwietlony


    void Start()
    {
        dialogueText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsClose && !dialogueDisplayed)
        {
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
            dialogueDisplayed = true;
        }

        // Sprawdzenie, czy up³yn¹³ czas wyœwietlania dialogu
        if (dialoguePanel.activeInHierarchy)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= displayTime)
            {
                zeroText();
            }
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        dialogueDisplayed = false;
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
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
        }
    }
}