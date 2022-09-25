using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinsController : MonoBehaviour
{

    private Vector3 startPosition;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = gameObject.GetComponent<Rigidbody>();
        this.startPosition = gameObject.transform.position;
    }

    
    void Update()
    {
        CheckBoardTouch();
    }


    public void ResetPosition()
    {
        this.rb.useGravity = true;
        this.gameObject.transform.position = this.startPosition;
    }

    private void CheckBoardTouch()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "ResetButton")
            {
                ResetPosition();
            }
        }
    }

}
