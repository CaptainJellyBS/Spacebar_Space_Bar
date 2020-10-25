using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAimingLaserEnemy : Enemy
{
    public float chargeTime, rotationSpeed;
    public Transform laserOrigin;
    public GameObject laser, chargeLight;
    public Color chargeLightColor = Color.green;

    protected override IEnumerator Behavior()
    {
        StartCoroutine(ChargeAndShoot());
        
        while(true)
        {
            yield return null;
            //if(Quaternion.Angle(transform.rotation, Quaternion.LookRotation(PlayerMovement.Instance.transform.position - transform.position)) > 180)
            if(Vector3.SignedAngle(transform.forward, PlayerMovement.Instance.transform.position - transform.position, Vector3.up) >= 0)
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            }           
        }
    }

    IEnumerator ChargeAndShoot()
    {
        while (hp > 0)
        {
            float t = 0;
            while (t < chargeTime)
            {
                t += Time.deltaTime;
                chargeLight.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.Lerp(Color.black, chargeLightColor, t / chargeTime));
                yield return null;
            }

            Instantiate(laser, laserOrigin);
            yield return new WaitForSeconds(laser.GetComponent<DestroyAfterTime>().lifetime);
        }
    }
}
