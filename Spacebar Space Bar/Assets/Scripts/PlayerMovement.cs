using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }

    public float moveSpeed, strafeSpeed, rotateSpeed, fireRate, laserBallLightUpTime;
    public GameObject laser;
    public GameObject[] laserBalls, engineBalls;
    bool firingLasers, flying, strafing;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        flying = Input.GetKey(KeyCode.W);
        strafing = Input.GetKey(KeyCode.LeftShift);


        if (flying) { transform.position += transform.forward * moveSpeed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.A)) 
        {
            if (!strafing)
            {
                transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
            }
            else
            {
                transform.position += -transform.right * strafeSpeed * Time.deltaTime;
            }
        }
        
        if (Input.GetKey(KeyCode.D)) 
        {
            if (!strafing)
            {
                transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
            }
            else
            {
                transform.position += transform.right * strafeSpeed * Time.deltaTime;
            }
        }

        if(Input.GetKey(KeyCode.Space) && !firingLasers) { StartCoroutine(FireLasers()); }

        SetEngineBalls();
    }

    IEnumerator FireLasers()
    {
        firingLasers = true;

        foreach (GameObject l in laserBalls)
        {
            l.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(255, 0, 0));
        }

        yield return new WaitForSeconds(laserBallLightUpTime);

        foreach (GameObject l in laserBalls)
        {
            l.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0, 0));
            Instantiate(laser, l.transform.position, transform.rotation);
        }

        yield return new WaitForSeconds((1 / fireRate)-laserBallLightUpTime);

        firingLasers = false;
    }

    void SetEngineBalls()
    {
        foreach (GameObject b in engineBalls)
        {
            if (flying)
            {
                b.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 151, 154));
            }
            else
            {
                b.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0, 0, 0));
            }
        }
    }
}
