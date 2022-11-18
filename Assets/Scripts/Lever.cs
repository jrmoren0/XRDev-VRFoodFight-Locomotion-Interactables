using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject launcher;
    [SerializeField] private BoxCollider spawnArea;


    private float X;
    private float pointRange;
   

    // Update is called once per frame
    void Update()
    {
        pointRange = Mathf.InverseLerp(0, 90,transform.localEulerAngles.x);//Converts lever angle to a value between 1 and 0
        X = Mathf.Lerp(spawnArea.bounds.min.x, spawnArea.bounds.max.x, pointRange);//Converts the value between 1 and 0 to a position in the bounds of the spawnArea width
        
        launcher.transform.position = new Vector3(X, 1, 1.5f); //moves the launcher object in the x axis;
        
        

    }
}
