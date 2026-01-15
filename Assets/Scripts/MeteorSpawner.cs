using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorCapsule;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Meteors being spawned!");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpawnBuffer());
    }

    public void SpawnMeteor()
    {
        int spawnPointX = Random.Range(-500, 500);
        int spawnPointY = Random.Range(1, 15);
        int spawnPointZ = Random.Range(-500, 500);

        Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, spawnPointZ);

        Instantiate(meteorCapsule, spawnPosition, Quaternion.identity);
    }

    private IEnumerator SpawnBuffer()
    {

        yield return null;
        SpawnMeteor();
        yield return new WaitForSeconds(10f);
        
    }
}
