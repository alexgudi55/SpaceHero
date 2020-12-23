using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CapsuleCollider))]
public class Pickup : MonoBehaviour
{
    int points = 100;
    [SerializeField] float rotationOffset = 100f;
    Vector3 randomRotation;
    [SerializeField] AudioSource pickupSound;
    bool beenHit = false;

    Transform Tplayer;
    [SerializeField]float destroyOffset = 7f;

    void Start()
    {
        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);
        Tplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.Rotate(randomRotation * Time.deltaTime);
        DestroyManager();
    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.name); 
        if(col.transform.CompareTag("Player"))
        {
            if(!beenHit)
             PickupHit();
        }
    }

    void DestroyManager()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null) 
            if(transform.position.z < Tplayer.position.z - destroyOffset)
            {
                EventManager.ReSpawnPickup();
                Destroy(gameObject);
            }
    }
    public void PickupHit()
    {
        if(!beenHit)
        {
            pickupSound.Play();
            beenHit = true;
            EventManager.ScorePoints(points);
            EventManager.ReSpawnPickup();
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        EventManager.onPlayerDeath += DestroyMyself;
    }

    void OnDisable()
    {
        EventManager.onPlayerDeath -= DestroyMyself;
    }

    void DestroyMyself()
    {
        Destroy(gameObject);
    }
}