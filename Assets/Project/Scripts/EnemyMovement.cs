using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform target;
    [SerializeField] float rotationalDamp = 0.5f;
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] Laser laser;
    [SerializeField] float detectionDistancePath = 20f;
    [SerializeField] float raycastOffsetPath = 2.5f; 
    [SerializeField] GameObject blowUp; 
    
    Vector3 hitPosition;

    void Start()
    {
        if(FindTarget()) target = GameObject.FindGameObjectWithTag("Player").transform;
        else target = null;
    }


    void OnEnable()
    {
       // EventManager.onPlayerDeath += FindMainCamera;
        EventManager.onStartGame += SelfDestruct;
    }

    void OnDisable()
    {
        //EventManager.onPlayerDeath -= FindMainCamera;
        EventManager.onStartGame -= SelfDestruct;
    }

    void SelfDestruct()
    {
        //Destroy(gameObject);
    }
    void Update()
    {
        //Turn();
        if(GameObject.FindGameObjectWithTag("Player") != null) 
        {   PathFinding();
            Move();
            if(InFront() && HaveLineOfSightRayCast())
            {
                FireLaser();
            }
        }
    }

    void Turn()
    {
        //Debug.Log("The target is: " + target);
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationalDamp);
    }

    void Move()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    bool InFront()
    {
        Vector3 directionToTarget = transform.position - target.position;
        float angle = Vector3.Angle(transform.forward, directionToTarget);
        
        if(Mathf.Abs(angle) > 90 && Mathf.Abs(angle) < 270)
        {
            //Debug.DrawLine(transform.position, target.position, Color.green);
            return true;
        }
        //Debug.DrawLine(transform.position, target.position, Color.red);
        return false;
    }

    bool HaveLineOfSightRayCast()
    {
        RaycastHit hit;
        Vector3 direction = target.position - laser.transform.position;
       // Debug.DrawRay(laser.transform.position, directionToTarget , Color.blue);

        if(Physics.Raycast(laser.transform.position, direction, out hit, laser.LaserLenght))
        {

            if(hit.transform.CompareTag("Player"))
            {
                //Debug.DrawRay(laser.transform.position, direction, Color.blue);
                hitPosition = hit.transform.position;
                return true;
            }
        }
        return false;
    }

    void FireLaser()
    {
        laser.FireLaser(hitPosition, target);
    }

    void PathFinding()
    {
        RaycastHit hit;
        Vector3 raycastOffset = Vector3.zero;

        Vector3 left = transform.position - transform.right * raycastOffsetPath;
        Vector3 right = transform.position + transform.right * raycastOffsetPath;
        Vector3 up = transform.position + transform.up * raycastOffsetPath;
        Vector3 down = transform.position - transform.up * raycastOffsetPath;
        
        Debug.DrawRay(left, transform.forward * detectionDistancePath, Color.cyan);
        Debug.DrawRay(right, transform.forward * detectionDistancePath, Color.cyan);
        Debug.DrawRay(up, transform.forward * detectionDistancePath, Color.cyan);
        Debug.DrawRay(down, transform.forward * detectionDistancePath, Color.cyan);
        
        if(Physics.Raycast(left, transform.forward, out hit, detectionDistancePath))
            raycastOffset += Vector3.right;
    
        else if(Physics.Raycast(right, transform.forward, out hit, detectionDistancePath))
            raycastOffset -= Vector3.right;

        else if(Physics.Raycast(up, transform.forward, out hit, detectionDistancePath))
            raycastOffset -= Vector3.up;

        else if(Physics.Raycast(down, transform.forward, out hit, detectionDistancePath))
            raycastOffset += Vector3.up;

        if(raycastOffset != Vector3.zero)
            transform.Rotate(raycastOffset * 5f * Time.deltaTime);
        else
            Turn();
    }

    bool FindTarget()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null) return false;
        return true;
    }

/*    void FindMainCamera()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }*/


    public void GotHitByLaser()
    {
        Instantiate(blowUp, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
