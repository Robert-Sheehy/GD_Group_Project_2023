using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJammo : MonoBehaviour
{

    float walkingSpeed = 3;
    private float turningSpeed = 90;
    /// <summary>
    /// The distance to the centre of the sphere used to check for interactable objects
    /// </summary>
    float checkDistance = 1;
    float checkRadius = 0.5f;
    Animator jammoAnimator;

    // Start is called before the first frame update
    void Start()
    {
        jammoAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {   ///   s            =         u                      *       t
            transform.position += -walkingSpeed * transform.forward * Time.deltaTime; ;
            jammoAnimator.SetBool("isWalking", true);
        }
        else
            jammoAnimator.SetBool("isWalking", false);

        if (Input.GetKey(KeyCode.W))
        {   ///   s            =         u                      *       t
            transform.position += walkingSpeed * transform.forward * Time.deltaTime; ;
            jammoAnimator.SetBool("isWalking", true);
        }
        else
            jammoAnimator.SetBool("isWalking", false);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turningSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turningSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.F)) 
        {
            // Harvest Check
            Collider[] allPossibleInteractives = Physics.OverlapSphere(transform.position + checkDistance * transform.forward, checkRadius);
            print("Found " + allPossibleInteractives.Length.ToString());
            foreach (Collider c in allPossibleInteractives)
            {
                RockScript myRock = c.GetComponent<RockScript>();
                if (myRock != null)
                {
                    print("I found a rock");
                    myRock.ImHarvestingYou(this);

                }

            }
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Ouch!!! I just hit a " + collision.gameObject.name);
    }
}
