using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private BallHorizontalMovement ball;
    private GameObject[] pins;
    private PointManager pointManager;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallHorizontalMovement>();
        pins = GameObject.FindGameObjectsWithTag("Pin");
        this.pointManager = GameObject.FindObjectOfType<PointManager>();
    }

    void Update()
    {
        CheckButtonTouch();
    }

    private void CheckButtonTouch()
    {
        RaycastHit hit;
        // Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "ResetButton")
            {
                ResetGame();
            }

            if (hit.collider.tag == "ShotButton")
            {
                this.ShotBall();
            }
        }
    }

    private void ResetGame()
    {
        ball.ResetPosition();
        pointManager.ResetPoints();
        foreach (var pin in pins)
        {
            if (pin != null)
            {
                pin.GetComponent<PinsController>()?.ResetPosition();
            }
        }
    }

    private void ShotBall()
    {
        if (this.ball.GetDefaultMovement())
        {
            ball.Shot();
        }
    }
}
