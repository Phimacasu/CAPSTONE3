using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClimbing;

    [SerializeField] private Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            Debug.Log("works");
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            Debug.Log("works");
            isLadder = true;
        }

    }


    private void OnTriggerExit(Collider collision)
    {
        isLadder = false;
        isClimbing = false;
    }
}
