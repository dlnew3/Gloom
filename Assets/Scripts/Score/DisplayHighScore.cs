using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour
{
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
