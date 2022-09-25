using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    [SerializeField]
    private GameObject text;

    private int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetPoints()
    {
        this.points = 0;
        this.UpdateText();
    }

    public void AddPoint()
    {
        this.points++;
        this.UpdateText();
    }

    private void UpdateText()
    {
        this.text.GetComponent<TextMeshProUGUI>().text = "Points: " + this.points;
    }
}
