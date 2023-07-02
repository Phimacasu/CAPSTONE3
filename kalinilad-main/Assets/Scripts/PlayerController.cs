using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform keyFollowPoint;

    public Key followingKey;

    public bool stateHasKey = false;

    public float movementSpeed = 6f;

    private bool isDialogueActive = false;
    private Rigidbody playerRigidbody;
    [SerializeField] private AudioSource moveSFX;
    [SerializeField] private AudioSource jumpSFX;
    [SerializeField] private AudioSource MetalLadderClimbSFX;
    ///[SerializeField] private AudioSource WoodLadderClimbSFX;
    [SerializeField] private AudioSource swimSFX;
    [SerializeField] private AudioSource MeleeHurtSFX;
    [SerializeField] private AudioSource ProjHurtSFX;

    float speed = 18f;

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


        if (PlayerPrefs.HasKey("Net"))
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

        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.isActive == true)
        {
            movement = Vector3.zero;
            return;
        }

        //Debug.Log(stateCanSwim);
        //Debug.Log(stateIsWatered);

        yMove = Input.GetAxisRaw("Vertical");
        movement = new Vector3(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y, 0f);//*Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.W) && stateIsGrounded && !stateIsClimbing || Input.GetKeyDown(KeyCode.Space) && stateIsGrounded && !stateIsClimbing)
        {
            jumpSFX.Play();
            rb.AddForce(new Vector3(0, 40f, 0), ForceMode.Impulse);
            stateIsGrounded = false;
        }

        if (stateIsLaddered && Mathf.Abs(yMove) > 0f)
        {
            stateIsClimbing = true;
        }

        if (stateIsWatered)
        {
                stateCanSwim = true;
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        /*if (Input.GetKeyDown(KeyCode.P))
        {

            PlayerPrefs.DeleteKey("SpawnX");
            PlayerPrefs.DeleteKey("Sequence");
            PlayerPrefs.DeleteKey("Checkpoint");
            PlayerPrefs.SetString("SceneSpawn", "Tutorial");
            SceneManager.LoadScene("Tutorial");


            PlayerPrefs.DeleteKey("Net");
            PlayerPrefs.DeleteKey("Lighter");
            PlayerPrefs.DeleteKey("Box");
            PlayerPrefs.DeleteKey("Mop");
        }*/

        /*if (Input.GetKeyDown(KeyCode.O))
        {
            /*PlayerPrefs.SetFloat("SpawnX", 0);
            PlayerPrefs.SetFloat("SpawnY", 5);
            PlayerPrefs.SetInt("Sequence", 30);
            PlayerPrefs.DeleteKey("Checkpoint");
            PlayerPrefs.SetString("SceneSpawn", "3.3");
            SceneManager.LoadScene("3.3");*/
        /*PlayerPrefs.SetFloat("SpawnX", 379);
        PlayerPrefs.SetFloat("SpawnY", 73);
        PlayerPrefs.SetInt("Sequence", 30);
        PlayerPrefs.DeleteKey("Checkpoint");
        PlayerPrefs.SetString("SceneSpawn", "Tutorial");
        SceneManager.LoadScene("Tutorial");*/
        /*PlayerPrefs.SetFloat("SpawnX", 428);
        PlayerPrefs.SetFloat("SpawnY", 143);
        PlayerPrefs.SetInt("Sequence", 30);
        PlayerPrefs.DeleteKey("Tunnels");
        PlayerPrefs.SetString("SceneSpawn", "Tunnels");
        /*SceneManager.LoadScene("Tunnels");*/
        /*PlayerPrefs.SetFloat("SpawnX", 366);
        PlayerPrefs.SetFloat("SpawnY", 42);
        PlayerPrefs.SetInt("Sequence", 30);
        PlayerPrefs.DeleteKey("Industrial");
        PlayerPrefs.SetString("SceneSpawn", "Industrial");
        SceneManager.LoadScene("Industrial");
        /*PlayerPrefs.SetFloat("SpawnX", 21);
        PlayerPrefs.SetFloat("SpawnY", 223);
        PlayerPrefs.SetInt("Sequence", 30);
        PlayerPrefs.DeleteKey("Checkpoint");
        PlayerPrefs.SetString("SceneSpawn", "Hub");
        SceneManager.LoadScene("Hub");
        PlayerPrefs.SetFloat("SpawnX", 111);
        PlayerPrefs.SetFloat("SpawnY", 83);
        PlayerPrefs.SetInt("Sequence", 30);
        PlayerPrefs.DeleteKey("CommercialAndCorporate");
        PlayerPrefs.SetString("SceneSpawn", "CommercialAndCorporate");
        SceneManager.LoadScene("CommercialAndCorporate");
    }*/

        /*if (Input.GetKeyDown(KeyCode.L))
         {
             PlayerPrefs.DeleteKey("SpawnX");
             PlayerPrefs.DeleteKey("Checkpoint");
         }*/

        if (!isDialogueActive)
        {
            // Handle player movement
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            moveSFX.Play();
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * movementSpeed;
            playerRigidbody.velocity = new Vector3(movement.x, playerRigidbody.velocity.y, movement.z);
        }
        else
        {
            // Disable player movement during dialogue
            playerRigidbody.velocity = Vector3.zero;
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

            if (stateCanSwim || stateIsClimbing)
            {
                if (stateIsClimbing)
                {
                    MetalLadderClimbSFX.Play();
                    rb.velocity = new Vector3(rb.velocity.x, yMove * speed, rb.velocity.z);
                }

                else if (stateCanSwim)
                {
                    swimSFX.Play();
                    rb.velocity = new Vector3(rb.velocity.x, yMove * speed, rb.velocity.z);
                }
            }
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
            MeleeHurtSFX.Play();
            Debug.LogError("Hit an enemy! Respawning to latest checkpoint...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.gameObject.tag == "ProjectileEnemy")
        {
            ProjHurtSFX.Play();
            Debug.LogError("Hit an enemy! Respawning to latest checkpoint...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            MeleeHurtSFX.Play();
            Debug.LogError("Hit an enemy! Respawning to latest checkpoint...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (other.gameObject.tag == "ProjectileEnemy")
        {
            ProjHurtSFX.Play();
            Debug.LogError("Hit an enemy! Respawning to latest checkpoint...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MetalLadder" || other.gameObject.tag == "WoodLadder")
            stateIsLaddered = true;

        if (other.gameObject.tag == "Water")
        {
            stateIsWatered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MetalLadder" || other.gameObject.tag == "WoodLadder")
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

    public void DisableMovement()
    {
        isDialogueActive = true;
    }

    public void EnableMovement()
    {
        isDialogueActive = false;
    }
}
