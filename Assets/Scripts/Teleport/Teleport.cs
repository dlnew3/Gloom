using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject player;
    
    private float currTime;

    
    private void bonus_mazeComplete(float time)
    {
        ScoreUpdate scoreUpdate = ScoreManager.instance.score.GetComponent<ScoreUpdate>();
        // Rounds the Time float to an integer
        int completeTime = (int)time;
        int bonusPts = 0;
        int avgComplete = ScoreManager.instance.mazeCompleteTime;
        
        if (avgComplete > completeTime)
        {
            int timeDiff = (avgComplete - completeTime);
            Debug.Log("difference in Time: " + timeDiff);
            //Occurs if maze is completed 2min faster than avg.
            if (timeDiff >= 120)
            {
                Debug.Log("timeDiff >= 120");
                bonusPts = 1000;
            }
            //Occurs if maze is completed between 1min and 1m59s faster than avg
            else if(timeDiff >= 60 && timeDiff < 120)
            {
                bonusPts = 500;
            }
            //Occus if maze is completed between 1sec and 59s faster than avg
            else if(timeDiff > 0 && timeDiff < 60)
            {
                bonusPts = 300;
            }
            //Occurs if maze is completed with time >= averageTime.
            else
            {
                bonusPts = 150;
            }
        }
        scoreUpdate.setCurrScore(bonusPts);
    }
    
    void OnTriggerEnter(Collider other) {
        bonus_mazeComplete(currTime);
        currTime = 0f;
        player.transform.position = teleportTarget.transform.position;

        LevelManager manager = FindObjectOfType<LevelManager>();
        Debug.Log("Initiating Teleport.manager.initNewMaze()...");
        manager.initNewMaze();
        Debug.Log("Completed Teleport.manager.initNewMaze()!");
    }

    private void Start()
    {
        player = PlayerManager.instance.player;
        Debug.Log("Teleport.cs - player variable assigned: " + player);
        currTime = 0f;
    }

    private void Update()
    {
        currTime += Time.deltaTime;
        Debug.Log("currTime = " + currTime);
    }
    
}
