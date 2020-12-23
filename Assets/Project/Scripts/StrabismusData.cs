using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrabismusData : MonoBehaviour
{
    // Start is called before the first frame update
    static StrabismusData instance;

    public string squintEye; // Aquí se guarda qué ojo será el estrábico.
    
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
    }

}
