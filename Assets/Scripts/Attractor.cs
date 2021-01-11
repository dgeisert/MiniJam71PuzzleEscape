using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public static Attractor Instance;

    Dictionary<Transform, Vector3> dirs = new Dictionary<Transform, Vector3>();
    Vector3 spin = new Vector3(50, 50, 50);

    void Awake()
    {
        Instance = this;
    }

    public void StartAttraction()
    {
        StartCoroutine(Attract());
    }
    public void Add(Transform trans)
    {
        dirs.Add(trans, (transform.position - trans.position).normalized);
    }

    IEnumerator Attract()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 1000; i++)
        {
            yield return null;
            foreach (var item in dirs)
            {
                item.Key.position += Time.deltaTime * item.Value * 10f;
                item.Key.eulerAngles += spin * Random.value * Time.deltaTime;
            }
        }
    }
}