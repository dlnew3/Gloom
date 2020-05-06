using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region Singleton
    public static ScoreManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    //Assign the GameObject Score_Amount to this public variable
    public GameObject score;
    //Assign an average completion time for a maze (in seconds)
    public int mazeCompleteTime;
   
}
