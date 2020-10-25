using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ProjectileDestructible")) 
        { 
            Destroy(other.gameObject);
            Destroy(gameObject);
            return;
        }

        
        if (other.CompareTag("EnemyDestructible")) 
        {
            GetEnemyFromObject(other.gameObject).TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        if(other.CompareTag("ProjectileIndestructible") || other.CompareTag("EnemyIndestructible"))
        { 
            Destroy(gameObject); return; 
        }
    }

    Enemy GetEnemyFromObject(GameObject obj)
    {
        GameObject t = obj;
        Enemy r = t.GetComponent<Enemy>();

        while(!r)
        {
            t = t.transform.parent.gameObject;
            r = t.GetComponent<Enemy>();
        }

        return r;
    }
}
