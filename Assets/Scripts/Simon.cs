using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Simon : MonoBehaviour
{
    public static Simon Instance;
    [SerializeField] UnityEvent action;
    [SerializeField] SimonValve[] Valves;
    [SerializeField] AudioClip wrong, correct;
    AudioSource source;

    int step = 0;
    int count = 0;
    bool complete = false;

    int[][] steps = new int[][]
    {
        new int[] { 6 },
        new int[] { 0, 2 },
        new int[] { 0, 2, 5 },
        new int[] { 0, 2, 5, 2 }
    };

    void Awake()
    {
        Instance = this;
        source = GetComponent<AudioSource>();
    }

    public void Play()
    {
        StartCoroutine(PlayValves());
    }

    IEnumerator PlayValves()
    {
        for (int i = 0; i < steps[step].Length; i++)
        {
            yield return new WaitForSeconds(1f);
            Valves[steps[step][i]].Play();
        }

    }

    public void Played(int val)
    {
        if (complete)
        {
            return;
        }
        if (val == steps[step][count])
        {
            count++;
            if (count >= steps[step].Length)
            {
                step++;
                count = 0;
                if (step >= steps.Length)
                {
                    Victory();
                }
                else
                {
                    Play();
                }
            }
        }
        else
        {
            step = 0;
            count = 0;
            int x = Mathf.FloorToInt(Random.value * 6);
            int y = Mathf.FloorToInt(Random.value * 6);
            int z = Mathf.FloorToInt(Random.value * 6);
            int w = Mathf.FloorToInt(Random.value * 6);
            steps = new int[][]
            {
                new int[] { x },
                new int[] { x, y },
                new int[] { x, y, z },
                new int[] { x, y, z, w }
            };
            //source.clip = wrong;
            //source.Play();
            Play();
        }
    }

    void Victory()
    {
        complete = true;
        source.clip = correct;
        source.Play();
        action.Invoke();
    }
}