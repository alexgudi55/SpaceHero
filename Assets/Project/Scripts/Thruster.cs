using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
[RequireComponent(typeof(Light))]
public class Thruster : MonoBehaviour
{
    TrailRenderer tr;
    Light thrusterLight;

    void Awake()
    {
        tr = GetComponent<TrailRenderer>();
        thrusterLight = GetComponent<Light>();
    }

    void Start()
    {
        //thrusterLight.enabled = false;
        thrusterLight.intensity = 0;
    }
    public void Activate(bool activate = true)
    {
        if(activate) // For sound, effects etc...
        {
            tr.enabled = true;
            thrusterLight.enabled = true;
        }
        else
        {
            tr.enabled = false;
            thrusterLight.enabled = false;
        }
    }

    public void Intensity(float intensity)
    {
        thrusterLight.intensity = intensity * 2f;
    }

}
