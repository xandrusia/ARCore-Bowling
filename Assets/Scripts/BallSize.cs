using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSize : MonoBehaviour
{
    [SerializeField]
    private GameObject light;
    
    [SerializeField]
    private GameObject medium;
    
    [SerializeField]
    private GameObject heavy;
    private void Start()
    {
        string size=PlayerPrefs.GetString("size");
        switch (size)
        { case "LIGHT AND FAST": light.SetActive(true);
                break;
            case "HEAVY AND PRECISE":heavy.SetActive(true);break;
         default:medium.SetActive(true);
             break;
            
        }
    }

   
}
