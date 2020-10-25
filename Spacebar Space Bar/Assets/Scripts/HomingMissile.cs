using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public bool smart;
    public float armTime = 0;
    bool armed = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Arm());
    }

    // Update is called once per frame
    void Update()
    {
        if(smart && armed) { transform.LookAt(PlayerMovement.Instance.transform); }
    }

    IEnumerator Arm()
    {
        yield return new WaitForSeconds(armTime);
        armed = true;
        transform.LookAt(PlayerMovement.Instance.transform);
    }
}
