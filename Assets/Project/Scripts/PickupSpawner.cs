using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] GameObject pickUpPrebaf;

   // [SerializeField] float spawnTimer = 5f;
    [SerializeField] float minZoffest = 30f;
    [SerializeField] float maxZoffest = 30f;
    
    [SerializeField] float xMaxPosition = 80f;
    [SerializeField] float xMinPosition = 6f;
    [SerializeField] float yMaxPosition = 20f;
    [SerializeField] float yMinPosition = 3f;
    
    Transform Tplayer;
    // Start is called before the first frame update
    void Start()
    {   
        Tplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SpawnPickUp();
    }

    void OnEnable()
    {
        EventManager.onReSpawnPickup += SpawnPickUp;
        EventManager.onPlayerDeath += DestroyMyself;
    }

    void OnDisable()
    {
        EventManager.onReSpawnPickup -= SpawnPickUp;
        EventManager.onPlayerDeath -= DestroyMyself;
    }

    Vector3 RandomPosition()
    {
        float x = Random.Range(xMinPosition, xMaxPosition);
        float y = Random.Range(yMinPosition,yMaxPosition);
        float z = Tplayer.position.z + Random.Range(minZoffest,maxZoffest);
        return new Vector3(x,y,z);
    }
    void SpawnPickUp()
    {
        Instantiate(pickUpPrebaf, RandomPosition(), Quaternion.identity);
    }
    

    void DestroyMyself()
    {
        Destroy(gameObject);
    }
}
