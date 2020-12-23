using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Light))]
public class Laser : MonoBehaviour
{
    LineRenderer lr;
    Light laserLight;
    bool canFire;
    [SerializeField] float laserOnTime = .5f;
    [SerializeField] float laserLength = 70f;
    [SerializeField] float laserDelay = .5f;
    [SerializeField] float laserHitModifier = 100f;
    [SerializeField] AudioSource fireLaser;
    

    public float LaserLenght{ get{ return laserLength;} }
    
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        laserLight = GetComponent<Light>();
    }

    void Start()
    {
        lr.enabled = false;
        laserLight.enabled = false;
        canFire = true;
    }

    Vector3 CastRay()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward) * laserLength;

        if(Physics.Raycast(transform.position, fwd, out hit))
        {
            Debug.Log("We hit: " + hit.transform.name);
            SpawnExplosion(hit.point, hit.transform);

            if(hit.transform.CompareTag("Pickup"))
                hit.transform.GetComponent<Pickup>().PickupHit();
            if(hit.transform.CompareTag("Enemy"))
            {
                EnemyMovement n = hit.transform.GetComponent<EnemyMovement>();
                if(n != null)
                    n.GotHitByLaser();
            }
            return hit.point;
        }
        Debug.Log("We missed...");
        return transform.position + transform.forward * laserLength;
    }

    void SpawnExplosion(Vector3 hitPosition, Transform target)
    {
        Explosion tmp = target.GetComponent<Explosion>();
            if(tmp != null)
            {
                  tmp.WasHit(hitPosition);
                  tmp.AddForce(hitPosition, transform, laserHitModifier);
            }
              
    }
    public void FireLaser()
    {
        FireLaser(CastRay());
        
    }
    
    public void FireLaser(Vector3 targetPosition, Transform target = null)
    {
        if(canFire)
        {
            if(target != null) SpawnExplosion(targetPosition, target);
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, targetPosition);
            lr.enabled = true;
            laserLight.enabled = true;
            canFire = false;
            Invoke("TurnOffLaser", laserOnTime); 
            Invoke("CanFire", laserDelay );
            fireLaser.Play();
        }
    }

    void TurnOffLaser()
    {
        lr.enabled = false;
        laserLight.enabled = false;        
    }

    void CanFire()
    {
        canFire = true;
    }
}
