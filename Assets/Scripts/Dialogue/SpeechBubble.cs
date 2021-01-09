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

    void Awake()
    {
        Instance = this;
        SetText(data);
    }

    void Update()
    {
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
        gameObject.SetActive(true);
        data = setText;
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        text.text = "";
        for (int i = 0; i < data.Length; i++)
        {
            typing = true;
            text.text += data[i];
            yield return null;
            yield return null;
        }
        typing = false;
    }
}