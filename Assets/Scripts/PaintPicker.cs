using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPicker : MonoBehaviour
{
    private MeshRenderer rend;

    public Material currentMaterial;
   
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        currentMaterial = other.GetComponent<Renderer>().material;
        rend.material = currentMaterial;
    }
}
