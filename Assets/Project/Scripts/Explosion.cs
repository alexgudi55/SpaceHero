using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject explosion; 
    [SerializeField] GameObject blowUp; 
    
    [SerializeField] Rigidbody rigidBody;

    [SerializeField]Shield shield;


    public void WasHit(Vector3 pos)
    {
        GameObject go = Instantiate(explosion, pos, Quaternion.identity, transform) as GameObject;
        if(shield) shield.TakeDamage();
        Destroy(go, 6f);
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint contact in collision)
        {
            WasHit(contact.point);
        }
    }

    public void AddForce(Vector3 hitPosition, Transform hitSource, float laserHitModifier)
    {
        Debug.LogWarning("AddForce: "+hitSource.name+" -> "+gameObject.name);
        if(rigidBody)
        {
            Vector3 forceVector = (hitSource.position - hitPosition).normalized;
            rigidBody.AddForceAtPosition(forceVector * laserHitModifier, hitPosition, ForceMode.Impulse);
        }
    }

    public void BlowUp()
    {
        EventManager.PlayerDeath(); // call the onPlayerDeathEvent
        Instantiate(blowUp, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void OnlyBlowUp()
    {
        Instantiate(blowUp, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
