using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour //Handles player movement
{

    private Animator playerAnimator;
    private float moveSpeed = 10f;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        float horAxis = Input.GetAxis("Horizontal");
        float verAxis = Input.GetAxis("Vertical");

        //Set the direction the player is facing based on input, then play the run animation
        if (verAxis > 0 && horAxis > 0)
        {
            transform.forward = Vector3.forward + Vector3.right;
            playerAnimator.SetFloat("Speed", moveSpeed);

        }
        else if (verAxis > 0 && horAxis < 0)
        {
            transform.forward = Vector3.forward + Vector3.left;
            playerAnimator.SetFloat("Speed", moveSpeed);
        }
        else if (verAxis < 0 && horAxis > 0)
        {
            transform.forward = Vector3.back + Vector3.right;
            playerAnimator.SetFloat("Speed", moveSpeed);
        }
        else if (verAxis < 0 && horAxis < 0)
        {
            transform.forward = Vector3.back + Vector3.left;
            playerAnimator.SetFloat("Speed", moveSpeed);
        }
        else if (verAxis > 0 && horAxis ==0)
        {
            transform.forward = Vector3.forward ;
            playerAnimator.SetFloat("Speed", moveSpeed);
        }
        else if (verAxis < 0 && horAxis == 0)
        {
            transform.forward = Vector3.back;
            playerAnimator.SetFloat("Speed",moveSpeed);
        }
        else if (horAxis > 0 && verAxis ==0)
        {
            transform.forward = Vector3.right;
            playerAnimator.SetFloat("Speed", moveSpeed);
        }
        else if (horAxis < 0 && verAxis == 0)
        {
            transform.forward = Vector3.left;
            playerAnimator.SetFloat("Speed", moveSpeed);
        }
        else 
        {
            playerAnimator.SetFloat("Speed", 0f);
        }
    }
}
