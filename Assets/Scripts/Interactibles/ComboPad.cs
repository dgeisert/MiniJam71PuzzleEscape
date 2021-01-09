using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ComboPad : MonoBehaviour
{
    [SerializeField] string code = "0000";
    string attempt;
    [SerializeField] UnityEvent onCorrect;
    AudioSource audioSource;
    [SerializeField] AudioClip correct, wrong, click;
    [SerializeField] TextMeshPro text;

    void Awake()
    {
        onCorrect.AddListener(PlayCorrect);
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
    }

    void PlayCorrect()
    {
        text.color = Color.green;
        audioSource.clip = correct;
        audioSource.Play();
    }

    public void AddToCode(string add)
    {
        audioSource.clip = click;
        attempt += add;
        text.color = Color.white;
        text.text = attempt;
        if (attempt.Length >= code.Length)
        {
            if (attempt == code)
            {
                onCorrect.Invoke();
            }
            else
            {
                audioSource.clip = wrong;
                attempt = "";
                text.color = Color.red;
            }
        }
        audioSource.Play();
    }
}