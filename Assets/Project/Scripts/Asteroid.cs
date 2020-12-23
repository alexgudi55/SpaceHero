using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float minScale = 0.7f;
    [SerializeField] float maxScale = 1.2f;
    [SerializeField] float rotationOffset = 100f;

    [SerializeField] GameObject blowUp;
    
    
    Vector3 randomRotation;
    // Start is called before the first frame update
    void Start()
    {
        /*random size*/
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minScale, maxScale);
        scale.y = Random.Range(minScale, maxScale);
        scale.z = Random.Range(minScale, maxScale);
        transform.localScale = scale;
        /*random rotation*/
        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(randomRotation * Time.deltaTime);
    }

    public void SelfDestruct()
    {
        Instantiate(blowUp, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnEnable()
    {
        EventManager.onPlayerDeath += SelfDestruct;
        //EventManager.onReSpawnPickup += PlacePickUp;
    }

    void OnDisable()
    {
        EventManager.onPlayerDeath -= SelfDestruct;
        //EventManager.onReSpawnPickup -= PlacePickUp;
    }
}
