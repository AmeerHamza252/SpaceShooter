using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemPrefabs;
    private float spawnRangeX = 8;
    private float delayTime = 1;
    private float spawnInterval = 2f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEne", delayTime, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    void SpawnRandomEne()
    {
        int enemIndex = Random.Range(0, enemPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 6,0);
        Instantiate(enemPrefabs[enemIndex], spawnPos, enemPrefabs[enemIndex].transform.rotation);


    }

}
