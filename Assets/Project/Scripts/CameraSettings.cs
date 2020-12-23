using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Este script lo llevan las 2 cámaras, la que proyecta al ojo izquierdo y la que proyecta al derecho
public class CameraSettings : MonoBehaviour
{
    
    StrabismusData data;
    Camera cam;

    void Awake()
    {
        data = GameObject.Find("StrabismusData").GetComponent<StrabismusData>();
        cam = gameObject.GetComponent<Camera>();
        // Aquí se escoge si esta cámara corresponde al ojo estrábico.
        if(gameObject.transform.name == "LeftCamera" && data.squintEye == "right"
           || gameObject.transform.name == "RightCamera" && data.squintEye == "left")
        {
            //Only render default layer;
            cam.cullingMask = 1 << 0; // Con esto se escoge que sólo se vea el layer "default"
        }
    }
}

/*
Para que funcione tal comoe está, los objetos de la escena que van a ser los que se "oculten", 
deben tener otra layer que no sea la default. Y todos los demás deben estar en default.

*/
