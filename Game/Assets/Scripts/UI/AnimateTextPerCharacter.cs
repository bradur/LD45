// Date   : 05.10.2019 05:46
// Project: Game
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AnimateTextPerCharacter : MonoBehaviour
{

    private bool animatingText = false;
    private bool animatingColor = false;
    private float textAnimationTimer = 0f;
    private float colorAnimationTimer = 0f;

    private float textAnimationSpeed = 8f;

    private float nextMessageInterval = 0.5f;
    private float nextMessageTimer = 0f;

    [SerializeField]
    private bool automaticStartup = false;
    private bool started = false;
    private float automaticStartupDelay = 1.2f;

    [SerializeField]
    private bool skippable = false;


    [SerializeField]
    private Text txtTarget;

    [TextArea]
    [SerializeField]
    private List<string> fullMessages;

    private List<string> internalMessages;
    private bool waitingForNextMessage = false;

    private string fullMessage;

    [SerializeField]
    private Color targetColor;
    private Color originalColor;

    [SerializeField]
    private float colorAnimationDuration;

    private string dialogueText;

    [SerializeField]
    private GameObject activateWhenFinished;
    
    void Start()
    {
        txtTarget.text = "";
        originalColor = txtTarget.color;
    }

    public void TurnOn(List<string> messages, float animationSpeed) {
        txtTarget.text = "";
        internalMessages = new List<string>(messages);
        textAnimationSpeed = animationSpeed;
        txtTarget.color = originalColor;
        NextMessage();
        if (!started) {
            started = true;
        }
    }

    private void NextMessage() {
        if (internalMessages.Count > 0) {
            string msg = internalMessages[0];
            //Debug.Log(msg);
            txtTarget.text += "\n";
            ShowMessage(msg);
            internalMessages.RemoveAt(0);
        } else {
            if (activateWhenFinished != null) {
                activateWhenFinished.SetActive(true);
            }
        }
    }

    private void WaitForNextMessage() {
        nextMessageTimer = nextMessageInterval;
        waitingForNextMessage = true;
    }

    private void ShowMessage(string message)
    {
        if (message != null)
        {
            if (message != txtTarget.text) {
                animatingText = true;
                animatingColor = false;
                dialogueText = "";
                fullMessage = message;
            }
        }
    }

    public void TurnOff()
    {
        animatingText = false;
        animatingColor = true;
    }

    void Update()
    {
        if (automaticStartup && !started) {
            automaticStartupDelay -= Time.deltaTime;
            if (automaticStartupDelay <= 0f) {
                TurnOn(fullMessages, textAnimationSpeed);
            }
        }
        if (waitingForNextMessage) {
            nextMessageTimer -= Time.deltaTime;
            if (nextMessageTimer <= 0) {
                nextMessageTimer = nextMessageInterval;
                waitingForNextMessage = false;
                NextMessage();
            }
        }
        if (animatingText)
        {
            textAnimationTimer += Time.deltaTime;
            if (skippable && Input.anyKey) {
                textAnimationTimer = (1f / textAnimationSpeed) + 1;
            }
            if (textAnimationTimer > 1f / textAnimationSpeed)
            {
                if (fullMessage == dialogueText)
                {
                    animatingText = false;
                    WaitForNextMessage();
                    txtTarget.text += "\n";
                } else {
                    string addition = fullMessage.Substring(dialogueText.Length, 1);
                    dialogueText += addition;
                    txtTarget.text += addition;
                }
                textAnimationTimer = 0f;
            }
        }
        if (animatingColor) {
            colorAnimationTimer += Time.deltaTime / colorAnimationDuration;
            txtTarget.color = Color.Lerp(originalColor, targetColor, colorAnimationTimer);
            if (colorAnimationTimer > 1) {
                animatingColor = false;
                colorAnimationTimer = 0f;
            }
        }
    }
}
