using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;
    [SerializeField] Laser[] laser;
    [SerializeField] GameObject deadCamera;

    [SerializeField] GameObject cam;
    // Update is called once per frame
    void Update()
    {
        //Turn();
        Thrust();
        Shoot();
    }


    void Thrust()
    {
        /*if(Input.GetAxis("Vertical") > 0) 
        {
            transform.position += cam.transform.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        }*/

        transform.position += cam.transform.forward * movementSpeed * Time.deltaTime;
    }

    void Shoot()
    {
        if(Input.GetMouseButtonDown(0))
        //if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Laser l in laser)
            {
                //Vector3 targetPos = l.transform.position + l.transform.forward * l.LaserLenght;
                l.FireLaser();
            }
        }
    }



    void OnEnable()
    {
        EventManager.onPlayerDeath += TimeUp;
    }

    void OnDisable()
    {
        EventManager.onPlayerDeath -= TimeUp;
    }

    void TimeUp()
    {
        Instantiate(deadCamera,transform.position,transform.rotation);
        GetComponent<Explosion>().OnlyBlowUp();
    }

}
