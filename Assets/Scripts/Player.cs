using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] Transform reticle;
    Camera cam;
    public int key = 0;

    void Awake()
    {
        Instance = this;
        cam = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 2))
        {
            reticle.localPosition = new Vector3(0, 0, hit.distance - 0.01f);
            Interactible focus = hit.transform.GetComponent<Interactible>();
            if (focus != null && Controls.Interact)
            {
                focus.Interact();
            }
        }
        else
        {
            reticle.localPosition = new Vector3(0, 0, 2);
        }
    }

}