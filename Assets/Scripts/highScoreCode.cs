using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highScoreCode : MonoBehaviour
{
    public GameObject gm;
    public int points;
    void Start()
    {
        Score sc = gm.GetComponent<Score>();
        points = 0;
    }
}
