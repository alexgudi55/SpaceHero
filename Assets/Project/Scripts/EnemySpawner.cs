using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Timer timer;
    [SerializeField] float spawnTimer = 5f;
    [SerializeField] float Zoffest = 30f;
    [SerializeField] float xMaxPosition = 50f;
    [SerializeField] float xMinPosition = 6f;
    [SerializeField] float yMaxPosition = 20f;
    [SerializeField] float yMinPosition = 3f;
    
    [SerializeField] int level = 0;
    Transform Tplayer;

    bool starSpawning = false;
    // Start is called before the first frame update
    void Start()
    {   
        Tplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if(level == 0) StartSpawning();
    }

    void Update()
    {
        if(level == 1 && timer.timePassed > 30 && !starSpawning)
        {
            StartSpawning();
        }
        if(level == 2 && timer.timePassed > 80 && !starSpawning)
        {
            StartSpawning();
        }
        
    }

    /*void OnEnable()
    {
        EventManager.onStartGame += StartSpawning;
        EventManager.onPlayerDeath += StopSpawning;
    }

    void OnDisable()
    {
        EventManager.onStartGame -= StartSpawning;
        EventManager.onPlayerDeath -= StopSpawning;
    }*/

    Vector3 RandomPosition()
    {
        float x = Random.Range(xMinPosition, xMaxPosition);
        float y = Random.Range(yMinPosition,yMaxPosition);
        float z = Tplayer.position.z + Zoffest;
        return new Vector3(x,y,z);
    }
    void SpawnEnemy()
    {
        Debug.Log("Spawn by: " + level);
        Instantiate(enemyPrefab, RandomPosition(), Quaternion.Inverse(Quaternion.identity));
    }

    void StopSpawning()
    {
        CancelInvoke();
    }

    void StartSpawning()
    {
        starSpawning = true;
        InvokeRepeating("SpawnEnemy", spawnTimer, spawnTimer);
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
