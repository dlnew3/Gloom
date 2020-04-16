using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public GameObject player; //object reference to our player
    public Vector3 offset; //object to hold our offset value
    // Start is called before the first frame update
    void Start()
    {
        //calculates the distance between the player and the camera position
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame & will also update once the player moves first.
    void LateUpdate()
    {
        //this makes the camera "follow" the player
        transform.position = offset + player.transform.position;
    }
}
