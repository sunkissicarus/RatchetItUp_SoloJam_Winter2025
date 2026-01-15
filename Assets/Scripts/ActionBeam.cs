using UnityEngine;

public class ActionBeam : MonoBehaviour
{
    //THIS IS FOR THE WORM HOLE
    public float xRange = 100f;
    public float zRange = 100f;
    public float spawnY = 5f;

    public GameObject[] myObjects;

    public Material newMaterial;
    public Material oldMaterial;

    private Renderer objectRenderer;

    public GameManager gm;

    public void WormHoleOnClick()
    {
        int randomIndex = Random.Range(0, myObjects.Length);
        GameObject objectToSpawn = myObjects[randomIndex];

        Vector3 spaceSpawnPosition = new Vector3(-5f, spawnY, -15f);

        Instantiate (objectToSpawn, spaceSpawnPosition, Quaternion.identity);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            WormHoleOnClick();
            Debug.Log("Tear through space!");
        }
    }

}
