using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PinsController : MonoBehaviour
{

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody rb;
    private PointManager pointManager;
    private ARAnchor anchor;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = gameObject.GetComponent<Rigidbody>();
        this.anchor = gameObject.GetComponent<ARAnchor>();
        this.pointManager = GameObject.FindObjectOfType<PointManager>();
        this.startPosition = transform.localPosition;
        this.startRotation = gameObject.transform.rotation;
        // gameObject.transform.hasChanged
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
        this.gameObject.transform.localPosition = this.startPosition;
        this.gameObject.transform.rotation = this.startRotation;
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    public void UpdateStartPosition()
    {
        this.startPosition = anchor.transform.position;
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
