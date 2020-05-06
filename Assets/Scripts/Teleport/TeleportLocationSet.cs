using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportLocationSet : MonoBehaviour
{
    


    // Start is called before the first frame update
    void Start()
    {
        //Initialize Vector3 with default TeleportLocation.transform.position
        Vector3 location = transform.position;

        //Sets location to the expected next Maze center
        if ((location.x + 50) > 200)
        {
            location.z += 50;
            location.x = -200;
        }
        else
        {
            location.x += 50;
        }
        Debug.Log("Expected location of next Maze = " + location);
        //Randomizes the position of the TeleportLocation within the next Maze
        location.z += Random.Range(-25, 25);
        location.x += Random.Range(-25,25);
        transform.position = location;
        Debug.Log("Position of TeleportLocation: " + transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
