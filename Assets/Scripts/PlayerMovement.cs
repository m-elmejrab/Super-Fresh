using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Animator playerAnimator;
    private float moveSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horAxis = Input.GetAxis("Horizontal");
        float verAxis = Input.GetAxis("Vertical");


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

            //transform.forward = -transform.forward;
            //playerAnimator.SetFloat("Speed", .5f);
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
            //moveSpeed = 10f;
        }
    }
}
