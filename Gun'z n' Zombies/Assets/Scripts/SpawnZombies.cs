using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombies : MonoBehaviour
{
    public Rigidbody zombie;
    public Transform spawnPoint;

    private int zombieSpawned;
    private int spawnTime;


    void Start()
    {
        spawnTime = Random.Range(3, 5);
        StartCoroutine(SpawntoLocation());
    }


    IEnumerator SpawntoLocation()
    {
        while (zombieSpawned < 10)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(zombie, spawnPoint.position, spawnPoint.rotation);
            zombieSpawned++;
        }
        
    }

}
