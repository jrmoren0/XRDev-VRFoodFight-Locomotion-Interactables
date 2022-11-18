using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{

    [SerializeField] private GameObject[] projectilePrefabs;

    [SerializeField] private Transform spawnPoint;

    [SerializeField] private float speed;

    int randomIndex;

    GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(Shooter());
    }

    IEnumerator Shooter()
    {
        
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(1);
        }
       
    }

    public void Shoot()
    {
        randomIndex = Random.Range(0, projectilePrefabs.Length);

        projectile = Instantiate(projectilePrefabs[randomIndex], spawnPoint.position, spawnPoint.rotation);


        projectile.GetComponent<Rigidbody>().AddForce(speed * spawnPoint.forward);

        Destroy(projectile, 5);



    }

    


}
