using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallSizeManager : MonoBehaviour
{
    private TMP_Dropdown m_Dropdown;

    private void Start()
    {
        m_Dropdown=gameObject.GetComponent<TMP_Dropdown>();
        m_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(m_Dropdown);
        });
    }

    void DropdownValueChanged(TMP_Dropdown change)
    {
        PlayerPrefs.SetString("size", change.captionText.text);
    }
    
}
