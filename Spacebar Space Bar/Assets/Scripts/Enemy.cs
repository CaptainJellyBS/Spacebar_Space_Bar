using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int hp;
    protected Rigidbody rb;
    // Start is called before the first frame update
    protected void Start()
    {
        StartCoroutine(Behavior());
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected void Update()
    {
        if(hp <= 0) { Die(); }
    }

    public virtual void TakeDamage(int damage = 1)
    {
        hp -= damage;
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    protected abstract IEnumerator Behavior();
}
