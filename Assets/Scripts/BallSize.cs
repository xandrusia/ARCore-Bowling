using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSize : MonoBehaviour
{
    private void Start()
    {
        string size=PlayerPrefs.GetString("size");
        switch (size)
        { case "LIGHT AND FAST": gameObject.GetComponent<Rigidbody>().mass = 1;
                break;
            case "HEAVY AND PRECISE":gameObject.GetComponent<Rigidbody>().mass = 3;break;
         default:gameObject.GetComponent<Rigidbody>().mass = 2;
             break;
            
        }
    }

   
}
