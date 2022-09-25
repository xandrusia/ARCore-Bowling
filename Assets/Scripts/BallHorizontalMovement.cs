using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

public class BallHorizontalMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject rightLimiter;

    [SerializeField]
    private GameObject leftLimiter;

    [SerializeField]
    private GameObject ballMovementLine;

    [SerializeField]
    private float speed = 0.1f;

    [SerializeField]
    private float shotSpeed = 50f;

    private bool isDefaultMovment = false;
    private Rigidbody rb;
    private Vector3 startPosition;
    private bool boardSpawned = false;

    public Vector3 startRotation;
    public int velocity;

    void Start()
    {
        this.rb = gameObject.GetComponent<Rigidbody>();
        this.startPosition = gameObject.transform.position;
        StartCoroutine("ChangeDefaultMovement");
    }

    void FixedUpdate()
    {
        if (this.isDefaultMovment)
        {
            ChangeDirection();
            this.transform.position += new Vector3(speed, 0, 0);
        }
    }

    public void Shot()
    {
        this.isDefaultMovment = false;
        // this.rb.useGravity = true;
        this.rb.AddForce(Vector3.forward * shotSpeed);

        //Allows to rotate the ball
        transform.eulerAngles = startRotation;
    }

    public void ResetPosition()
    {
        this.rb.velocity = Vector3.zero;
        this.rb.useGravity = false;
        this.gameObject.transform.position = this.startPosition;
        this.isDefaultMovment = true;
    }

    void Update()
    {
        // CheckBoardTouch();

        //Updates the ball's rotational speed every second
        if (Input.touchCount > 0)
        {
            transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }
    }

    /* --------------- CHANGE DIRECTION WHEN BALL REACHES LIMITER --------------- */

    private void ChangeDirection()
    {
        if (gameObject.transform.position.x >= this.rightLimiter.transform.position.x)
        {
            this.speed = -this.speed;
        }
        if (gameObject.transform.position.x <= this.leftLimiter.transform.position.x)
        {
            this.speed = -this.speed;
        }
    }

    private IEnumerator ChangeDefaultMovement()
    {
        yield return new WaitForSeconds(1);
        this.isDefaultMovment = true;
    }

    // private void CheckBoardTouch()
    // {
    //     RaycastHit hit;
    //     // Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     if (Physics.Raycast(ray, out hit))
    //     {
    //         if (hit.collider.tag == "ResetButton")
    //         {
    //             ResetPosition();
    //         }

    //         if (hit.collider.tag == "ShotButton")
    //         {
    //             Shot();
    //         }
    //     }
    // }
}


// RaycastHit hit;
// Ray ray = yourARCamera.ScreenPointToRay(Input.GetTouch(0).position);
// if (Physics.Raycast(ray, out hit))
// {
//      // Check if what is hit is the desired object
//      if(hit.tag == "The_Tag_Of_The_Object_You_Are_Looking_For")
//      {
//            // User clicked the object.. Do something here..
//      }
// }
