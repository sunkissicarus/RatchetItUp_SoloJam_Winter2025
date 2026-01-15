using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject planetSphere;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Planets being spawned!");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpawnBuffer());
    }

    public void SpawnPlanet()
    {
        int spawnPointX = Random.Range(-500, 500);
        int spawnPointY = Random.Range(1, 15);
        int spawnPointZ = Random.Range(-500, 500);

        Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, spawnPointZ);

        Instantiate(planetSphere, spawnPosition, Quaternion.identity);
    }
    private IEnumerator SpawnBuffer()
    {
        yield return null;
        SpawnPlanet();
        yield return new WaitForSeconds(20f);
        
    }
}
