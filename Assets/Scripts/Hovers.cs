using UnityEngine;

public class Hovers : MonoBehaviour
{
    [SerializeField] private MeshFilter initialModel;
    [SerializeField] private Mesh targetModel;

    public GameManager gm;

    public GameObject audioManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        //Planets
        if (gameObject.CompareTag("Planet"))
        {
            //Hammer
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject);
                gm.AddScore(5);
                audioManager.GetComponent<AudioManager>().Play("Hammer");
                Debug.Log(tag + "HAMMERED");
            }

            //Scalpel
            if (Input.GetMouseButtonDown(1))
            {
                initialModel.mesh = targetModel;
                gm.AddScore(3);
                audioManager.GetComponent<AudioManager>().Play("Scalpel");
                Debug.Log(tag + "SCALPED");
            }
        }


        //Meteors
        if (gameObject.CompareTag("Meteor"))
        {
            //Hammer
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject);
                gm.AddScore(-3);
                audioManager.GetComponent<AudioManager>().Play("Hammer");
                Debug.Log(tag + "HAMMERED");
            }

            //Scalpel
            if (Input.GetMouseButtonDown(1))
            {
                initialModel.mesh = targetModel;
                gm.AddScore(-1);
                audioManager.GetComponent<AudioManager>().Play("Scalpel");
                Debug.Log(tag + "SCALPED");
            }
        }

        //Ships
        if (gameObject.CompareTag("Ship"))
        {
            //Hammer
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject);
                gm.AddScore(3);
                audioManager.GetComponent<AudioManager>().Play("Hammer");
                Debug.Log(tag + "HAMMERED");
            }

            //Scalpel
            if (Input.GetMouseButtonDown(1))
            {
                initialModel.mesh = targetModel;
                gm.AddScore(1);
                audioManager.GetComponent<AudioManager>().Play("Scalpel");
                Debug.Log(tag + "SCALPED");
            }
        }

        
    }
}
