using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSize : MonoBehaviour
{
    [SerializeField]
    private GameObject ballLight;

    [SerializeField]
    private GameObject ballMedium;

    [SerializeField]
    private GameObject ballHeavy;

    private GameObject activeBall;

    public GameObject GetActiveBall()
    {
        return activeBall;
    }

    private void Start()
    {
        UpdateBall();
    }

    public void UpdateBall()
    {
        InactiveBalls();
        string size = PlayerPrefs.GetString("size");
        print("size" + size);
        switch (size)
        {
            case "LIGHT AND FAST":
                this.activeBall = ballLight;
                ballLight.SetActive(true);
                break;
            case "HEAVY AND PRECISE":
                this.activeBall = ballHeavy;
                ballHeavy.SetActive(true);
                break;
            default:
                this.activeBall = ballMedium;
                ballMedium.SetActive(true);
                break;

        }
    }

    private void InactiveBalls()
    {
        this.ballHeavy.SetActive(false);
        this.ballLight.SetActive(false);
        this.ballMedium.SetActive(false);
    }


}
