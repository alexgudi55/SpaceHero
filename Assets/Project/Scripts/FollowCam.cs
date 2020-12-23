using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform fellowCam;
    [SerializeField] bool rotateForDebugging = false;

    void Update() 
    {

        Turn();
    }

    void Turn()
    {
        transform.position = fellowCam.transform.position;
        if(rotateForDebugging)
        {
            transform.rotation = fellowCam.transform.rotation;
        }
    }

}
