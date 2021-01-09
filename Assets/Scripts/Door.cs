using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactible
{
    [SerializeField] Vector3 open, closed;
    [SerializeField] bool Rotational = false;
    bool isOpen = false;
    Vector3 dir;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (Rotational)
        {
            transform.localEulerAngles = closed;
        }
        else
        {
            transform.localPosition = closed;
        }
        dir = (open - closed);
    }
    public override void Interact()
    {
        base.Interact();
        Open();
    }
    void Open()
    {
        if (isOpen)
        {
            return;
        }
        if (audioSource != null)
        {
            audioSource.Play();
        }
        StartCoroutine(DoOpen());
        isOpen = true;
    }
    IEnumerator DoOpen()
    {
        float time = 0;
        while (time < 1)
        {
            yield return null;
            if (Rotational)
            {
                transform.localEulerAngles += dir * Time.deltaTime;
            }
            else
            {
                transform.localPosition += dir * Time.deltaTime;
            }
            time += Time.deltaTime;
        }
    }
}