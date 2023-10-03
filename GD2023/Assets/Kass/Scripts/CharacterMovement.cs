using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{
    public float run = 5, strafe = 5, jump = 15, sensitivity = 150, force = 10;
    Rigidbody rigidbody;
    Animator animator;
    bool grounded;


    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            animator.SetBool("onGround", true);
            animator.SetBool("falling", false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        animator.SetBool("isWalking", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.velocity.y < 0)
        {
            animator.SetBool("falling", true);
        }

        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(transform.up, -sensitivity * Time.deltaTime);
        }
        else if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(transform.up, sensitivity * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            run = 10;
            strafe = 8;
            animator.SetBool("isRunning", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            run = 5;
            strafe = 5;
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rigidbody.AddForce(Vector3.up * force);
            grounded = false;
            animator.SetBool("jumpUp", true);
            animator.SetBool("onGround", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * run;
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isWalking", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * run;
            animator.SetBool("backWalk", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("backWalk", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * strafe;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * strafe;
        }
    }
}
