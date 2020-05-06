using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{


    // Update is called once per frame
    void Start()
    {

        transform.localScale = new Vector3(1.0f, 0.5f, 0.5f);

    }
    void Update()
    {

        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
