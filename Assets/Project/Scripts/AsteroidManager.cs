using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] int gridSpacing = 10;
    [SerializeField] int xQuantity = 3;
    [SerializeField] int yQuantity = 2;

    [SerializeField] int zQuantity = 18;

    
    
    [SerializeField] GameObject pickupPrefab;
    public List<Asteroid> asteroids = new List<Asteroid>();
    public Asteroid asteroid;
    // Start is called before the first frame update

    
    void Start()
    {
        //PlaceAsteroids();
    }

    void OnEnable()
    {
        EventManager.onStartGame += PlaceAsteroids;
        //EventManager.onPlayerDeath += DestroyAsteroids;
        //EventManager.onReSpawnPickup += PlacePickUp;
    }

    void OnDisable()
    {
        EventManager.onStartGame -= PlaceAsteroids;
        //EventManager.onPlayerDeath -= DestroyAsteroids;
        //EventManager.onReSpawnPickup -= PlacePickUp;
    }

    void DestroyAsteroids()
    {
        foreach(Asteroid ast in asteroids)
        {
            ast.SelfDestruct();
        }
        asteroids.Clear();
    }
    void PlaceAsteroids()
    {
        for(int x = 0; x < xQuantity; x++)
        {
            for(int y = 0; y < yQuantity; y++)
                for(int z = 0; z < zQuantity; z++)
                    InstantiateAsteroid(x , y ,z);
        }
        //PlacePickUp();
    }

    void InstantiateAsteroid(int x, int y, int z)
    {
        asteroids.Add(Instantiate(asteroid, 
        new Vector3(transform.position.x + (x * gridSpacing) + AsteroidOffset(), 
                    transform.position.y + (y * gridSpacing) + AsteroidOffset(), 
                    transform.position.z + (z * gridSpacing)+ AsteroidOffset()), 
                    Quaternion.identity, 
                    transform)); 
    }

    void PlacePickUp()
    {
        int random = Random.Range(0, asteroids.Count);
        Vector3 pos = asteroids[random].transform.position;
        Instantiate(pickupPrefab, pos, Quaternion.identity);
        Destroy(asteroids[random].gameObject);
        asteroids.RemoveAt(random);
    }

    float AsteroidOffset()
    {
        return Random.Range(-gridSpacing/2 , gridSpacing/2);
    }
}
