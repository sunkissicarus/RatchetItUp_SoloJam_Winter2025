using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class CaptainControl : MonoBehaviour
{   
    public float moveDuration = 1.0f; //time to move between tiles
    public float gridSize = 1f; //cell size on the grid
    private bool isMoving = false;
    private Vector3 targetPosition;

    public GameManager gm;

    public GameObject audioManager;
    
    public Vector3 myPos = Vector3.zero;
    public void Start()
    {
        Debug.Log("Captain's Ship online!");
        targetPosition = transform.position;
    }
    
    public void Update()
    {
        if (!isMoving)
        {
            //moving left
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine(MoveRoutine(Vector3.left * gridSize));
                gm.AddScore(1);
                Debug.Log("Moving left");
                audioManager.GetComponent<AudioManager>().Play("Movement");
            }

            //moving up
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                StartCoroutine(MoveRoutine(Vector3.forward * gridSize));
                gm.AddScore(3);
                Debug.Log("Moving forward");
                audioManager.GetComponent<AudioManager>().Play("Movement");
            }

            //moving right
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine(MoveRoutine(Vector3.right * gridSize));
                gm.AddScore(1);
                Debug.Log("Moving right");
                audioManager.GetComponent<AudioManager>().Play("Movement");
            }

            //moving down
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                StartCoroutine(MoveRoutine(Vector3.back * gridSize));
                gm.AddScore(-5);
                Debug.Log("Moving back");
                audioManager.GetComponent<AudioManager>().Play("Movement");
            }
        }
        
    }

    private IEnumerator MoveRoutine(Vector3 direction)
    {
        isMoving = true;

        Vector3 startPosition = transform.position;
        targetPosition = startPosition + direction;

        float elapsedTime = 0;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / moveDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //grip snapping
        transform.position = targetPosition;
        isMoving = false;
    }
}
