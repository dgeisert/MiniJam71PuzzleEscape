using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attracted : MonoBehaviour
{
    void Start()
    {
        Attractor.Instance.Add(transform);
    }
}