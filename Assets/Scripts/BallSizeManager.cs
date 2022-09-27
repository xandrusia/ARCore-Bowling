using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSizeManager : MonoBehaviour
{
    Dropdown m_Dropdown;

    private void Start()
    {
        m_Dropdown=gameObject.GetComponent<Dropdown>();
        m_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(m_Dropdown);
        });
    }

    void DropdownValueChanged(Dropdown change)
    {
        PlayerPrefs.SetString("size", change.ToString());
    }
    
}
