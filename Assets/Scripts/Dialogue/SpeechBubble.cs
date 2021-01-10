using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    public static SpeechBubble Instance;
    bool typing = false;
    [SerializeField] private TextMeshProUGUI text, name;
    [SerializeField] private Image portrait;
    [SerializeField] private string data;
    Coroutine typingCoroutine;
    bool openned = true;

    void Awake()
    {
        Instance = this;
        SetText(data);
    }

    void Update()
    {
        if (Controls.Interact)
        {
            if (openned)
            {
                openned = false;
                typing = false;
                text.text = data;
                if (typingCoroutine != null)
                {
                    StopCoroutine(typingCoroutine);
                }
            }
            else
            {
                if (!typing)
                {
                    gameObject.SetActive(false);
                }
            }
        }
        if (Controls.Shake)
        {
            Next();
        }
    }

    public void Next()
    {
        if (typing)
        {
            typing = false;
            text.text = data;
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void SetText(string setText)
    {
        openned = true;
        gameObject.SetActive(true);
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        if (data == setText)
        {
            typing = false;
            text.text = data;
        }
        else
        {
            typingCoroutine = StartCoroutine(Type());
        }
        data = setText;
    }

    IEnumerator Type()
    {
        text.text = "";
        for (int i = 0; i < data.Length; i++)
        {
            yield return null;
            typing = true;
            text.text += data[i];
        }
        typing = false;
    }
}