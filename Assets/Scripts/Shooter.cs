using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 0.2f;

    public bool isFiring;
    Coroutine firingCoroutine;


    void Start()
    {
        
    }

    
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContiniusly());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(FireContiniusly());
            firingCoroutine = null;
        }
    }

    IEnumerator FireContiniusly()
    {
        while (is)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rigidbody = projectile.GetComponent<Rigidbody2D>();
            if(rigidbody != null) 
            {
                rigidbody.velocity = transform.up * projectileSpeed;                
            }
            Destroy(projectile, projectileLifetime);
            yield return new WaitForSeconds(firingRate);
        }
    }
}
