using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingShooterEnemy : Enemy
{
    public GameObject projectile1, projectile2;
    public Transform projOrigin;

    public float fireRate, rotationSpeed;
    protected override IEnumerator Behavior()
    {
        StartCoroutine(Shoot());

        while(hp>0)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator Shoot()
    {
        while(hp>0)
        {
            Instantiate(projectile1, projOrigin.position, transform.rotation);
            yield return new WaitForSeconds(1 / fireRate);

            Instantiate(projectile2, projOrigin.position, transform.rotation);
            yield return new WaitForSeconds(1 / fireRate);
        }
    }
}
