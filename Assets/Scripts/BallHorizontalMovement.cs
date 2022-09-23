using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float shotSpeed = 10f;

    private bool isDefaultMovment = true;
    private Rigidbody rb;
    private Vector3 startPosition;
    private bool boardSpawned = false;

    void Start()
    {
        this.rb = gameObject.GetComponent<Rigidbody>();
        this.startPosition = gameObject.transform.position;
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
        this.rb.AddForce(Vector3.forward * shotSpeed);
    }

    public void ResetPosition()
    {
        this.rb.velocity = Vector3.zero;
        this.gameObject.transform.position = this.startPosition;
    }

    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider.CompareTag("Board"))
                {
                    Shot();
                }
            }
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
}
