using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinsController : MonoBehaviour
{

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody rb;
    private PointManager pointManager;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = gameObject.GetComponent<Rigidbody>();
        this.pointManager = GameObject.FindObjectOfType<PointManager>();
        this.startPosition = gameObject.transform.position;
        this.startRotation = gameObject.transform.rotation;
    }


    void Update()
    {
        // CheckBoardTouch();
    }


    public void ResetPosition()
    {
        this.rb.velocity = Vector3.zero;
        this.rb.angularVelocity = Vector3.zero;
        this.rb.useGravity = false;
        this.gameObject.transform.position = this.startPosition;
        this.gameObject.transform.rotation = this.startRotation;
        gameObject.GetComponent<BoxCollider>().enabled = true;
        // Instantiate(gameObject, startPosition, Quaternion.identity);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball" || collision.gameObject.tag == "Pin")
        {
            this.rb.useGravity = true;
            AudioManager.GetInstance().PlayCollapsePins();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Board")
        {
            // print("point");
            pointManager.AddPoint();
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    // private void CheckBoardTouch()
    // {
    //     RaycastHit hit;
    //     Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
    //     if (Physics.Raycast(ray, out hit))
    //     {
    //         if (hit.collider.tag == "ResetButton")
    //         {
    //             ResetPosition();
    //         }
    //     }
    // }

}
