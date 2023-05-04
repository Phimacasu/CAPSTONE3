using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform keyFollowPoint;

    public Key followingKey;

    public bool stateHasKey = false;

    float speed = 20f;

    float yMove = 0f;

    Rigidbody rb;
    bool stateIsGrounded = false;
    bool stateIsLaddered = false;
    bool stateIsClimbing = false;
    bool stateIsWatered = false;
    bool stateCanSwim = false;
    Vector3 movement;

    public Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -100.0f, 0);

        Debug.LogWarning(PlayerPrefs.GetInt("Sequence"));


        if(PlayerPrefs.HasKey("Net"))
            Debug.LogWarning(PlayerPrefs.GetInt("Net"));
        else
            Debug.LogWarning("Haven't gotten Net quest.");

        if (PlayerPrefs.HasKey("Lighter"))
            Debug.LogWarning(PlayerPrefs.GetInt("Lighter"));
        else
            Debug.LogWarning("Haven't gotten Lighter quest.");

        if (PlayerPrefs.HasKey("Box"))
            Debug.LogWarning(PlayerPrefs.GetInt("Box"));
        else
            Debug.LogWarning("Haven't gotten Box quest.");

        if (PlayerPrefs.HasKey("Mop"))
            Debug.LogWarning(PlayerPrefs.GetInt("Mop"));
        else
            Debug.LogWarning("Haven't gotten Mop quest.");


        if (PlayerPrefs.HasKey("SceneSpawn"))
        {
            if (PlayerPrefs.GetString("SceneSpawn") != SceneManager.GetActiveScene().name)
                SceneManager.LoadScene(PlayerPrefs.GetString("SceneSpawn"));
        }
        else
        {
            SceneManager.LoadScene("Tutorial");
        }
            
        if (PlayerPrefs.HasKey("SpawnX"))
            spawnPoint = new Vector3(PlayerPrefs.GetFloat("SpawnX"), PlayerPrefs.GetFloat("SpawnY"), 0f);
        else
            spawnPoint = gameObject.transform.position;

        transform.position = spawnPoint;
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.isActive == true)
            return;

        //Debug.Log(stateCanSwim);
        //Debug.Log(stateIsWatered);

        yMove = Input.GetAxisRaw("Vertical");
        movement = new Vector3(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y, 0f);//*Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.W) && stateIsGrounded && !stateIsClimbing)
        {
            rb.AddForce(new Vector3(0, 40f, 0), ForceMode.Impulse);
            stateIsGrounded = false;
        }

        if (stateIsLaddered && Mathf.Abs(yMove) > 0f)
        {
            stateIsClimbing = true;
        }

        if (stateIsWatered)
        {        
            if (PlayerPrefs.GetInt("Sequence") >= 11)
            {
                stateCanSwim = true;
            }
            else
            {
                stateCanSwim = false;
            }
                
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            /*
            PlayerPrefs.DeleteKey("SpawnX");
            PlayerPrefs.DeleteKey("Sequence");
            PlayerPrefs.DeleteKey("Checkpoint");
            PlayerPrefs.SetString("SceneSpawn", "Tutorial");
            SceneManager.LoadScene("Tutorial");
            */

            PlayerPrefs.DeleteKey("Net");
            PlayerPrefs.DeleteKey("Lighter");
            PlayerPrefs.DeleteKey("Box");
            PlayerPrefs.DeleteKey("Mop");
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            PlayerPrefs.SetFloat("SpawnX", 198);
            PlayerPrefs.SetFloat("SpawnY", 343);
            PlayerPrefs.SetInt("Sequence", 30);
            PlayerPrefs.DeleteKey("Checkpoint");
            PlayerPrefs.SetString("SceneSpawn", "CommercialAndCorporate");
            SceneManager.LoadScene("CommercialAndCorporate");
        }
    }
    void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector3 direction)
    {
        rb.velocity = direction;

        if (stateIsClimbing || stateIsWatered)
        {
            rb.useGravity = false;

            if(stateCanSwim || stateIsClimbing)
                rb.velocity = new Vector3(rb.velocity.x, yMove*speed, rb.velocity.z);
            else
                rb.velocity = new Vector3(rb.velocity.x, Mathf.Clamp(yMove, 0, 1f) * speed, rb.velocity.z); 
        }
        else
            rb.useGravity = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            stateIsGrounded = true;

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.LogError("Hit an enemy! Respawning to latest checkpoint...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.LogError("Hit an enemy! Respawning to latest checkpoint...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ladder")
            stateIsLaddered = true;

        if (other.gameObject.tag == "Water")
            stateIsWatered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            stateIsLaddered = false;
            stateIsClimbing = false;
        }

        if (other.gameObject.tag == "Water")
        {
            stateIsWatered = false;
            stateCanSwim = false;
        }         
    }
}