// Date   : 05.10.2019 05:46
// Project: Game
// Author : bradur

using UnityEngine;
using UnityEngine.UI;

public class AnimateTextPerCharacter : MonoBehaviour
{

    private bool animatingText = false;
    private bool animatingColor = false;
    private float textAnimationTimer = 0f;
    private float colorAnimationTimer = 0f;

    [SerializeField]
    [Range(0.1f, 10f)]
    private float textAnimationSpeed = 1f;

    [SerializeField]
    private Text txtTarget;

    [TextArea]
    [SerializeField]
    private string fullMessage;

    [SerializeField]
    private Color targetColor;
    private Color originalColor;

    [SerializeField]
    private float colorAnimationDuration;


    void Start()
    {
        txtTarget.text = "";
        originalColor = txtTarget.color;
    }

    public void TurnOn(string message)
    {
        if (message != null)
        {
            txtTarget.color = originalColor;
            if (message != txtTarget.text) {
                animatingText = true;
                animatingColor = false;
                if (fullMessage != message)
                {
                    txtTarget.text = "";
                }
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
        if (animatingText)
        {
            textAnimationTimer += Time.deltaTime;
            if (textAnimationTimer > 1f / textAnimationSpeed)
            {
                string dialogueText = txtTarget.text;
                dialogueText = fullMessage.Substring(0, dialogueText.Length + 1);
                if (fullMessage == dialogueText)
                {
                    animatingText = false;
                }
                textAnimationTimer = 0f;
                txtTarget.text = dialogueText;
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
