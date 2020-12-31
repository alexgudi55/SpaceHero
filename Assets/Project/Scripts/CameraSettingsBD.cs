using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


// Este script lo llevan las 2 cámaras, la que proyecta al ojo izquierdo y la que proyecta al derecho
public class CameraSettingsBD : MonoBehaviour
{
    
    //StrabismusData data;
    Camera cam;
    public string idPaciente;
    public string idEspecialista;
    void Awake()
    {
        cam = gameObject.GetComponent<Camera>();
        // Aquí se escoge si esta cámara corresponde al ojo estrábico.
        ConsultasSQL sql = new ConsultasSQL();
        string[] eyes = sql.getAngleEyes();
        //Debug.Log("Ojos: " + eyes[0] + "--" +eyes[1]);
        idPaciente = eyes[2];
        idEspecialista = eyes[3];
        /*Establece que ve cada ojo*/
        if(!eyes[0].Equals("0") || !eyes[1].Equals("0")){
            if(gameObject.transform.name == "LeftCamera" && !eyes[0].Equals("0")){ // Ojo Izquierdo con estrabismo
                cam.cullingMask = 1 << 0 | 1<< 1 | 1 << 2 | 1 << 4 | 1 << 5 | 1 << 8;
            }else if(gameObject.transform.name == "RightCamera" && !eyes[1].Equals("0")){ // Ojo derecho con estrabismo
                cam.cullingMask = 1 << 0 | 1<< 1 | 1 << 2 | 1 << 4 | 1 << 5 | 1 << 8;
            }else{
                cam.cullingMask = 1 << 0 | 1<< 1 | 1 << 2 | 1 << 4 | 1 << 5;
            }
        }else{
            cam.cullingMask = 1 << 0 | 1<< 1 | 1 << 2 | 1 << 4 | 1 << 5 | 1 << 8;
        }
    }
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*
Para que funcione tal comoe está, los objetos de la escena que van a ser los que se "oculten", 
deben tener otra layer que no sea la default. Y todos los demás deben estar en default.
*/
