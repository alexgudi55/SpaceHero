using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    Transform Tplayer;
    [SerializeField]float destroyOffset = 7f;

    void Start()
    {
        Tplayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null) 
            if(transform.position.z < Tplayer.position.z - destroyOffset)
            {
                Destroy(gameObject);
            }
    }
}
