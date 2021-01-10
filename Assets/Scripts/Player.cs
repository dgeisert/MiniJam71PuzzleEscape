using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] Transform reticle;
    Camera cam;
    public bool[] key = new bool[] {false, false, false, false, false, false};
    Color neutral;
    Material mat;

    void Awake()
    {
        Instance = this;
        cam = GetComponentInChildren<Camera>();
        mat = reticle.GetComponent<MeshRenderer>().material;
        neutral = mat.GetColor("_Color");
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 3))
        {
            reticle.localPosition = new Vector3(0, 0, hit.distance - 0.01f);
            Interactible focus = hit.transform.GetComponent<Interactible>();
            if (focus != null)
            {
                if (Controls.Interact)
                {
                    focus.Interact();
                }
                mat.SetColor("_Color", Color.green);
            }
            else
            {
                mat.SetColor("_Color", neutral);
            }
        }
        else
        {
            reticle.localPosition = new Vector3(0, 0, 3);
            mat.SetColor("_Color", neutral);
        }
    }

}