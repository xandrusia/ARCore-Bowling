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

    private bool isDefaultMovment = true;
    private Rigidbody rb;
    private Vector3 startPosition;
    private Quaternion startRotation;

    public int velocity;

    void Awake()
    {
        this.startPosition = gameObject.transform.localPosition;
        this.startRotation = gameObject.transform.rotation;
        this.isDefaultMovment = true;
    }

    void Start()
    {
        // this.rb = gameObject.GetComponent<Rigidbody>();
        this.startPosition = gameObject.transform.localPosition;
        this.startRotation = gameObject.transform.rotation;
    }

    void FixedUpdate()
    {
        if (this.isDefaultMovment)
        {
            ChangeDirection();
            this.transform.position += transform.right * speed;
        }
    }

    public void Shot()
    {
        this.isDefaultMovment = false;
        this.rb = gameObject.AddComponent<Rigidbody>();
        // this.rb.useGravity = true;
        this.rb.AddForce(transform.forward * shotSpeed);
    }

    public void ResetPosition()
    {
        Destroy(this.rb);
        this.transform.rotation = this.startRotation;
        this.gameObject.transform.localPosition = this.startPosition;
        this.isDefaultMovment = true;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }
    }

    public bool GetDefaultMovement()
    {
        return this.isDefaultMovment;
    }

    /* --------------- CHANGE DIRECTION WHEN BALL REACHES LIMITER --------------- */

    private void ChangeDirection()
    {
        if (gameObject.transform.position.z >= this.rightLimiter.transform.position.z)
        {
            this.speed = -this.speed;
        }
        if (gameObject.transform.position.z <= this.leftLimiter.transform.position.z)
        {
            this.speed = -this.speed;
        }
    }
}
