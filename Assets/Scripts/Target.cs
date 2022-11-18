using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    [SerializeField] private BoxCollider spawnArea;
 

    [SerializeField] GameManager manager;
    private void OnCollisionEnter(Collision col){
    
    Destroy(col.gameObject);

     manager.AddPoint();

      MovetoRandomPosition();
    }

    private void MovetoRandomPosition()
    {

        float x = Random.RandomRange(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
        float y = Random.RandomRange(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
        float z = Random.RandomRange(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

        transform.position = new Vector3(x, y, z);
    }




}
