using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonValve : Interactible
{
    AudioSource audio;
    [SerializeField] int val;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Play()
    {
        transform.Shake(0.5f, 1);
        audio.Play();
    }

    public override void Interact()
    {
        Play();
        Simon.Instance.Played(val);
    }
}