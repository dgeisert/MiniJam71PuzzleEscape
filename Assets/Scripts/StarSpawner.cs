using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject Star;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 1000; i++)
        {
            GameObject go = GameObject.Instantiate(Star, new Vector3(Random.value - 0.5f, Random.value - 0.5f, Random.value - 0.5f).normalized * 5f, Quaternion.identity);
            go.transform.localScale = (Random.value / 100 + 0.01f) * Vector3.one;
            go.GetComponent<MeshRenderer>().material.SetColor("_Color", Random.value < 0.1f ? Color.red : (Random.value < 0.8f ? (Random.value < 0.5f ? Color.white : Color.cyan) : Color.yellow));
            go.SetActive(true);
        }
    }
}