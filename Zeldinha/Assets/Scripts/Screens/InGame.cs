using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{

    public Text txtPoints;
    public int points;


    void Start()
    {
        points = 0;
    }

    void Update()
    {
        txtPoints.text = "x " + points.ToString();
    }
}
