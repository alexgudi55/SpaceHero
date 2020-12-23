using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    // Update is called once per frame
    
    [SerializeField] float turnSpeed = 120f;
    void Update()
    {
        Turn();
    }

    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
         float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
         float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");
         transform.Rotate(pitch, yaw, -roll);
    }

}
