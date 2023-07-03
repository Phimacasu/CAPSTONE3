using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    private Animator animatorKali;
    /// <summary>
    /// private SpriteRenderer renderer;
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {
        // /bool isWalking = false;
        ///animatorKali = GetComponent<Animator>();
        Debug.Log("Animator Found");

        ////renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //bool isWalking = animatorKali.GetBool("isWalking");
        bool forwardPress = Input.GetKeyDown(KeyCode.A);
        bool backwardPress = Input.GetKeyDown(KeyCode.D);
        
        if (forwardPress || backwardPress)
        {
            ////animatorKali.SetBool("isWalking",true);
            Debug.Log("Walking");
            ////renderer.flipX = true;
        }

         if (!forwardPress || !backwardPress)
        {
            ///animatorKali.SetBool("isWalking",false);
            Debug.Log("Not Walking");
        }
    }
}
