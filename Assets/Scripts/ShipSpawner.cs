using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipSpawner : MonoBehaviour
{
    public GameObject shipCylinder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Ships being spawned!");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SpawnBuffer());
    }

    public void SpawnShip()
    {
        int spawnPointX = Random.Range(-500, 500);
        int spawnPointY = Random.Range(1, 15);
        int spawnPointZ = Random.Range(-250, 250);

        Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, spawnPointZ);

        Instantiate(shipCylinder, spawnPosition, Quaternion.identity);
    }

    private IEnumerator SpawnBuffer()
    {
        yield return null;
        SpawnShip();
        yield return new WaitForSeconds(5f);
    }
}
