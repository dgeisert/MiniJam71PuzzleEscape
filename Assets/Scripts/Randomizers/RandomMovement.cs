using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    [SerializeField] bool circular = false;
    [SerializeField] bool sin = false;
    [SerializeField] Vector3 rot, move;
    [SerializeField] float rate = 1;
    Vector3 baseMove;

    void Start()
    {
        baseMove = transform.localPosition;
    }

    void Update()
    {
        if (circular)
        {
            transform.localEulerAngles += rot * Time.deltaTime * rate;
        }
        if (sin)
        {
            transform.localPosition = baseMove + move * Mathf.Sin(Time.time * rate);
        }
    }
}